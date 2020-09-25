export class Estacionamento {
  constructor() {
    this.id = 0;
    this.dataHoraEntrada = '';
    this.dataHoraSaida = '';
    this.veiculoId = 0;
    this.valorTotal = 0;
  }

  id: number;
  dataHoraEntrada: string;
  dataHoraSaida: string;
  veiculoId: number;
  valorTotal: number;
}
