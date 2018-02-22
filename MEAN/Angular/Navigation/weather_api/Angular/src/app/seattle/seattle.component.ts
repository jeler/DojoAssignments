import { Component, OnInit } from '@angular/core';
import { HttpService } from '../http.service';


@Component({
  selector: 'app-seattle',
  templateUrl: './seattle.component.html',
  styleUrls: ['./seattle.component.css']
})
export class SeattleComponent implements OnInit {

weather_data: any;
seattle_picture: string;

  constructor(private _httpService: HttpService) { 
    this.seattle_picture = '../assets/images/seattle.jpeg'
  }

  ngOnInit() {
    this.Seattle_Received_Data();
  }
  Seattle_Received_Data()
  {
    let seattle_weather = this._httpService.Seattle_Weather_Data();
    seattle_weather.subscribe(data => {
      console.log("This is data!",data)
      this.weather_data = data["main"]
    }
    )
  }
}
