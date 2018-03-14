import { Component, OnInit } from '@angular/core';
import { FilterPipe }from '../filter.pipe';
import { HttpService } from '../http.service';
import { ActivatedRoute, Params, Router } from '@angular/router';

@Component({
  selector: 'app-allboardgames',
  templateUrl: './allboardgames.component.html',
  styleUrls: ['./allboardgames.component.css']
})
export class AllboardgamesComponent implements OnInit {

  constructor(private _httpService: HttpService, private _router: Router) { }

  user_info: any;
  allGames: any;
  session: any;
  
  ngOnInit() {
    this.getGames();    
    this.checkSessionUserComponent()
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
        this.session = data["session"]
        console.log(this.user_info)
      }
    })
  }

  getGames()
  {
    let allGames = this._httpService.getAllGames().subscribe(data => {
      console.log(data, "all the data!")
      this.allGames = data["games"];
      console.log(this.allGames)
    })
  }

  deleteGame(id)
  {
    let deleteGame = this._httpService.deleteGame(id).subscribe(data => {
      console.log(data)
      this.getGames();                 
      
    })
  }
}
