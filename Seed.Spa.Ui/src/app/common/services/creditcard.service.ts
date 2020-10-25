import { Injectable } from '@angular/core';
import { GlobalService } from '../../global.service';

declare var Moip: any;

@Injectable()
export class CreditCardService {


  pubKey: string;

  constructor() {

    this.pubKey = GlobalService.getEndPoints().WIRECARD_KEY;

  }


  public encripty(number: string, cvc: string, expMonth: string, expYear: string) {

    var cc = new Moip.CreditCard({
      number: number,
      cvc: cvc,
      expMonth: expMonth,
      expYear: expYear,
      pubKey: this.pubKey
    });

    if (cc.isValid()) 
      return cc.hash();
    
    return "";
  }


}
