import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule  } from '@angular/forms';

import { ModalModule } from 'ngx-bootstrap/modal';

import { SampleItemComponent } from './sampleitem.component';

import { SampleItemFieldCreateComponent } from './sampleitem-field-create/sampleitem-field-create.component';
import { SampleItemFieldEditComponent } from './sampleitem-field-edit/sampleitem-field-edit.component';

import { SampleItemContainerCreateComponent } from './sampleitem-container-create/sampleitem-container-create.component';
import { SampleItemContainerEditComponent } from './sampleitem-container-edit/sampleitem-container-edit.component';

import { SampleItemRoutingModule } from './sampleitem.routing.module';

import { SampleItemService } from './sampleitem.service';
import { SampleItemServiceFields } from './sampleitem.service.fields';

import { ApiService } from '../../common/services/api.service';
import { CommonSharedModule } from '../../common/common-shared.module';


@NgModule({
    imports: [
        CommonModule,
        FormsModule,
        ReactiveFormsModule,
        ModalModule.forRoot(),
        CommonSharedModule,
        SampleItemRoutingModule,

    ],
    declarations: [
        SampleItemComponent,
        SampleItemFieldCreateComponent,
        SampleItemFieldEditComponent,
        SampleItemContainerCreateComponent,
        SampleItemContainerEditComponent
    ],
    providers: [SampleItemService,SampleItemServiceFields, ApiService],
	exports: [SampleItemComponent]
})
export class SampleItemModule {


}
