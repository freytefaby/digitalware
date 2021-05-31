export class ICliente{
    cliente:string;
    clienteId:number;
    edad_cliente:number;
    productos: IProductoMovimiento[] 
}

export class IProductoMovimiento{
    movimientoId : number; 
    cantidad:number;
    precio : number;
    producto : string;
    productoId : number;
    fecha:string;
}

export interface IMovimiento{
    cliente:string;
    clienteId:number;
    edad_cliente:number;
    fecha:string;
    movimientoId : number; 
    cantidad:number;
    precio : number;
    producto : string;
    productoId : number;
}

export interface IProducto{
    id:number,
    descripcion:string,
    precio:number

}





