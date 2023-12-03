import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ToastController } from '@ionic/angular';
import { ApiService } from 'src/app/config-service/config.services';
import { Escala } from 'src/app/models/Escala';
import { Vaga } from 'src/app/models/Vaga';

@Component({
  selector: 'app-adicionar-escala',
  templateUrl: './adicionar-escala.component.html',
  styleUrls: ['./adicionar-escala.component.scss'],
})
export class AdicionarEscalaComponent  implements OnInit {
  private endpoint = 'https://localhost:7051/api/escales';
  private apiService: ApiService<Escala>;
  checkboxMarcado = false;
  numeroInclusoes: number = 0 ;
  listaIds: number[] = [];

  funcoes: Vaga[] = [];

  escala = new Escala();

  constructor(private http: HttpClient, private router: Router, private toastController: ToastController) { 
    this.apiService = new ApiService<Escala>(this.http);
  }

  ngOnInit() {
    this.getFuncoes();
  }

  getFuncoes() {
    let endpoint = 'https://localhost:7051/api/jobs';
    this.apiService.getAll(endpoint).subscribe((data) => {
      this.funcoes = data.data;
    });
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
    this.apiService.post(this.escala, this.endpoint).subscribe(
      async (data) => {
        await this.mostrarToast('Cadastrado com sucesso!', true);
      },
      async (error) => {
        await this.mostrarToast('Ops, falha ao tentar cadastrar.', false);
      }
    );
  }

  checkboxChanged(event: any) {
    this.checkboxMarcado = event.detail.checked;
  }

  onNumeroChange() {
    this.listaIds = Array.from({ length: this.numeroInclusoes }, (_, index) => index + 1);
  }
  
  voltar() {    
    this.router.navigate([`${'escalas'}`]);
  }

}
