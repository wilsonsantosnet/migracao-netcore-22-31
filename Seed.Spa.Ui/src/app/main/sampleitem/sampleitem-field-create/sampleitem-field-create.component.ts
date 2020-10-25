import { Component, OnInit, Input, ChangeDetectorRef, ViewChild } from '@angular/core';
import { SampleItemService } from '../sampleitem.service';

import { ViewModel } from '../../../common/model/viewmodel';
import { ModalDirective } from 'ngx-bootstrap/modal';
import { GlobalService, NotificationParameters } from '../../../global.service';

@Component({
    selector: 'app-sampleitem-field-create',
    templateUrl: './sampleitem-field-create.component.html',
    styleUrls: ['./sampleitem-field-create.component.css']
})
export class SampleItemFieldCreateComponent implements OnInit {

   @Input() vm: ViewModel<any>;

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
