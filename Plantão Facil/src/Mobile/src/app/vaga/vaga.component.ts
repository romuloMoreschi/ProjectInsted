import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { ApiService } from '../config-service/config.services';
import { Vaga } from '../models/Vaga';
import { HttpClient } from '@angular/common/http';
import { DatePipe } from '@angular/common';
import { ToastController } from '@ionic/angular';

@Component({
  selector: 'app-vaga',
  templateUrl: './vaga.component.html',
  styleUrls: ['./vaga.component.scss'],
})
export class VagaComponent implements OnInit {
  private endpoint = 'http://206.189.184.232:5000/api/jobs';
  private apiService: ApiService<Vaga>;

  vagas: Vaga[] = [];

  constructor(private http: HttpClient, private datePipe: DatePipe, private router: Router, private toastController: ToastController) {
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

  atualizarPagina(){  
    window.location.reload();
  }

  private formatarData(data: string): string {
    return this.datePipe.transform(data, 'dd-MM-yyyy HH:mm') || '';
  }

  adicionarVaga(): void {
    this.router.navigate([`${'adicionar-vaga'}`]);
  }

  atualizar(vaga: Vaga) {
    this.router.navigate([`${'atualizar-vaga'}`, vaga.id]);
  }

  deletar(id: number) {
    this.apiService.delete(id, this.endpoint).subscribe(
      async (data) => {
        await this.mostrarToast('Deletado com sucesso!', true);
      },
      async (error) => {
        await this.mostrarToast('Ops, falha ao tentar deletar.', false);
      }
    );
    
  }

  async mostrarToast(mensagem: string, success: boolean) {    
    const toast = await this.toastController.create({
      message: mensagem,
      duration: 2000,
      position: 'top',
      color: success ? 'success' : 'danger',
    });
    toast.present();

    if(success){
      await this.delay(2000);
      window.location.reload();
    } 
  }

  delay(ms: number) {
    return new Promise(resolve => setTimeout(resolve, ms));
  }
}
