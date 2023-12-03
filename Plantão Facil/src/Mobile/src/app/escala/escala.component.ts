import { Component, OnInit } from '@angular/core';
import { Escala } from '../models/Escala';
import { ApiService } from '../config-service/config.services';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { Funcionario } from '../models/Funcionario';

@Component({
  selector: 'app-escala',
  templateUrl: './escala.component.html',
  styleUrls: ['./escala.component.scss']
})
export class EscalaComponent implements OnInit {
  private endpoint = 'https://localhost:7051/api/escales';
  private apiService: ApiService<Escala>;

  escalas: Escala[] = [];

  constructor(private http: HttpClient, private router: Router) {
    this.apiService = new ApiService<Escala>(this.http);
  }

  ngOnInit(): void {
    this.apiService.getAll(this.endpoint).subscribe((data) => {
      this.escalas = data.data.map(e => ({
        ...e,
        funcionarios: this.escalaVazia(e.funcionarios)    
      }));

      this.escalas.forEach(escala => {
        escala.funcionarios.forEach(funcionario => {
          funcionario.vaga = funcionario.vaga || {
            id: 0,
            funcao: "N/A",
            horario: new Date,
            numeroVagasDisponiveis: 0,
            situacaoId: 0,
            escalaId: 0
          };
        });
      });
      
    });  
  }
  
  private escalaVazia(funcionarios: Funcionario[]): Funcionario[] {
    if (!funcionarios || funcionarios.every(funcionario => !funcionario.nome)) {
      return [new Funcionario()];
    }
  
    return funcionarios;
  }  

  adicionarFuncionario(): void {
    this.router.navigate([`${'adicionar-funcionario'}`]);
  }

  adicionarEscala(): void {
    this.router.navigate([`${'adicionar-escala'}`]);
  }

  atualizarPagina(){  
    window.location.reload();
  }

  // atualizar(escala: Escala) {
  //   this.router.navigate([`${'atualizar-vaga'}`, vaga.id]);
  // }
}
