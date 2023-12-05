import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ToastController } from '@ionic/angular';
import { ApiService } from 'src/app/config-service/config.services';
import { Escala } from 'src/app/models/Escala';
import { Vaga } from 'src/app/models/Vaga';

@Component({
  selector: 'app-adicionar-vaga',
  templateUrl: './adicionar-vaga.component.html',
  styleUrls: ['./adicionar-vaga.component.scss'],
})
export class AdicionarVagaComponent implements OnInit {
  private endpoint = 'http://206.189.184.232:5000/api/jobs';
  private apiService: ApiService<Vaga>;
  vaga = new Vaga();

  escalas: Escala[] = [];

  constructor(private http: HttpClient, private router: Router, private toastController: ToastController) { 
    this.apiService = new ApiService<Vaga>(this.http);
  }

  ngOnInit() {
    this.getEscalas();
  }

  async mostrarToast(mensagem: string, success: boolean) {
    const toast = await this.toastController.create({
      message: mensagem,
      duration: 1000,
      position: 'top',
      color: success ? 'success' : 'danger',
    });
    toast.present();
  }

  enviar() {
    this.apiService.post(this.vaga, this.endpoint).subscribe(
      async (data) => {
        await this.mostrarToast('Cadastrado com sucesso!', true);
      },
      async (error) => {
        await this.mostrarToast('Ops, falha ao tentar cadastrar.', false);
      }
    );
  }

  voltar() {    
    this.router.navigate([`${'vagas'}`]);
  }

  getEscalas() {
    let endpoint = 'http://206.189.184.232:5000/api/escales';
    this.apiService.getAll(endpoint).subscribe((data) => {
      this.escalas = data.data;
    });
  }
}
