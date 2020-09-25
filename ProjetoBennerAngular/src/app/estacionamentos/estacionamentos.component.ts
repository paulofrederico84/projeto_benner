import { VeiculoService } from './../services/veiculo.service';
import { Veiculo } from './../models/Veiculo';
import { EstacionamentoService } from '../services/estacionamento.service';
import { Estacionamento } from '../models/Estacionamento';
import { Component, OnInit, TemplateRef } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { BsModalService, BsModalRef } from 'ngx-bootstrap/modal';

@Component({
  selector: 'app-estacionamentos',
  templateUrl: './estacionamentos.component.html',
  styleUrls: ['./estacionamentos.component.css']
})
export class EstacionamentosComponent implements OnInit {

  public titulo = 'Estacionamento';
  public estacionamentoSelecionado: Estacionamento;
  public estacionamentoForm: FormGroup;
  public modalRef: BsModalRef;
  public modo = 'post';

  public estacionamentos = [];

  public veiculos = [];

  constructor(private fb: FormBuilder,
              private modalService: BsModalService,
              private estacionamentoService: EstacionamentoService,
              private veiculoService: VeiculoService) {
    this.criarForm();
  }

  openModal(template: TemplateRef<any>) {
    this.modalRef = this.modalService.show(template);
  }

  criarForm() {
    this.estacionamentoForm = this.fb.group({
      id: [  ],
      dataHoraSaida: ['', Validators.required],
      dataHoraEntrada: ['', Validators.required],
      veiculoId: ['', Validators.required],
      valorTotal: ['', Validators.required],
     }
   );
 }

 ngOnInit() {
   this.carregarEstacionamentos();
   this.carregarVeiculos();
 }

 carregarEstacionamentos() {
   this.estacionamentoService.getAll().subscribe(
      (resultado: Estacionamento[]) => {
        console.log(resultado);
        this.estacionamentos = resultado;
      },
      (erro: any) => {
        console.log(erro);
      }
   );
 }

 carregarVeiculos() {
  this.veiculoService.getAll().subscribe(
     (resultado: Veiculo[]) => {
       this.veiculos = resultado;
     },
     (erro: any) => {
       console.log(erro);
     }
  );
}

 novoEstacionamento() {
   this.estacionamentoSelecionado = new Estacionamento();
   this.estacionamentoForm.patchValue(this.estacionamentoSelecionado);
 }

 salvarEstacionamento(estacionamento: Estacionamento) {
   (estacionamento.id === 0 ? this.modo = 'post' : this.modo = 'put');
   console.log(estacionamento.id);
   this.estacionamentoService[this.modo](estacionamento).subscribe(
     (resultado: Estacionamento) => {
       console.log(resultado);
       this.estacionamentoSelecionado = resultado;
       this.carregarEstacionamentos();
     },
     (erro: any) => {
       console.log(erro);
     }
   );
 }

 excluirEstacionamento(estacionamento: Estacionamento) {
  this.estacionamentoService.delete(estacionamento.id).subscribe(
    (retorno: string) => {
      console.log(retorno);
      this.carregarEstacionamentos();
    },
    (erro: any) => {
      console.log(erro);
    }
  );
 }

 estacionamentoSelect(estacionamento: Estacionamento) {
    this.estacionamentoSelecionado = estacionamento;
    this.estacionamentoForm.patchValue(estacionamento);
  }

  voltar() {
    this.estacionamentoSelecionado = null;
  }

  estacionamentoSubmit() {
    this.salvarEstacionamento(this.estacionamentoForm.value);
  }
}
