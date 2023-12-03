import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { ApiService } from '../config-service/config.services';
import { Vaga } from '../models/Vaga';
import { HttpClient } from '@angular/common/http';
import { DatePipe } from '@angular/common';

@Component({
  selector: 'app-vaga',
  templateUrl: './vaga.component.html',
  styleUrls: ['./vaga.component.scss'],
})
export class VagaComponent  implements OnInit {
  private endpoint = 'https://localhost:7051/api/jobs';
  private apiService: ApiService<Vaga>;

  vagas: Vaga[] = [];

  constructor(private http: HttpClient, private datePipe: DatePipe) {
    this.apiService = new ApiService<Vaga>(this.http);
  }

  ngOnInit(): void {
    this.apiService.getAll(this.endpoint).subscribe((data) => {
      this.vagas = data.data.map(v => ({
        ...v,
        horario: this.formatarData(v.horario),
      }));
    });
  }

  private formatarData(data: string): string {
    return this.datePipe.transform(data, 'dd-MM-yyyy HH:mm') || '';
  }
}
