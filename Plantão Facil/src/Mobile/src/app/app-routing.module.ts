import { NgModule } from '@angular/core';
import { PreloadAllModules, RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { FuncionarioComponent } from './funcionario/funcionario.component';
import { EscalaComponent } from './escala/escala.component';
import { VagaComponent } from './vaga/vaga.component';
import { ConfiguracaoComponent } from './configuracao/configuracao.component';
import { AdicionarVagaComponent } from './vaga/adicionar-vaga/adicionar-vaga.component';
import { AtualizarVagaComponent } from './vaga/atualizar-vaga/atualizar-vaga.component';
import { AdicionarEscalaComponent } from './escala/adicionar-escala/adicionar-escala.component';

const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'configuracoes', component: ConfiguracaoComponent },
  { path: 'funcionarios', component: FuncionarioComponent },
  { path: 'escalas', component: EscalaComponent },
  { path: 'adicionar-escala', component: AdicionarEscalaComponent },
  { path: 'vagas', component: VagaComponent },
  { path: 'adicionar-vaga', component: AdicionarVagaComponent },
  { path: 'atualizar-vaga/:id', component: AtualizarVagaComponent },
];


@NgModule({
  imports: [
    RouterModule.forRoot(routes, { preloadingStrategy: PreloadAllModules })
  ],
  exports: [RouterModule]
})
export class AppRoutingModule {}
