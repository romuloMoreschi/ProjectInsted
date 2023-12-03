import { Vaga } from "./Vaga";

export class Funcionario {
    public nome: string;
    public sexo: string;
    public pontuacao: number;
    public situacaoId: number;    
    public vaga: Vaga; 

    constructor() {
        this.nome = 'Escala vazia';
        this.sexo = '';
        this.pontuacao = 1000;
        this.situacaoId = 0;
        this.vaga = new Vaga();
    }
}