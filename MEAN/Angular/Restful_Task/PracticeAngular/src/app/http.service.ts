import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable()
export class HttpService {

  constructor(private _http: HttpClient) {
    this.getTasks();
    this.getTaskById();
   }
   getTasks()
   {
     let tempObservable = this._http.get('/tasks');
     tempObservable.subscribe(data => console.log("Got our tasks!", data));
   }
   getTaskById()
   {
     let task_data_by_id = this._http.get('/tasks/')
     task_data_by_id.subscribe(data => console.log("Individual task data!", data));
   }

}
