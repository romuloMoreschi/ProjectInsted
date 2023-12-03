import { Component, OnInit } from '@angular/core';
import { Escala, Funcionario } from '../models/Escala';
import { ApiService } from '../config-service/config.services';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-escala',
  templateUrl: './escala.component.html',
  styleUrls: ['./escala.component.scss']
})
export class EscalaComponent implements OnInit {
  private endpoint = 'https://localhost:7051/api/escales';
  private apiService: ApiService<Escala>;

  escalas: Escala[] = [];

  constructor(private http: HttpClient) {
    this.apiService = new ApiService<Escala>(this.http);
  }

  ngOnInit(): void {
    this.apiService.getAll(this.endpoint).subscribe((data) => {
      this.escalas = data.data.map(e => ({
        ...e,
        funcionarios: this.escalaVazia(e.funcionarios),
      }));
    });
  }
  
  private escalaVazia(funcionarios: Funcionario[]): Funcionario[] {
    if (!funcionarios || funcionarios.every(funcionario => !funcionario.nome)) {
      return [new Funcionario("Escala vazia", "", 0, 0)];
    }
  
    return funcionarios;
  }  

  adicionarFuncionario(): void {
    // Lógica para adicionar um novo funcionário
  }
}
