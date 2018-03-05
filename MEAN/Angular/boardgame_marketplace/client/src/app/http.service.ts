import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable()
export class HttpService {

  constructor(private _http: HttpClient) { }

  createNewUser(UserReg)
  {
    console.log(UserReg)
    return this._http.post('createnewuser', UserReg)
  }

  loginUser(UserLog)
  {
    console.log(UserLog)
    return this._http.post('loginuser', UserLog)
    
  }
  checkSessionUser()
  {
    console.log("in session check service!")
    return this._http.get('check_session')
  }
  userLogout()
  {
    console.log("here from nav bar!")
    return this._http.get('logout')
  }
}
