import { Component, OnInit } from '@angular/core';
import { Funcionario } from '../models/Escala';
import { ApiService } from '../config-service/config.services';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-funcionario',
  templateUrl: './funcionario.component.html',
  styleUrls: ['./funcionario.component.scss'],
})
export class FuncionarioComponent implements OnInit {
  private endpoint = 'https://localhost:7051/api/employees';
  private apiService: ApiService<Funcionario>;

  funcionarios: Funcionario[] = [];

  constructor(private http: HttpClient) {
    this.apiService = new ApiService<Funcionario>(this.http);
  }

  ngOnInit(): void {
    this.apiService.getAll(this.endpoint).subscribe((data) => {
      this.funcionarios = data.data;
    });
  }
}
