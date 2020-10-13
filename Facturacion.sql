-- Creación base de datos --
CREATE DATABASE digitalWare;
USE digitalWare;

-- Creación de tablas --
CREATE TABLE Cliente (
	IdCliente INT IDENTITY(1,1) PRIMARY KEY,
	PrimerNombre NVARCHAR(50) NOT NULL,
	SegundoNombre NVARCHAR(50),
	PrimerApellido NVARCHAR(50) NOT NULL,
	SegundoApellido NVARCHAR(50),
	FechaNacimiento DATE,
	Cedula INT NOT NULL UNIQUE
);

CREATE TABLE Categoria (
	IdCategoria INT IDENTITY(1,1) PRIMARY KEY,
	Descripcion NVARCHAR(100)
);

CREATE TABLE Producto  (
	IdProducto INT IDENTITY(1,1) PRIMARY KEY,
	IdCategoria INT,
	Nombre NVARCHAR(50) NOT NULL,
	Precio DECIMAL NOT NULL,
	CONSTRAINT FK_Producto_Categoria FOREIGN KEY (IdCategoria) REFERENCES Categoria(IdCategoria)
);

CREATE TABLE InventarioProducto (
	IdInventario INT IDENTITY(1,1) PRIMARY KEY,
	IdProducto INT,
	Cantidad INT,
	CONSTRAINT FK_Producto_Inventario FOREIGN KEY (IdProducto) REFERENCES Producto(IdProducto)
);

CREATE TABLE Factura (
	IdFactura INT PRIMARY KEY,
	IdCliente INT,
	Fecha DATE,
	CONSTRAINT FK_Factura_Cliente FOREIGN KEY (IdCliente) REFERENCES Cliente(IdCliente)
);

CREATE TABLE DetalleFactura (
	IdDetalleFactura INT PRIMARY KEY,
	IdFactura INT,
	IdProducto INT,
	Precio Decimal,
	Observaciones NVARCHAR(150),
	CONSTRAINT FK_Factura_Detallle FOREIGN KEY (IdFactura) REFERENCES Factura(IdFactura),
	CONSTRAINT FK_Producto_Detalle FOREIGN KEY (IdProducto) REFERENCES Producto(IdProducto)
);
-- Fin Creación Tablas


-- Poblado de tablas --
INSERT INTO 
Cliente (Cedula,PrimerNombre,SegundoNombre,PrimerApellido,SegundoApellido,FechaNacimiento)
VALUES 
(1000000001,'Jair','Leonardo','Jimenez','Munevar','1998/08/28'),
(1000000002,'Zulay','Dayana','Jimenez','Leon','1998/01/16'),
(1000000003,'Ingrid','Dayana','Jimenez','Munevar','1989/06/23'),
(1000000004,'Cristhian','Manuel','Gomez','Martinez','1997/09/18'),
(1000000005,'Marcos','Javier','Mayorga','Cruz','1999/01/19');

INSERT INTO
Categoria (Descripcion)
VALUES
('MEMORIAS'),
('Monitores'),
('Teclados'),
('Mouses'),
('UPS');

INSERT INTO 
Producto (IdCategoria, Nombre,Precio) 
VALUES 
(1, 'Memoria RAM 8GB', 167000),
(1, 'Memoria RAM 16GB', 235000),
(2, 'Monitor Samsung Curso 24"', 568500),
(2, 'Monitor LG Ultra Wide 27"', 732120),
(5, 'UPS 500 Dinamica', 118000),
(5, 'UPS 650 Dinamica', 165000),
(3, 'Teclado semi-mecanico', 201350),
(3, 'Teclado Mecanico', 428200),
(4, 'Mouse Gamer RGB', 165320),
(4,'MOUSE Inalambrico 3000', 45000),
(4, 'Pad Mouse 92 Cm', 89900),
(4, 'Pad Mouse 25 Cm', 25500);

INSERT INTO 
InventarioProducto (IdProducto,Cantidad) 
VALUES
(1,15),
(2,12),
(3,8),
(4,3),
(5,6),
(6,4),
(7,17),
(8,12),
(9,1),
(10,34),
(11,15),
(12,2);

INSERT INTO 
Factura (IdFactura, IdCliente, Fecha)
VALUES
(1, 1, '2000/01/10'),
(2, 2, '2000/02/08'),
(3, 3, '2000/04/13'),
(4, 4, '2000/06/28'),
(5, 5, '2000/05/14'),
(6, 1, '2000/03/10'),
(7, 2, '2000/08/10'),
(8, 3, '2000/01/02'),
(9, 4, '2000/01/03'),
(10, 5, '2000/03/25'),
(11, 1, '2000/02/20'),
(12, 2, '2000/01/18'),
(13, 3, '2000/04/16'),
(14, 4, '2000/01/03');

