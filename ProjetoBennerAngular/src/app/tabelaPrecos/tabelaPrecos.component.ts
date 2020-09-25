import { TabelaPrecoService } from '../services/TabelaPreco.service';
import { TabelaPreco } from '../models/TabelaPreco';
import { Component, OnInit, TemplateRef } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { BsModalService, BsModalRef } from 'ngx-bootstrap/modal';

@Component({
  selector: 'app-tabelaPrecos',
  templateUrl: './tabelaPrecos.component.html',
  styleUrls: ['./tabelaPrecos.component.scss']
})
export class TabelaPrecosComponent implements OnInit {

  public titulo = 'TabelaPreco';
  public tabelaPrecoSelecionado: TabelaPreco;
  public tabelaPrecoForm: FormGroup;
  public modalRef: BsModalRef;
  public modo = 'post';

  public tabelaPrecos = [];

  constructor(private fb: FormBuilder,
              private modalService: BsModalService,
              private tabelaPrecoService: TabelaPrecoService) {
    this.criarForm();
  }

  openModal(template: TemplateRef<any>) {
    this.modalRef = this.modalService.show(template);
  }

  criarForm() {
    this.tabelaPrecoForm = this.fb.group({
      id: [  ],
      dataHoraSaida: ['', Validators.required],
      dataHoraEntrada: ['', Validators.required],
      veiculoId: ['', Validators.required],
      valorTotal: ['', Validators.required],
     }
   );
 }

 ngOnInit() {
   this.carregarTabelaPrecos();
 }

 carregarTabelaPrecos() {
   this.tabelaPrecoService.getAll().subscribe(
      (resultado: TabelaPreco[]) => {
        this.tabelaPrecos = resultado;
      },
      (erro: any) => {
        console.log(erro);
      }
   );
 }

 novoTabelaPreco() {
   this.tabelaPrecoSelecionado = new TabelaPreco();
   this.tabelaPrecoForm.patchValue(this.tabelaPrecoSelecionado);
 }

 salvarTabelaPreco(tabelaPreco: TabelaPreco) {
   (tabelaPreco.id === 0 ? this.modo = 'post' : this.modo = 'put');
   this.tabelaPrecoService[this.modo](tabelaPreco).subscribe(
     (resultado: TabelaPreco) => {
       console.log(resultado);
       this.tabelaPrecoSelecionado = resultado;
       this.carregarTabelaPrecos();
     },
     (erro: any) => {
       console.log(erro);
     }
   );
 }

 excluirTabelaPreco(tabelaPreco: TabelaPreco) {
  this.tabelaPrecoService.delete(tabelaPreco.id).subscribe(
    (retorno: string) => {
      console.log(retorno);
      this.carregarTabelaPrecos();
    },
    (erro: any) => {
      console.log(erro);
    }
  );
 }

 tabelaPrecoSelect(tabelaPreco: TabelaPreco) {
    this.tabelaPrecoSelecionado = tabelaPreco;
    this.tabelaPrecoForm.patchValue(tabelaPreco);
  }

  voltar() {
    this.tabelaPrecoSelecionado = null;
  }

  tabelaPrecoSubmit() {
    this.salvarTabelaPreco(this.tabelaPrecoForm.value);
  }
}
