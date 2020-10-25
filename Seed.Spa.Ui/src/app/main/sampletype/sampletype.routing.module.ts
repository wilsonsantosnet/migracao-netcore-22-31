import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { SampleTypeComponent } from './sampletype.component';


@NgModule({
    imports: [
        RouterModule.forChild([
            { path: '', data : { title : "SampleType" }, component: SampleTypeComponent },
        ])
    ],
    exports: [
        RouterModule
    ]
})

export class SampleTypeRoutingModule {
}