import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable()
export class HttpService {

  constructor(private _http: HttpClient) {
    // this.getPokemon()
    // this.getAbilityCommonalities()
    this.getAbilityCommonalities2()


  }
  // getPokemon() {
  //   let bulbasaur = this._http.get('https://pokeapi.co/api/v2/pokemon/1/');
  //   console.log("bulbasaur");
  //   // bulbasaur.subscribe(data => console.log("Bulbasaur!", data));
  //   var bulb = bulbasaur.subscribe(function (data) {
  //     console.log(data)
  //     // console.log(data["abilities"])
  //     // console.log(data["abilities"][0].ability.name)````
  //     for (var i = 0; i < data["abilities"].length; i++) {
  //       console.log(`Bulbasaur's abilities are ${data["abilities"][i].ability.name}`)
  //       // var ability = data["abilities"][i].ability.name
  //       return data["abilties"]
  //     }
  //   });
  // }
  // getAbilityCommonalities() {
  //   let all_pokemon = this._http.get('https://pokeapi.co/api/v2/ability/34/');
  //   var ability = all_pokemon.subscribe(function (data) {
  //     console.log(data);
  //     console.log(data["pokemon"].length)
  //   })
  // }
  getAbilityCommonalities2() 
{
    let bulbasaur = this._http.get('https://pokeapi.co/api/v2/pokemon/1/');
    console.log("bulbasaur");
    // bulbasaur.subscribe(data => console.log("Bulbasaur!", data));
    var bulb = bulbasaur.subscribe(data => {
      console.log(data)
      // console.log(data["abilities"])
      // console.log(data["abilities"][0].ability.name)````
      for (var i = 0; i < data["abilities"].length; i++) 
    {
        console.log(`Bulbasaur's abilities are ${data["abilities"][i].ability.name}`)
        var target_url = data["abilities"][i].ability.url;
        console.log(target_url)
        var common_abilities = this._http.get(target_url)
        console.log("working on")
        var ability_call = common_abilities.subscribe(function (data) 
      {
          console.log(data);
          console.log(`There are ${data["pokemon"].length} that share ${data["name"]}` )
        })
    }
    });
  }
}
