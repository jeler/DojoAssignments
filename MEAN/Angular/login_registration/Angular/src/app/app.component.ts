import { Component, OnInit } from '@angular/core';
import { HttpService } from './http.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  UserReg: any;
  constructor(private _httpService: HttpService) {}
  errors: any;
  ngOnInit()
  {
    this.UserReg = 
    {
      email: "",
      first_name: "",
      last_name: "",
      password: "",
      password_confirm:"",
      birthday: ""
    }
  }
    onSubmit(UserReg)
    {
      let newUser = this._httpService.createNewUser(this.UserReg);
      newUser.subscribe(data => {
        console.log(data,"Got user!")
        // console.log(data['errors']['birthday']['message'])
        this.errors = data["errors"];
      });
      console.log("This is userreg from component!", this.UserReg);

    }
  }
