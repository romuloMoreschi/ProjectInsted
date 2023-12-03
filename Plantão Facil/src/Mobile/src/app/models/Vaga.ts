export class Vaga {
    public id: number;
    public horario: Date;
    public funcao: string;
    public numeroVagasDisponiveis: number;
    public situacaoId: number;

    constructor(id: number, horario: Date, funcao: string, numeroVagasDisponiveis: number, situacaoId: number) {
        this.id = id;
        this.horario = horario;
        this.funcao = funcao;
        this.numeroVagasDisponiveis = numeroVagasDisponiveis;
        this.situacaoId = situacaoId;
    }
}
