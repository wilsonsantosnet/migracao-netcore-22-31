import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';

@NgModule({
	imports: [
		CommonModule,
		FormsModule,
    RouterModule.forChild([])
	],
  declarations: [],
  exports: [RouterModule]
})
export class UtilSharedModule {

}
