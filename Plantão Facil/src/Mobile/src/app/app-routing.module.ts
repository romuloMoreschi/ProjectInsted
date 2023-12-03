import { NgModule } from '@angular/core';
import { PreloadAllModules, RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { FuncionarioComponent } from './funcionario/funcionario.component';
import { EscalaComponent } from './escala/escala.component';
import { VagaComponent } from './vaga/vaga.component';
import { ConfiguracaoComponent } from './configuracao/configuracao.component';

const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'funcionarios', component: FuncionarioComponent },
  { path: 'escalas', component: EscalaComponent },
  { path: 'vagas', component: VagaComponent },
  { path: 'configuracoes', component: ConfiguracaoComponent }
];


@NgModule({
  imports: [
    RouterModule.forRoot(routes, { preloadingStrategy: PreloadAllModules })
  ],
  exports: [RouterModule]
})
export class AppRoutingModule {}
