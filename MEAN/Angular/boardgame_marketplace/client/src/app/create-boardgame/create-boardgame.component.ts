import { Component, OnInit } from '@angular/core';
import { HttpService } from '../http.service';
import { ActivatedRoute, Params, Router } from '@angular/router';

@Component({
  selector: 'app-create-boardgame',
  templateUrl: './create-boardgame.component.html',
  styleUrls: ['./create-boardgame.component.css']
})
export class CreateBoardgameComponent implements OnInit {

  user_info: any;
  BoardGameCreate: any;
  
  constructor(private _httpService: HttpService, private _router: Router) { }
  
  ngOnInit() {
    this.checkSessionUserComponent()
    this.BoardGameCreate= {
        title: "",
        description:"",
        price: 0,
        location: "",
        condition: ""
      }
  }

  checkSessionUserComponent()
  {
    var session_data = this._httpService.checkSessionUser();
    session_data.subscribe(data => {
      console.log(data, "this is data!")
      console.log(data["session"])
      if(data["session"]== false)
      {
        console.log("got here!")
        this._router.navigateByUrl("/")                  
      }
      else 
      {
        console.log("got here to give user data!")
        this.user_info = data["user"]
        console.log(this.user_info)
      }
    })
  }
  createNewBoardgame(BoardGameCreate)
  {
    let newGame = this._httpService.createBoardGame(this.BoardGameCreate)
    .subscribe(data => {
      console.log(data, "this is bg data from form!")
    })
    console.log(this.BoardGameCreate)
    this._router.navigateByUrl("/dashboard")           
  }

}
