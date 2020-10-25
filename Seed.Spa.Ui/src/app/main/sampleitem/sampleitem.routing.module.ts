import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { SampleItemComponent } from './sampleitem.component';


@NgModule({
    imports: [
        RouterModule.forChild([
            { path: '', data : { title : "SampleItem" }, component: SampleItemComponent },
        ])
    ],
    exports: [
        RouterModule
    ]
})

export class SampleItemRoutingModule {
}