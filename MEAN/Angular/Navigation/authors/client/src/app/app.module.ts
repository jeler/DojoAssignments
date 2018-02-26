import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HttpService } from './http.service';
import { HttpClientModule } from '@angular/common/http';
import { NewAuthorComponent } from './newauthor/newauthor.component';
import { HomeComponent } from './home/home.component';
import { FormsModule } from '@angular/forms';
import { EditAuthorComponent } from './editauthor/editauthor.component';


@NgModule({
  declarations: [
    AppComponent,
    NewAuthorComponent,
    HomeComponent,
    EditAuthorComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule
  ],
  providers: [HttpService],
  bootstrap: [AppComponent]
})
export class AppModule { }
