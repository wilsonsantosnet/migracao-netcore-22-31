import { Component, Input, Output, OnChanges, EventEmitter, OnInit } from '@angular/core';
import { ViewModel } from '../model/viewmodel';
import { ServiceBase } from '../services/service.base';
import { ApiService } from '../services/api.service';

@Component({
  selector: 'make-grid-order',
  template: `<make-grid *ngIf="viewgrid"
                 (edit)="onEdit($event)"
                 (details)="onDetails($event)"
                 (print)="onPrint($event)"
                 (deleteConfimation)="onDeleteConfimation($event)"
                 (orderBy)="onOrderBy($event)"
                 (filter)="onFilter($event)"
                 [(vm)]="vm"
                 [showFilters]="showFilters"
                 [showPrint]="showPrint"
                 [showDelete]="showDelete"
                 [showDetails]="showDetails"
                 [showEdit]="showEdit">
            </make-grid>
            <nestable-tree *ngIf="!viewgrid && nestableData && vm.filterResult"
              (change)="onChangeNestable($event)"
              [data]="nestableData"
              [id]="content-nestable">
            </nestable-tree>
            <div class='col text-right mt-3'>
              <button *ngIf="savePending" (click)='onSaveOrder()' class='btn btn-success' title='Salvar Ordernação'><i class='fa fa-check'></i></button>
              <button (click)='onChangeView()' class='btn btn-warning' title='Trocar Visão'><i class='fa fa-tasks'></i></button>
            </div>`
})
export class MakeGridOrderComponent implements OnInit, OnChanges {


  @Input() vm: ViewModel<any>

  @Input() showCustom: boolean;
  @Input() showFilters: boolean;
  @Input() showEdit: boolean;
  @Input() showDetails: boolean;
  @Input() showPrint: boolean;
  @Input() showDelete: boolean
  @Input() showOrderBy: boolean;
  @Input() showCheckbox: boolean;
  @Input() showAction: boolean;
  @Input() actionLeft: boolean;
  @Input() gridCss: string;
  @Input() customButton: any = [];
  @Input() checkboxProperty: string;

  @Input() fieldNameDisplay: string;
  @Input() fieldNameId: string;
  @Input() fieldNameOrder: string;
  @Input() resourceOrder: string;

  @Output() edit = new EventEmitter<any>();
  @Output() details = new EventEmitter<any>();
  @Output() print = new EventEmitter<any>();
  @Output() deleteConfimation = new EventEmitter<any>();
  @Output() orderBy = new EventEmitter<any>();
  @Output() filter = new EventEmitter<any>();
  @Output() change = new EventEmitter<any>();


  viewgrid: boolean;
  nestableData: any;
  savePending: boolean;
  itensPending: any;

  constructor(private servicebase: ServiceBase, private api: ApiService<any>) {
    this.viewgrid = true;
    this.savePending = false;
  }

  onChangeView() {
    this.viewgrid = !this.viewgrid;
    this.loadNestableData();
  }

  setdefaultprops() {

    if (!this.resourceOrder)
      this.resourceOrder = this.vm.key;

    if (!this.fieldNameDisplay)
      this.fieldNameDisplay = "name";

    if (!this.fieldNameId)
      this.fieldNameId = this.servicebase.objectToArrayWithKeys(this.vm.infos).filter((item) => { return item.infos.isKey; })[0].key ;

    if (!this.fieldNameOrder)
      this.fieldNameOrder = "order";

  }

  loadNestableData() {

    this.setdefaultprops();
    this.nestableData = this.vm.filterResult.map((item) => {
      return {
        id: item[this.fieldNameId],
        name: item[this.fieldNameDisplay],
        dataAditional: item
      }
    });

  }

  ngOnChanges(): void {
    this.loadNestableData();
  }

  ngOnInit(): void {
    this.loadNestableData();
  }

  onEdit(model: any) {
    this.edit.emit(model);
  }

  onDetails(model: any) {
    this.details.emit(model);
  }

  onPrint(model: any) {
    this.print.emit(model);
  }

  onDeleteConfimation(model: any) {
    this.deleteConfimation.emit(model);
  }

  onOrderBy(model: any) {
    this.orderBy.emit(model);
  }

  onFilter(modelFilter: any) {
    this.filter.emit(modelFilter);
  }

  onChangeNestable(e) {
    this.change.emit(e);
    this.savePending = true;
    this.itensPending = e;
  }

  onSaveOrder(e) {

    var orderned = this.itensPending.map((item, i) => {
      var model = item.aditional;
      model[this.fieldNameOrder] = i + 1;
      model["attributeBehavior"] = "SaveOrder";
      return model
    })

    console.log("onSaveOrder", orderned);

    this.api.setResource(this.resourceOrder).postMany(orderned).subscribe((response) => {
      this.filter.emit(this.vm.modelFilter);
      this.savePending = false;
      this.onChangeView();
    })
  }

}
