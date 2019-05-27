import { Injectable, Inject } from '@angular/core';
import { Http, Response } from '@angular/http';

import { Observable } from 'rxjs/Observable';
import { Router } from '@angular/router';

import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';
import 'rxjs/add/observable/throw';

@Injectable()
export class UsuarioService {
  myAppUrl: string = "";
  constructor(private _http: Http, @Inject('BASE_URL') baseUrl: string) {
    this.myAppUrl = baseUrl;
  }  
  deleteUsuario(UsuarioID: number) {
    return this._http.delete(this.myAppUrl + "api/Accounts/Delete/" + UsuarioID).map((response: Response) => response.json()).catch(this.errorHandler);
  }
  updateUsuario(usuario: any) {
    return this._http.put(this.myAppUrl + 'api/Accounts/Put', usuario).map((response: Response) => response.json()).catch(this.errorHandler);
  }
  saveUsuario(usuario: any) {
    return this._http.post(this.myAppUrl + 'api/Accounts/Post', usuario).map((response: Response) => response.json()).catch(this.errorHandler)
  }

  getById(userId: string) {
    return this._http.get(this.myAppUrl + 'api/Accounts/GetById', userId).map((response: Response) => response.json()).catch(this.errorHandler);
  }

  getUsuarios() {
    return this._http.get(this.myAppUrl + 'api/Accounts/GetAll').map((response: Response) => response.json()).catch(this.errorHandler);
  }

  errorHandler(error: Response) {
    console.log(error);
    return Observable.throw(error.json().error || 'Server error');
  }
}
