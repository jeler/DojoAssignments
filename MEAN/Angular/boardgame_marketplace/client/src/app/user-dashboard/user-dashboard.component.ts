import { Component, OnInit } from '@angular/core';
import { FilterPipe }from '../filter.pipe';
import { HttpService } from '../http.service';

@Component({
  selector: 'app-user-dashboard',
  templateUrl: './user-dashboard.component.html',
  styleUrls: ['./user-dashboard.component.css']
})
export class UserDashboardComponent implements OnInit {

  constructor(private _httpService: HttpService) { }

  session_user: any;

  characters = [
    'Finn the human',
    'Jake the dog',
    'Princess bubblegum',
    'Lumpy Space Princess',
    'Beemo1',
    'Beemo2'
  ]

  ngOnInit() 
  {
    // let checkUser = this._httpService.checkSessionUser(this.session_user);
    //   checkUser.subscribe(data => {
    //     console.log(data);
    //   })
  }

}
