import { Component, OnInit } from '@angular/core';
import { HttpService } from '../http.service';
import { ActivatedRoute, Params, Router } from '@angular/router';


@Component({
  selector: 'app-editauthor',
  templateUrl: './editauthor.component.html',
  styleUrls: ['./editauthor.component.css']
})
export class EditAuthorComponent implements OnInit {
  id: string;
  author2 = { id: "", name: "" };
  editAuthor: any;
  errors: any;
  // this.editAuthor= {name: ""};

  constructor(
    private _route: ActivatedRoute,
    private _router: Router,
    private _httpService: HttpService
  ) { }

  ngOnInit() {
    this._route.params.subscribe(params => {
      console.log("this is params!", params)
      this.id = params['id']
      this.RetrieveData(this.id);
    })

  }
  RetrieveData(id) {
    let new_author = this._httpService.getAuthorInfo(this.id)
    new_author.subscribe(data => {
      console.log("this is data from edit!", data)
      console.log(data["author"]["name"])
      this.author2 = data["author"]
      this.editAuthor = this.author2;
    });
  }
  EditAuthorInfo(editAuthor) {
    let edit_author = this._httpService.updateAuthorInfo(this.editAuthor);
    edit_author.subscribe(data => {
      console.log(data, "This is data!")
      console.log(this.editAuthor);
      if("errors" in data)
      {
        this.errors = data["errors"]
      }
      else{
        this._router.navigateByUrl('/')
      }
    })
  }
}
