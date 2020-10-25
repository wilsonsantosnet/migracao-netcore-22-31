import { Injectable } from '@angular/core';

@Injectable()
export class SessionStorageService {

  public static get(key: string) {
    try {
      return sessionStorage.getItem(key);
    } catch (e) {
      console.log("Erro ao acessar o sessionStorage " + key);
    }
  }

  public static add(key: string, data: any) {
    try {
      sessionStorage.setItem(key, data);
    } catch (e) {
      console.log("Erro ao acessar o sessionStorage " + key);
    }
  }

  public static update(key: string, data: any) {
    try {
      sessionStorage.setItem(key, data);
    } catch (e) {
      console.log("Erro ao acessar o sessionStorage " + key);
    }
  }

  public static remove(key: string) {
    try {
      sessionStorage.removeItem(key);
    } catch (e) {
      console.log("Erro ao acessar o sessionStorage " + key);
    }
  }

  public static reset() {
    try {
      sessionStorage.clear();
    } catch (e) {
      console.log("Erro ao acessar o sessionStorage clear");
    }
  }

}
