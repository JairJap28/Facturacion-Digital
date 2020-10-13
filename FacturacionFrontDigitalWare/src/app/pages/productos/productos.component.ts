import { Component, OnInit, ViewChild } from '@angular/core';

// DevExtreme
import { DxDataGridComponent } from 'devextreme-angular';
import notify from 'devextreme/ui/notify';

// Services
import { ProductosService } from './service/productos.service';

// Models
import { Producto } from './models/Producto';
import { Respuesta } from '../../core/models/Respuesta/Respuesta';
import { Categoria } from './models/Categoria';
import { CategoriaService } from './service/categoria.service';
import { Item } from '../../core/models/Item';

@Component({
  selector: 'app-productos',
  templateUrl: './productos.component.html',
  styleUrls: ['./productos.component.css']
})
export class ProductosComponent implements OnInit {
  @ViewChild(DxDataGridComponent, { static: false }) dataGrid: DxDataGridComponent;
  showHeaderFilter: boolean = true;
  showFilterRow: boolean = true;
  allMode: string;
  checkBoxesMode: string;
  loadingVisible = true;

  constructor(private productoService: ProductosService, private categoriaService: CategoriaService) {
    this.allMode = 'allPages';
    this.checkBoxesMode = 'onClick';
    this.getProducts();
    this.getCategories();
  }
  respuestaProductos: Producto[] = [];
  respuestaCategorias: Item[] = [];
  categoriasText: string[] = [];
  selectedCategory: Item;

  ngOnInit(): void { }

  getProducts() {
    this.productoService.getProducts()
    .subscribe((data: Respuesta<Producto>) => {
      this.respuestaProductos = data.entidades;
    }, () => notify({ message: "Ha ocurrido un error al consultar los productos"}, "error"))
  }

  getCategories(){
    this.categoriaService.getCategories()
    .subscribe((data: Respuesta<Categoria>) => {
      this.respuestaCategorias = data.entidades.map(cat => ({ text: cat.descripcion, value: cat.idCategoria }));
      this.categoriasText = data.entidades.map(cat => cat.descripcion);
      this.loadingVisible = false;
    }, () => notify({ message: "Ha ocurrido un error al consultar las categorias"}, "error"))
  }

  onChangeCategory(e){
    this.selectedCategory = e.selectedItem;
    this.filterCategory();
  }

  filterCategory() {
    if (this.selectedCategory) {
      this.dataGrid.instance.filter([
        ["idCategoria", "=", this.selectedCategory.value]
      ]);
    } else {
      this.dataGrid.instance.filter([
        ["idCategoria", "<>", 0]
      ]);
    }
  }

  onRowUpdated(event) {
    const producto: Producto = event.data;
    producto.idCategoria = this.respuestaCategorias.find(cat => cat.text === event.data.categoria).value;

    this.productoService.updateProduct(producto)
      .subscribe((data: Respuesta<Producto>) => {
        notify({ message: data.mensajes[0], width: 500 },data.resultado ? "success": "error");
      }, () => notify({ message: "Ha ocurrido un error al realizar la petición"}, "error"))
  }

  onRowInserted(event) {
    const indexProducto = this.respuestaProductos.findIndex(producto => !producto.idProducto);
    const producto: Producto = event.data;
    producto.idCategoria = this.respuestaCategorias.find(cat => cat.text === event.data.categoria).value;

    this.productoService.addProduct(producto)
      .subscribe((data: Respuesta<Producto>) => {
        this.respuestaProductos[indexProducto] = data.entidades[0];
        this.dataGrid.instance.refresh();
        notify({ message: data.mensajes[0], width: 500 },data.resultado ? "success": "error");
      }, () => notify({ message: "Ha ocurrido un error al realizar la petición"}, "error"));
  }
}
