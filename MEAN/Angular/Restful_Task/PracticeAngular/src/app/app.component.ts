import { Component, OnInit } from '@angular/core';
import { HttpService } from './http.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  tasks = [];
  // specific_task = [];
  // makes tasks list accessible to html
  newTask: any;
  
  constructor(private _httpService: HttpService) { }
  // ngOnInit will run when the component is initialized, after the constructor method.
  ngOnInit() {
    this.getTasksFromService();
  }
  // below code will not wait for button click and show tasks on page
  getTasksFromService(){
    let observable = this._httpService.getTasks();
    observable.subscribe(data => {
       console.log("Got our tasks!", data)
       // In this example, the array of tasks is assigned to the key 'tasks' in the data object. 
       // This may be different for you, depending on how you set up your Task API.
       this.tasks = data['tasks'];       
    });
  }
  getTasksFromClick() {
    let observable = this._httpService.onButtonClick();
    // onButtonClick() from service - returns all tasks
    observable.subscribe(data => {
      console.log("Got our tasks!", data)
      this.tasks = data['tasks'];
      console.log(this.tasks);

    });
  }

}