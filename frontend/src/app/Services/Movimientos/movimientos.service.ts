import { Injectable } from '@angular/core';
import {environment} from '../../../environments/environment';
import {HttpClient,HttpHeaders} from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class MovimientosService {

  constructor(private _http: HttpClient) {}


  public headers: HttpHeaders = new HttpHeaders({
    'Accept':'application/json'
  });


  CargarMovimientos(){
    const url = environment.ListarMovimientos;
    return this._http.get(url,{headers:this.headers});
}

CargarClientes(){
  const url = environment.ListarClientes;
  return this._http.get(url,{headers:this.headers});
}

cargarProducto(){
  const url = environment.ListarProducto;
  return this._http.get(url,{headers:this.headers});
}

crearMovimiento(request:any){
  const url = environment.ListarMovimientos;
  return this._http.post(url,request,{headers:this.headers});
}

eliminarMovimiento(clienteId : number){
  const url = environment.ListarMovimientos+"/"+clienteId;
  return this._http.delete(url,{headers:this.headers});
}
}
