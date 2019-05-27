import {  Component,  Inject} from '@angular/core';
import {  Http,  Headers} from '@angular/http';
import {  UsuarioService} from '../../services/usuarioservices'
import {  Router,  ActivatedRoute} from '@angular/router';
@Component({
  selector: 'usuariodata',
  templateUrl: './usuariodata.component.html'
})
export class UsuarioDataComponent {
  public usuariolist: UsuarioList[];
  constructor(public http: Http, private _router: Router, private _usuarioService: UsuarioService) {
    this.getUsuarios();
  }
  getUsuarios() {
    this._usuarioService.getUsuarios().subscribe(data => this.usuariolist = data)
    console.log(this.usuariolist);
  }
  deleteUsuario(usuarioId: number) {
    var ans = confirm("Deseja realmente deletar o usuário com o Id: " + usuarioId);
    if (ans) {
      this._usuarioService.deleteUsuario(usuarioId).subscribe((data) => {
        this.getUsuarios();
      }, error => console.error(error))
    }
  }
}
interface UsuarioList {
  ID: string;
  Nome: string;
  Email: string;
  Login: string;
  Senha: string;  
}
