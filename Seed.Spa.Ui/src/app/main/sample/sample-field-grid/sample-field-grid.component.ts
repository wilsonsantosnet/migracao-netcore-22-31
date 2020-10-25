
import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';

import { ViewModel } from '../../../common/model/viewmodel';

@Component({
    selector: 'app-sample-field-grid',
    templateUrl: './sample-field-grid.component.html',
    styleUrls: ['./sample-field-grid.component.css']
})
export class SampleFieldGridComponent implements OnInit {


  @Input() vm: ViewModel<any>;

  @Output() edit = new EventEmitter<any>();
  @Output() details = new EventEmitter<any>();
  @Output() print = new EventEmitter<any>();
  @Output() deleteConfimation = new EventEmitter<any>();
  @Output() orderBy = new EventEmitter<any>();
  @Output() filter = new EventEmitter<any>();

  _isAsc: boolean;

  constructor() { }

  ngOnInit() {

  }

  onEdit(evt: any, model: any) {
    evt.preventDefault();
    this.edit.emit(model);
  }

  onDetails(evt: any, model: any) {
    evt.preventDefault();
    this.details.emit(model);
  }

  onPrint(evt: any, model: any) {
    evt.preventDefault();
    this.print.emit(model);
  }

  onDeleteConfimation(evt: any, model: any) {
    evt.preventDefault();
    this.deleteConfimation.emit(model);
  }

  onOrderBy(evt: any, field: any) {
    this._isAsc = !this._isAsc
    evt.preventDefault();
    this.orderBy.emit({
      field: field,
      asc: this._isAsc
    });
  }

  onFilter(evt: any) {
    this.filter.emit(this.vm.modelFilter);
  }

}
