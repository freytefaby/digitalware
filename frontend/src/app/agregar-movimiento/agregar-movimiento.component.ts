import { EventEmitter, Output,Component, OnInit } from '@angular/core';
import { BsModalRef } from 'ngx-bootstrap/modal';
import {FormBuilder,FormGroup,FormControl,Validators,ReactiveFormsModule} from '@angular/forms';
import {MovimientosService} from '../Services/Movimientos/movimientos.service';
import { ICliente, IProducto } from '../Models/MovimientosModel';


@Component({
  selector: 'app-agregar-movimiento',
  templateUrl: './agregar-movimiento.component.html',
  styleUrls: ['./agregar-movimiento.component.css']
})
export class AgregarMovimientoComponent implements OnInit {
  @Output() messageEvent = new EventEmitter<number>();
  IClientes : ICliente[] = [];
  IProductos : IProducto[] = [];
  IProducto : IProducto = null;
  movimiento: FormGroup;
  public modelAgregarUsuario: Array<any> = [];
  constructor(private _movimientos: MovimientosService,
              public bsModalRef: BsModalRef,
              private formbuilder: FormBuilder) {
                this.formulario();
  }

  ngOnInit(): void {
    this.cargarClientes();
    this.cargarProductos();
  }

  formulario() : void{
    this.movimiento = this.formbuilder.group({
      clienteId : new FormControl(0,[Validators.required, Validators.pattern("^[0-9]*$"), Validators.min(1)]),
      productoId : new FormControl(0,[Validators.required, Validators.pattern("^[0-9]*$"), Validators.min(1)]),
      cantidad : new FormControl(0,[Validators.required, Validators.pattern("^[0-9]*$"), Validators.min(1)])
    });
  }

  cargarClientes(){
    this._movimientos.CargarClientes().subscribe(data=>{
      this.IClientes = data['data'] as ICliente[];
      console.log(this.IClientes);
      
    },error=>{})
  }

  cargarProductos(){
    this._movimientos.cargarProducto().subscribe(data=>{
      this.IProductos = data['data'] as IProducto[];
      console.log(this.IProductos);
      
    },error=>{})
  }

  agregarItem(){
   this.modelAgregarUsuario.push({
     productoId : Number(this.movimiento.get('productoId').value),
     cantidad : Number(this.movimiento.get('cantidad').value),
     producto : this.IProducto.descripcion,
     precio : this.IProducto.precio * this.movimiento.get('cantidad').value
   }); 
    
  }

  seleccionProducto(event:Event){
    this.IProducto = this.IProductos.find((producto)=>producto.id == Number(event));
  }

  agregarMovimiento(){
    const request = {
      clienteId : Number(this.movimiento.get('clienteId').value),
      productos : this.modelAgregarUsuario 
    }

    this._movimientos.crearMovimiento(request).subscribe(data=>{
      this.messageEvent.emit(1);
      this.bsModalRef.hide();
      
    },error=>{

      this.messageEvent.emit(0);
      alert("Error de servidor")
    });
    
    
  }

  eliminarItem(index:number){
    this.modelAgregarUsuario.splice(index,1)
  }

  

}
