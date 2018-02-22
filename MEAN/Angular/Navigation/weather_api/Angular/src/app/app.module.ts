import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ChicagoComponent } from './chicago/chicago.component';
import { HttpService } from './http.service';
import { HttpClientModule } from '@angular/common/http';
import { SeattleComponent } from './seattle/seattle.component';


@NgModule({
  declarations: [
    AppComponent,
    ChicagoComponent,
    SeattleComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule
  ],
  providers: [HttpService],
  bootstrap: [AppComponent]
})
export class AppModule { }
