import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { UserDashboardComponent } from './user-dashboard/user-dashboard.component';
import { CreateBoardgameComponent } from './create-boardgame/create-boardgame.component';

 
const routes: Routes = [
  {path: '', component: HomeComponent},
  {path: "createboardgame", component: CreateBoardgameComponent},
  {path: "dashboard", component: UserDashboardComponent},
  {path: "", pathMatch: 'full', redirectTo: '/'}

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }


