import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ChicagoComponent } from './chicago/chicago.component'
import { SeattleComponent } from './seattle/seattle.component'




const routes: Routes = [
  { path: 'chicago', component: ChicagoComponent},
  { path: 'seattle', component: SeattleComponent},
  { path: '', pathMatch: 'full', redirectTo: '/chicago'}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
