import { Component, OnInit } from '@angular/core';
import { HttpService } from '../http.service';
import { ActivatedRoute, Params, Router } from '@angular/router';


@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  constructor(private _httpService: HttpService, private _router: Router) { }
  UserReg: any;
  UserLog: any;
  // errors: any;
  RegError;
  LogError;
  PwError;
  Lockout;
  random: any;

  ngOnInit()
  {
    this.UserReg = 
    {
      email: "",
      first_name: "",
      last_name: "",
      password: "",
      password_confirm:"",
    }
    this.UserLog = 
    {
      email: "",
      password: ""
    }
    this.getrandomGame();
  }
    onSubmit(UserReg)
    {
      let newUser = this._httpService.createNewUser(this.UserReg);
      newUser.subscribe(data => {
        console.log(data,"Got user!")
        // console.log(data['errors']['birthday']['message'])
        // this.errors = data["errors"];
        if(data["err"])
        {
          // this.errors = data["errors"]
          this.RegError = data['err'];
          this._router.navigateByUrl("/")
        }
        else{
          this._router.navigateByUrl("/dashboard")
        }
      });
    }
    onLogin(UserLog)
    {
      let User = this._httpService.loginUser(this.UserLog);
      User.subscribe(data => {
        console.log(data);
        if(data["err"] || data["pw_error"] || data["lockout"])
        {
          this.LogError= data["err"]
          this.PwError = data["pw_error"]
          
            if(data["lockout"] === true)
            {
              
              this.Lockout = data["lockout"];
              console.log(this.Lockout)
              this._router.navigateByUrl("/")          
            }
          
        }
        else
        {
          this._router.navigateByUrl("/dashboard")          
        }
      })
    }

    getrandomGame()
    {
      let random = this._httpService.randomGame()
      random.subscribe(data => {
        console.log("this is data", data)
        this.random = data["result"]
        console.log(this.random);
      })
    }

  }