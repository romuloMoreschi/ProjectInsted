import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { RouteReuseStrategy } from '@angular/router';

import { IonicModule, IonicRouteStrategy } from '@ionic/angular';

import { AppComponent } from './app.component';
import { AppRoutingModule } from './app-routing.module';

import { MenuLateralComponent } from './shared/menu-lateral/menu-lateral.component';
import { HomeComponent } from './home/home.component';
import { FuncionarioComponent } from './funcionario/funcionario.component';

@NgModule({
  declarations: [
    AppComponent,
    MenuLateralComponent,
    HomeComponent,
    FuncionarioComponent
  ],
  imports: [BrowserModule, IonicModule.forRoot(), AppRoutingModule],
  providers: [{ provide: RouteReuseStrategy, useClass: IonicRouteStrategy }],
  bootstrap: [AppComponent],
})
export class AppModule {}
