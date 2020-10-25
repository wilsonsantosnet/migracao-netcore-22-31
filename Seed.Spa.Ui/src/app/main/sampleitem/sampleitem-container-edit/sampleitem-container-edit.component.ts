//EXT
import { Component, OnInit, Input } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

import { ModalDirective } from 'ngx-bootstrap/modal';
import { ViewModel } from '../../../common/model/viewmodel';
import { SampleItemService } from '../sampleitem.service';

@Component({
    selector: 'app-sampleitem-container-edit',
    templateUrl: './sampleitem-container-edit.component.html',
    styleUrls: ['./sampleitem-container-edit.component.css'],
})
export class SampleItemContainerEditComponent implements OnInit {

    @Input() vm: ViewModel<any>;
    id: number;
    private sub: any;

    constructor(private sampleItemService: SampleItemService, private route: ActivatedRoute, private router: Router) {

        this.vm = this.sampleItemService.initVM();
    }

    ngOnInit() {

       
    }

}
