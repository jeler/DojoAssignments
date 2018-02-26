import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ActivatedRoute } from '@angular/router';
import { AppComponent } from './app.component';
import { NewAuthorComponent } from './newauthor/newauthor.component';
import { HomeComponent } from './home/home.component';
import {EditAuthorComponent} from './editauthor/editauthor.component'


const routes: Routes = [
  {path: 'edit/:id', component: EditAuthorComponent},
  {path: '', component: HomeComponent},
  {path: 'newauthor', component: NewAuthorComponent},
  {path: "", pathMatch: 'full', redirectTo: '/'},
  {path: "createnewauthor", pathMatch: 'full', redirectTo: '/'},  
  {path: "delete/:id", pathMatch: "full", redirectTo:'/'}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
