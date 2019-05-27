import {  Component,  OnInit} from '@angular/core';
import {  Http,  Headers} from '@angular/http';
import {  NgForm,  FormBuilder,  FormGroup,  Validators,  FormControl} from '@angular/forms';
import {  Router,  ActivatedRoute} from '@angular/router';
import {  UsuarioDataComponent } from '../usuariodata/usuariodata.components';
import {
  UsuarioService
} from '../../services/usuarioservices';
@Component({
  templateUrl: './addusuario.component.html'
})
export class AddUsuario implements OnInit {
  usuarioForm: FormGroup;
  title: string = "Criar";
  usuarioId: string;
  errorMessage: any;
  constructor(private _fb: FormBuilder, private _avRoute: ActivatedRoute, private _usuarioService: UsuarioService, private _router: Router) {
    if (this._avRoute.snapshot.params["usuarioID"]) {
      this.usuarioId = this._avRoute.snapshot.params["usuarioID"];
      //alert(this.usuarioId);  
    }
    this.usuarioForm = this._fb.group({
      usuarioId: '',
      nome: ['', [Validators.required]],
      email: ['', [Validators.required]],
      login: ['', [Validators.required]],
      senha: ['', [Validators.required]]
    })
  }
  ngOnInit() {
    if (this.usuarioId != '') {
      this.title = "Editar";
      this._usuarioService.getById(this.usuarioId).subscribe(resp => this.usuarioForm.setValue(resp), error => this.errorMessage = error);
    }
  }
  save() {
    if (!this.usuarioForm.valid) {
      return;
    }
    if (this.title == "Criar") {
      this._usuarioService.saveUsuario(this.usuarioForm.value).subscribe((data) => {
        this._router.navigate(['/usuario-data']);
      }, error => this.errorMessage = error)
    } else if (this.title == "Editar") {
      this._usuarioService.updateUsuario(this.usuarioForm.value).subscribe((data) => {
        this._router.navigate(['/usuario-data']);
      }, error => this.errorMessage = error)
    }
  }
  cancel() {
    this._router.navigate(['/usuario-data']);
  }
  get nome() {
    return this.usuarioForm.get('nome');
  }
  get email() {
    return this.usuarioForm.get('email');
  }
  get login() {
    return this.usuarioForm.get('login');
  }
  get senha() {
    return this.usuarioForm.get('senha');
  }  
}
