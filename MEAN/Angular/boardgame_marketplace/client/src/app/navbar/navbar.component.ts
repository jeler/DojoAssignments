import { Component, OnInit } from '@angular/core';
import { HttpService } from '../http.service';


@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent implements OnInit {

  constructor(private _httpService: HttpService) { }

  ngOnInit() {
  }

  getUserInfo()
  {
    // console.log(req.session._id);
  }
}
