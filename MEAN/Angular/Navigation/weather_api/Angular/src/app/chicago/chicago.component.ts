import { Component, OnInit } from '@angular/core';
import { HttpService } from '../http.service';


@Component({
  selector: 'app-chicago',
  templateUrl: './chicago.component.html',
  styleUrls: ['./chicago.component.css']
})
export class ChicagoComponent implements OnInit {

  chicago_picture: string;
  constructor(private _httpService: HttpService) {
    this.chicago_picture = '../assets/images/chicago-illinois-skyline-skyscrapers-161963.jpeg'
   }
  weather_data: any;
  weather_array = [];

  ngOnInit() {
    this.getChicagoWeather()

  }

  getChicagoWeather() {
    let chi_weather = this._httpService.Chi_Weather_Data();
    chi_weather.subscribe(data => {
      console.log("This is data", data)
      console.log(data["main"]["temp_min"]);
      this.weather_data = data["main"];
      for (var info in data["main"])
      {
        console.log(data["main"][info])
        this.weather_array.push(data["main"][info])
      }
      console.log(this.weather_array)
    })

  }

}