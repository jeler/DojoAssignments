import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable()
export class HttpService {

  constructor(private _http: HttpClient) {
    this.getTasks();
    this.onButtonClick();
   }
   getTasks()
   {
     return this._http.get('/tasks');
   }

   onButtonClick() { 
     return this._http.get('/tasks');
}

}
