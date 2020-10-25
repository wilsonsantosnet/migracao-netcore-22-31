import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { ViewModel } from '../model/viewmodel';


@Component({
  selector: 'grid-filter',
  template: `
  <input *ngIf="show && type == 'string'" type='text' [(ngModel)]="vm.modelFilter[fieldName]"  (change)="onFilter($event,fieldName)" class="form-control form-control-sm"/>
  <input *ngIf="show && type == 'DateTime'" type='text' [(ngModel)]="vm.modelFilter[fieldName]"  (change)="onFilter($event,fieldName)" datepicker class="form-control form-control-sm"/>
  <input *ngIf="show && type == 'DateTime?'" type='text' [(ngModel)]="vm.modelFilter[fieldName]"  (change)="onFilter($event,fieldName)" datepicker class="form-control form-control-sm"/>
  <input *ngIf="show && type == 'int?' && !navigationProp" type='text' [(ngModel)]="vm.modelFilter[fieldName]"  (change)="onFilter($event,fieldName)" class="form-control form-control-sm"/>
  <input *ngIf="show && type == 'int' && !navigationProp" type='text' [(ngModel)]="vm.modelFilter[fieldName]"  (change)="onFilter($event,fieldName)" class="form-control form-control-sm"/>

  <input *ngIf="show && type == 'decimal?' && !navigationProp" type='text' [(ngModel)]="vm.modelFilter[fieldName]"  (change)="onFilter($event,fieldName)" class="form-control form-control-sm" [textMask]='{ mask: vm.masks.maskDecimal }'/>
  <input *ngIf="show && type == 'decimal' && !navigationProp" type='text' [(ngModel)]="vm.modelFilter[fieldName]"  (change)="onFilter($event,fieldName)" class="form-control form-control-sm" [textMask]='{ mask: vm.masks.maskDecimal }'/>

  <select *ngIf="show && navigationProp && pagination" class='form-control' [(ngModel)]="vm.modelFilter[fieldName]" datasource [dataitem]="navigationProp" [fieldFilterName]="'Name'" (change)="onFilter($event,fieldName)" class="form-control form-control-sm" [filterBehavior]="'GetDataListCustomPaging'"></select>
  <select *ngIf="show && navigationProp && !pagination" class='form-control' [(ngModel)]="vm.modelFilter[fieldName]" datasource [dataitem]="navigationProp" [fieldFilterName]="'Name'" (change)="onFilter($event,fieldName)" class="form-control form-control-sm"></select>

  <select *ngIf="show && type == 'dataitem'" class="form-control form-control-sm" [(ngModel)]="vm.modelFilter[fieldName]" (change)="onFilter($event,fieldName)" datasourceaux [dataitem]="fieldName" [dataAux]="aux" class="form-control form-control-sm"></select>
  <select *ngIf="show && type == 'bool'"class="form-control form-control-sm" [(ngModel)]="vm.modelFilter[fieldName]" (change)="onFilter($event,fieldName)" datasourceaux [dataitem]="fieldName" [dataAux]="[{ id: 'false', name: 'Não' }, { id: 'true', name: 'Sim' }]" ></select>
  <select *ngIf="show && type == 'bool?'"class="form-control form-control-sm" [(ngModel)]="vm.modelFilter[fieldName]" (change)="onFilter($event,fieldName)" datasourceaux [dataitem]="fieldName" [dataAux]="[{ id: 'false', name: 'Não' }, { id: 'true', name: 'Sim' }]" ></select>`
})
export class GridFilterComponent implements OnInit {

  @Output() filter = new EventEmitter<any>();

  @Input() vm: ViewModel<any>
  @Input() show: boolean;
  @Input() pagination: boolean;
  @Input() navigationProp: string;
  @Input() type: string;
  @Input() fieldName: string;
  @Input() aux: any;


  constructor() { }

  ngOnInit() {
    console.log("show", this.show);
    console.log("pagination", this.pagination);
    console.log("type", this.type);
    console.log("fieldName", this.fieldName);
  }

  onFilter(evt: any, field: any) {
    this.filter.emit(this.vm.modelFilter);
  }


}
