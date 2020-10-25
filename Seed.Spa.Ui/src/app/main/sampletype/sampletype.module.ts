import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule  } from '@angular/forms';

import { ModalModule } from 'ngx-bootstrap/modal';

import { SampleTypeComponent } from './sampletype.component';

import { SampleTypeFieldCreateComponent } from './sampletype-field-create/sampletype-field-create.component';
import { SampleTypeFieldEditComponent } from './sampletype-field-edit/sampletype-field-edit.component';

import { SampleTypeContainerCreateComponent } from './sampletype-container-create/sampletype-container-create.component';
import { SampleTypeContainerEditComponent } from './sampletype-container-edit/sampletype-container-edit.component';

import { SampleTypeRoutingModule } from './sampletype.routing.module';

import { SampleTypeService } from './sampletype.service';
import { SampleTypeServiceFields } from './sampletype.service.fields';

import { ApiService } from '../../common/services/api.service';
import { CommonSharedModule } from '../../common/common-shared.module';


@NgModule({
    imports: [
        CommonModule,
        FormsModule,
        ReactiveFormsModule,
        ModalModule.forRoot(),
        CommonSharedModule,
        SampleTypeRoutingModule,

    ],
    declarations: [
        SampleTypeComponent,
        SampleTypeFieldCreateComponent,
        SampleTypeFieldEditComponent,
        SampleTypeContainerCreateComponent,
        SampleTypeContainerEditComponent
    ],
    providers: [SampleTypeService,SampleTypeServiceFields, ApiService],
	exports: [SampleTypeComponent]
})
export class SampleTypeModule {


}
