import { Component,OnInit,TemplateRef  } from '@angular/core';
import {MovimientosService} from '../app/Services/Movimientos/movimientos.service';
import {IMovimiento,ICliente,IProductoMovimiento} from '../app/Models/MovimientosModel';
import { BsModalService, BsModalRef } from 'ngx-bootstrap/modal';
import { AgregarMovimientoComponent } from './agregar-movimiento/agregar-movimiento.component';
@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  modalRef: BsModalRef;
  IClientes : ICliente[] = [];
  IMovimientos : IMovimiento[] =[];
  IProductos : IProductoMovimiento[] = [];
  constructor(private _movimientos: MovimientosService, private modalService: BsModalService ){

  }
  ngOnInit(){
    this.cargarMovimientos();
  
  }

  cargarMovimientos(){
    this._movimientos.CargarMovimientos().subscribe(data=>{   
      this.llenarMovimiento(data['data']);
      
    },error=>{
      console.error(error);
    })
  }


  llenarMovimiento(Movimientos:IMovimiento[]) : void{
    
    //agrupamos por cliente 
     let groupby = Movimientos.reduce((result,movimiento)=>{
        (result[movimiento.clienteId] = result[movimiento.clienteId] || []).push({
          movimientoId : movimiento.movimientoId,
          cantidad:movimiento.cantidad,
          precio : movimiento.precio,
          producto : movimiento.producto,
          productoId : movimiento.productoId,
          fecha : movimiento.fecha
        })
        return result; 
     },{});

     //Obtenemos los id de cada cliente
     const clientsId = Object.keys(groupby);
     //insertamos en el modelo de cliente
     clientsId.forEach((item)=>{
        const movimiento = Movimientos.find((movimiento)=> movimiento.clienteId == Number(item))
        this.IClientes.push({
          cliente:movimiento.cliente,
          clienteId:movimiento.clienteId,
          edad_cliente:movimiento.edad_cliente,
          productos : groupby[item]

        });
     });
  }

  getPrecio(productos : IProductoMovimiento[]): number{
    let valor : number = 0;
    productos.forEach(item=>{
      valor  = valor + item.precio
    });
    return valor;
  }

  openModal(template: TemplateRef<any>, productos : IProductoMovimiento[]) {
    this.IProductos = productos;
    this.modalRef = this.modalService.show(template);
  }

  CrearMovimiento(){
    this.modalRef = this.modalService.show(AgregarMovimientoComponent,{class:'modal-lg',ignoreBackdropClick:true});
    this.modalRef.content.messageEvent.subscribe(data=>{
      console.log("mensaje del modal->"+data);
      if(data == 1){
        this.IClientes = [];
        this.cargarMovimientos();
      }
      
    });
  }

  eliminarMovimiento(clienteId:number){
    if(confirm("Al eliminar los movimientos de este usuario los productos regresaran a la base, estas seguro de eliminar estos movimientos?"))
    {
      this._movimientos.eliminarMovimiento(clienteId).subscribe(data=>{
        console.log(data);
        this.IClientes = [];
        this.cargarMovimientos();
      },error=>{
        console.log(error);
        
      })
    }else{
      console.log("No acepto")
    }
  }

}
