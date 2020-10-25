//EXT
import { Injectable } from '@angular/core';
import { Observable, Observer } from 'rxjs';
import { Subject } from 'rxjs';
import { FormGroup, FormControl } from '@angular/forms';

import { ApiService } from '../../common/services/api.service';
import { ServiceBase } from '../../common/services/service.base';
import { ViewModel } from '../../common/model/viewmodel';
import { GlobalService } from '../../global.service';
import { SampleItemServiceFields } from './sampleitem.service.fields';
import { GlobalServiceCulture, Translated, TranslatedField } from '../../global.service.culture';
import { MainService } from '../main.service';

@Injectable()
export class SampleItemService extends ServiceBase {

    private _form : FormGroup;

    constructor(private api: ApiService<any>,private serviceFields: SampleItemServiceFields, private globalServiceCulture: GlobalServiceCulture, private mainService: MainService) {

        super();
        this._form = this.serviceFields.getFormFields();

    }

    initVM(): ViewModel<any> {

        return new ViewModel({
            mostrarFiltros: false,
            actionTitle: "SampleItem",
            actionDescription: "",
            key : this.serviceFields.getKey(),
            downloadUri: GlobalService.getEndPoints().DOWNLOAD,
            filterResult: [],
            modelFilter: {},
            summary: {},
            model: {},
            details: {},
            infos: this.getInfos(),
            grid: this.getInfoGrid(this.getInfos()),
            gridOriginal: this.getInfoGrid(this.serviceFields.getInfosFields()),
            generalInfo: this.mainService.getInfos(),
            form: this._form,
            masks: this.masksConfig(),
            manterTelaAberta : false,
            navigationModal: true
        });
    }

    getInfos() {
        return this.serviceFields.getInfosFields();
    }

    getInfoGrid(infos : any) {
        return super.getInfoGrid(infos)
    }

    updateCulture(culture: string = null) {
        return this.getInfosTranslated(this.globalServiceCulture.defineCulture(culture));
    }

    updateCultureMain(culture: string = null) {
        return this.mainService.getInfosTranslated(this.globalServiceCulture.defineCulture(culture));
    }

    getInfosTranslated(culture: string) {
        return this.globalServiceCulture.getInfosTranslatedStrategy('SampleItem', culture, this.getInfos(), []);
    }

    get(filters?: any): Observable<any> {
        return this.api.setResource('SampleItem').get(filters);
    }

    getDataCustom(filters?: any): Observable<any> {
        return this.api.setResource('SampleItem').getDataCustom(filters);
    }

    getDataListCustom(filters?: any): Observable<any> {
        return this.api.setResource('SampleItem').getDataListCustom(filters);
    }
    
    getDataListCustomPaging(filters?: any): Observable<any> {
        return this.api.setResource('SampleItem').getDataListCustomPaging(filters);
    }
    
    getDataItem(filters?: any): Observable<any> {
        return this.api.setResource('SampleItem').getDataitem(filters);
    }

    save(model: any): Observable<any> {

        if (model.sampleItemId) {
            return this.api.setResource('SampleItem').put(model);
        }

        return this.api.setResource('SampleItem').post(model);
    }

    delete(model: any): Observable<any> {
        return this.api.setResource('SampleItem').delete(model);
    }
    
    export(filters?: any): Observable<any> {
        return this.api.setResource('SampleItem').export(filters);
    }
}
