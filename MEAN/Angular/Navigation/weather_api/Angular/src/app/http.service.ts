import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';



@Injectable()
export class HttpService {

  constructor(private _http: HttpClient) { }
    Chi_Weather_Data()
    {
      return this._http.get("http://api.openweathermap.org/data/2.5/weather?id=4887398&units=imperial&APPID=99288359196596cf6c11573008ff0d17")
    }
    Seattle_Weather_Data()
    {
      return this._http.get("http://api.openweathermap.org/data/2.5/weather?id=5809844&units=imperial&APPID=99288359196596cf6c11573008ff0d17")
      
    }
}