INSERT INTO
DetalleFactura (IdDetalleFactura, IdFactura, IdProducto, Precio, Observaciones)
VALUES
(1, 1, 1, 167000, 'Memoria para portatil, verificada'),
(2, 1, 3, 568500, 'N/A'),
(3, 2, 9, 165320, 'RGB Color Blanco'),
(4, 3, 6, 165000, 'Cliente compra sin permitir verificación'),
(5, 4, 2, 235000, 'Memoria para portatil, verificada'),
(6, 5, 3, 568500, 'N/A'),
(7, 5, 1, 167000, 'Memoria para portatil, verificada'),
(8, 5, 8, 428200, 'N/A'),
(9, 6, 1, 167000, 'Memoria para portatil, verificada'),
(10, 7, 9, 165320, 'RGB Rojo'),
(11, 8, 12, 25500, 'Pad Mouse Gel Suave'),
(12, 9, 7, 201350, 'Se deja el registro que el cliente ve un desperfecto en la tecla A'),
(13, 10, 1, 167000, 'Memoria para portatil, verificada'),
(14, 10, 3, 568500, 'Se prueba el producto antes de ser entregado al cliente'),
(15, 11, 11, 89900, 'Pad mouse largo'),
(16, 12, 6, 165000, 'N/A'),
(17, 12, 5, 118000, 'UPS Verificada, caja con desperfecto'),
(18, 13, 9, 165320, 'RGB Azul'),
(19, 14, 4, 732120, 'N/A'),
(20, 14, 1, 167000, 'Memoria para portatil, verificada');
-- Fin Poblado de datos


-- CONSULTAS --
-- 1. Obtener la lista de precios de todos los productos --
SELECT
	IdProducto,
	Nombre,
	Precio
FROM Producto;

-- 2.Obtener la lista de productos cuya existencia en el inventario haya llegado al mínimo
-- permitido (5 unidades)
SELECT 
	Prod.IdProducto,
	Prod.Nombre,
	InvProd.Cantidad
FROM Producto AS Prod
LEFT JOIN InventarioProducto InvProd ON Prod.IdProducto = InvProd.IdProducto
WHERE InvProd.Cantidad <= 5;

-- 3.Obtener una lista de clientes no mayores de 35 años que hayan realizado compras entre el
-- 1 de febrero de 2000 y el 25 de mayo de 2000
SELECT DISTINCT
	Cli.IdCliente,
	Cli.Cedula,
	Cli.PrimerNombre,
	Cli.PrimerApellido,
	DATEDIFF(YEAR, FechaNacimiento, GETDATE()) as Edad
FROM Cliente Cli
LEFT JOIN Factura Fac ON Cli.IdCliente = Fac.IdCliente
WHERE (Fac.Fecha BETWEEN '2000/02/01' AND '2000/05/25') 
AND DATEDIFF(YEAR, FechaNacimiento, GETDATE()) < 35;


-- 4. Obtener el valor total vendido por cada producto en el año 2000
SELECT
	Pro.IdProducto	as IdProducto,
	Pro.Nombre		as Nombre,
	SUM(DetFac.Precio) as 'Valor Total',
	YEAR(Fac.Fecha) as Año
FROM Producto Pro
LEFT JOIN DetalleFactura DetFac ON Pro.IdProducto = DetFac.IdProducto
LEFT JOIN Factura Fac on Fac.IdFactura = DetFac.IdFactura
WHERE YEAR(Fac.Fecha) = 2000
GROUP BY Pro.IdProducto, YEAR(Fac.Fecha), Pro.Nombre, DetFac.Precio
ORDER BY Pro.IdProducto;

-- 5.Obtener la última fecha de compra de un cliente y según su frecuencia de compra estimar
-- en qué fecha podría volver a comprar.
SELECT 
	Cli.IdCliente,
	Cli.Cedula as Cedula,
	Cli.PrimerNombre + ' ' + Cli.PrimerApellido as Nombre,
	MIN(Fac.Fecha) as 'Fec. Primera Compra',
	MAX(Fac.Fecha) as 'Fec. Ultima Compra',
	--DATEDIFF(DAY, Min(Fac.Fecha), MAX(Fac.Fecha)) as Rango,
	COUNT(Fac.IdFactura) as 'Cant. Compras',
	(DATEDIFF(DAY, Min(Fac.Fecha), MAX(Fac.Fecha)) / COUNT(Fac.IdFactura)) as 'Frecuencia Compra',
	DATEADD(DAY, (DATEDIFF(DAY, Min(Fac.Fecha), MAX(Fac.Fecha)) / COUNT(Fac.IdFactura)), MAX(Fac.Fecha)) as 'Proxima Compra'
FROM Cliente Cli
LEFT JOIN Factura Fac ON Cli.IdCliente = Fac.IdCliente
GROUP BY Cli.IdCliente, Cli.Cedula, Cli.PrimerNombre, Cli.PrimerApellido;