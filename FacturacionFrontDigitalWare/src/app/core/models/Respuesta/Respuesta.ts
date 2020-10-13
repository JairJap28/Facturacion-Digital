export interface Respuesta<T> {
    resultado: boolean;
    entidades: T[];
    mensajes: string[];
};
