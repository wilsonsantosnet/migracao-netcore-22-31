//EXT
import { Component, OnInit, Input } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

import { ModalDirective } from 'ngx-bootstrap/modal';
import { ViewModel } from '../../../common/model/viewmodel';
import { SampleItemService } from '../sampleitem.service';

@Component({
    selector: 'app-sampleitem-container-create',
    templateUrl: './sampleitem-container-create.component.html',
    styleUrls: ['./sampleitem-container-create.component.css'],
})
export class SampleItemContainerCreateComponent implements OnInit {

    @Input() vm: ViewModel<any>;
  
    constructor(private sampleItemService: SampleItemService, private route: ActivatedRoute, private router: Router) {

        this.vm = this.sampleItemService.initVM();
    }

    ngOnInit() {

       
    }

}
