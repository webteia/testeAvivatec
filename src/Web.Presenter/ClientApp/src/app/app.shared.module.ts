import { NgModule } from '@angular/core';
import { UsuarioService } from './services/usuarioservices'
import {  CommonModule} from '@angular/common';
import {  FormsModule,  ReactiveFormsModule} from '@angular/forms';
import {  HttpModule} from '@angular/http';
import { RouterModule } from '@angular/router';
import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import {  HomeComponent} from './home/home.component';
import {  FetchDataComponent} from './fetch-data/fetch-data.component';
import {  CounterComponent} from './counter/counter.component';
import {  UsuarioDataComponent} from './components/usuariodata/usuariodata.components';
import {  AddUsuario} from './components/addusuario/addusuario.component';
@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    CounterComponent,
    FetchDataComponent,
    UsuarioDataComponent,
    HomeComponent,
    AddUsuario
  ],
  imports: [
    CommonModule,
    HttpModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule.forRoot([{
      path: '',
      redirectTo: 'home',
      pathMatch: 'full'
    }, {
      path: 'home',
      component: HomeComponent
    }, {
      path: 'counter',
      component: CounterComponent
    }, {
      path: 'fetch-data',
      component: FetchDataComponent
    }, {
      path: 'usuario-data',
      component: UsuarioDataComponent
    }, {
      path: 'add-usuario',
      component: AddUsuario
    }, {
        path: 'usuario/edit/:usuarioId',
      component: AddUsuario
    }, {
      path: '**',
      redirectTo: 'home'
    }])
  ],
  providers: [UsuarioService]
})
export class AppModuleShared { } 
