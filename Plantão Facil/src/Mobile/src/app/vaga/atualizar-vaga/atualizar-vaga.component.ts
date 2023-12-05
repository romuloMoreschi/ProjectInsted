import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastController } from '@ionic/angular';
import { ApiService } from 'src/app/config-service/config.services';
import { Escala } from 'src/app/models/Escala';
import { Vaga } from 'src/app/models/Vaga';

@Component({
  selector: 'app-atualizar-vaga',
  templateUrl: './atualizar-vaga.component.html',
  styleUrls: ['./atualizar-vaga.component.scss'],
})
export class AtualizarVagaComponent  implements OnInit {
  private endpoint = 'http://206.189.184.232:5000/api/jobs';
  private apiService: ApiService<Vaga>;
  vaga = new Vaga();

  escalas: Escala[] = [];

  constructor(private http: HttpClient, private router: Router, private toastController: ToastController, private route: ActivatedRoute) { 
    this.apiService = new ApiService<Vaga>(this.http);
  }

  ngOnInit() {
    this.getEscalas();

    this.route.params.subscribe(params => {
      this.vaga.id = params['id'];
    });
    this.apiService.get(this.vaga.id, this.endpoint).subscribe(
      async (data) => {        
        this.vaga = data.data
      },
      async (error) => {
        console.log(error);
      }
    );
  }

  async mostrarToast(mensagem: string, success: boolean) {
    const toast = await this.toastController.create({
      message: mensagem,
      duration: 1300,
      position: 'top',
      color: success ? 'success' : 'danger',
    });
    toast.present();

    if(success){
      await this.delay(1300);
      this.voltar();
    } 
  }

  delay(ms: number) {
    return new Promise(resolve => setTimeout(resolve, ms));
  }

  atualizar() {
    this.apiService.put(this.vaga, this.endpoint).subscribe(
      async (data) => {
        await this.mostrarToast('Atualizado com sucesso!', true);
      },
      async (error) => {
        await this.mostrarToast('Ops, falha ao tentar atualizar.', false);
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
