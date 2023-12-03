export class Vaga {
    public id: number;
    public horario: Date;
    public funcao: string;
    public numeroVagasDisponiveis: number | null;
    public situacaoId: number;
    public escalaId: number;

    constructor() {
        this.id = 0;
        this.horario =  new Date;
        this.funcao = '';
        this.numeroVagasDisponiveis = null;
        this.situacaoId = 1;
        this.escalaId = 0;
    }
}
