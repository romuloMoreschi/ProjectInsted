export class Funcionario {
    public nome: string;
    public sexo: string;
    public pontuacao: number;
    public situacaoId: number;

    constructor(nome: string, sexo: string, pontuacao: number, situacaoId: number) {
        this.nome = nome;
        this.sexo = sexo;
        this.pontuacao = pontuacao;
        this.situacaoId = situacaoId;
    }
}

export class Escala {
    public id: number;
    public dataInicial: Date;
    public dataTermino: Date;
    public funcionarioId: number;
    public vagaId: number;
    public funcionarios: Funcionario[]; 

    constructor() {
        this.id = 0;
        this.dataInicial = new Date();
        this.dataTermino = new Date();
        this.funcionarioId = 0;
        this.vagaId = 0;
        this.funcionarios = [];
    }
}
