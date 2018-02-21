import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable()
export class HttpService {

  constructor(private _http: HttpClient) {
  

   }
   createNewUser(UserReg)
   {
     console.log("this is UserReg from serivce", UserReg);
     return this._http.post('/register_user', UserReg)
   }
}
