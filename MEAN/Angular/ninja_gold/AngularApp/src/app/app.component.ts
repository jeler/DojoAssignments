import { Component, OnInit } from '@angular/core';
import { HttpService } from './http.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title="app";
  gold = 0;
  messages =[];
  // makes tasks list accessible to html
  constructor(private _httpService: HttpService) { }
  ngOnInit() {
  }

  FarmGold() {
    let farm_gold_number = Math.floor(Math.random()*(4) + 2)
    this.gold += farm_gold_number;
    this.messages.push(`You earned ${farm_gold_number} at the farm`)
    console.log("This is this.gold", this.gold);
    console.log("This is farm_gold_number", farm_gold_number);
  }

}