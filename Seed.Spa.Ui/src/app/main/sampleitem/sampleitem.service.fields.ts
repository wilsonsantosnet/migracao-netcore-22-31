import { Injectable } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';

import { ServiceBase } from '../../common/services/service.base';

@Injectable()
export class SampleItemServiceFields extends ServiceBase {


	constructor() {
		super()
	}

	getKey() {
		return "SampleItem";
	}

	getFormControls(moreFormControls? : any) {
		var formControls = Object.assign({
      name : new FormControl(),
      sampleItemId : new FormControl(),
      sampleId : new FormControl(),
		},moreFormControls || {});
		return formControls;
	}

	getFormFields(moreFormControls?: any) {
		return new FormGroup(this.getFormControls(moreFormControls));
	}

	getInfosFields(moreInfosFields? : any, useMoreInfosFields = false) {
		var defaultInfosFields = {
      name: { label: 'name', type: 'string', isKey: false, list:true  ,  },
      sampleItemId: { label: 'sampleItemId', type: 'int', isKey: true, list:false  ,  },
      sampleId: { label: 'sampleId', type: 'int', isKey: false, list:true  , navigationProp:'Sample' },
		};
		return this.mergeInfoFields(defaultInfosFields, moreInfosFields, useMoreInfosFields);
	}

}
