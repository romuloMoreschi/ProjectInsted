import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { RouteReuseStrategy } from '@angular/router';

import { IonicModule, IonicRouteStrategy } from '@ionic/angular';

import { AppComponent } from './app.component';
import { AppRoutingModule } from './app-routing.module';

import { MenuLateralComponent } from './shared/menu-lateral/menu-lateral.component';
import { HomeComponent } from './home/home.component';
import { FuncionarioComponent } from './funcionario/funcionario.component';
import { EscalaComponent } from './escala/escala.component';
import { VagaComponent } from './vaga/vaga.component';
import { ConfiguracaoComponent } from './configuracao/configuracao.component';
import { ApiService } from './config-service/config.services';
import { HttpClientModule } from '@angular/common/http';
import { DatePipe } from '@angular/common';

@NgModule({
  declarations: [
    AppComponent,
    MenuLateralComponent,
    HomeComponent,
    FuncionarioComponent,
    EscalaComponent,
    VagaComponent,
    ConfiguracaoComponent
  ],
  imports: [ HttpClientModule, BrowserModule, IonicModule.forRoot(), AppRoutingModule],
  providers: [ApiService, DatePipe, { provide: RouteReuseStrategy, useClass: IonicRouteStrategy }],
  bootstrap: [AppComponent],
})
export class AppModule {}
