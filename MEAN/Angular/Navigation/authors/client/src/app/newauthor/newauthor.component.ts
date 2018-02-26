import { Component, OnInit } from '@angular/core';
import { HttpService } from '../http.service';
import { ActivatedRoute, Params, Router } from '@angular/router';


@Component({
  selector: 'app-newauthor',
  templateUrl: './newauthor.component.html',
  styleUrls: ['./newauthor.component.css']
})

export class NewAuthorComponent implements OnInit {
  newAuthor: any;
  errors: any;
    constructor(private _httpService: HttpService, private _router: Router) { }

  ngOnInit() {
    this.newAuthor = {name: ""}
    console.log(this.newAuthor)
 
  }

  createAuthor(newAuthor)
  {
    let new_author = this._httpService.submitNewAuthor(this.newAuthor)
    new_author.subscribe(data => {
      // console.log(data);
      // console.log = data["errors"]["name"]["message"]
      if("errors" in data)
      {
        this.errors = data["errors"]
      }
      else
      {
        this._router.navigateByUrl("/")

      }
      
    })
  }

}
