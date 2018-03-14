import { Component, OnInit } from '@angular/core';
import { HttpService } from '../http.service';
import { ActivatedRoute, Params, Router } from '@angular/router';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  authors = [];
  constructor(private _httpService: HttpService, private _router: Router) {
    
   }

  ngOnInit() {
    this.showAllAuthors();
  }
  showAllAuthors() {
    let observable = this._httpService.getAuthors();
    observable.subscribe(data => {
      console.log("Got our authors!", data)
      // In this example, the array of tasks is assigned to the key 'tasks' in the data object. 
      // This may be different for you, depending on how you set up your Task API.
      this.authors = data['authors'];
      console.log(this.authors)
      console.log(data['authors'][0]['name'])
      console.log(data['authors'][0]['_id'])
    });
  }
  deleteSpecificAuthor(id) {
    console.log("got to line 32 in component!", id)
    let observable = this._httpService.deleteAuthor(id);
    observable.subscribe(data => {
      console.log("data from delete in component!", data);
      // this._router.navigateByUrl("/")
      this.showAllAuthors();
    })
  }
}
