import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable()
export class HttpService {

  constructor(private _http: HttpClient) { 

    var info = this.getAuthors();

  }
  getAuthors()
  {
    return this._http.get('/authors');
  }
  submitNewAuthor(newAuthor)
  {
    console.log(newAuthor)
    return this._http.post('/createnewauthor', newAuthor)
  }
  getAuthorInfo(id)
  {
    console.log("got here!", id)
    return this._http.get('/authors/' + id)
  }
  updateAuthorInfo(editAuthor)
  {
    console.log("got here in updateAuthorInfo!", editAuthor)
    return this._http.post('/updateuser', editAuthor)
  }
  deleteAuthor(id)
  {
    console.log("in service")
    return this._http.get('/delete/' + id)
  }
}
