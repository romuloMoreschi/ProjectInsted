import { Funcionario } from "./Funcionario";
import { Vaga } from "./Vaga";

export class Escala {
    public id: number;
    public dataInicial: Date;
    public dataTermino: Date;
    public funcionarioId: number;
    public vagaId: number;
    public funcionarios: Funcionario[]; 
    public vagas: Vaga[]; 

    constructor() {
        this.id = 0;
        this.dataInicial = new Date();
        this.dataTermino = new Date();
        this.funcionarioId = 0;
        this.vagaId = 0;
        this.funcionarios = [];
        this.vagas = [];
    }
}
