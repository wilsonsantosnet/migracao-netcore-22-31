import { Component, OnInit, Input, ChangeDetectorRef, ViewChild } from '@angular/core';
import { SampleItemService } from '../sampleitem.service';

import { ViewModel } from '../../../common/model/viewmodel';
import { ModalDirective } from 'ngx-bootstrap/modal';

@Component({
    selector: 'app-sampleitem-field-edit',
    templateUrl: './sampleitem-field-edit.component.html',
    styleUrls: ['./sampleitem-field-edit.component.css']
})
export class SampleItemFieldEditComponent implements OnInit {

    @Input() vm: ViewModel<any>


    constructor(private sampleItemService: SampleItemService, private ref: ChangeDetectorRef) { }

    ngOnInit() {}

    ngOnChanges() {
       this.ref.detectChanges()
    }

    onSaveEnd(model: any) {
       
    }

    onBackEnd(model: any) {
       
    }

        

   
}
