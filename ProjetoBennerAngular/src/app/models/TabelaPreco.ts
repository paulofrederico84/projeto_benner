export class TabelaPreco {
  constructor() {
    this.id = 0;
    this.vigenciaInicial = null;
    this.vigenciaFinal = null;
    this.valorHora = '';
  }

  id: number;
  vigenciaInicial: Date;
  vigenciaFinal: Date;
  valorHora: string;
}
