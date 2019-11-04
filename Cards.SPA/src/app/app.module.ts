import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule, FormBuilder } from '@angular/forms';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { CardComponent } from './card/card.component';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { NavComponent } from './nav/nav.component';
import { CategoryComponent } from './dictionaries/category/category.component';
import { ModeComponent } from './dictionaries/mode/mode.component';
import { RepeatRateComponent } from './dictionaries/repeat-rate/repeat-rate.component';
import { RouterModule, Routes } from '@angular/router';
import { NoteComponent } from './note/note.component';
import { JwtInterceptor } from './_helpers/jwt-interecptor';
import { ErrorInterceptor } from './_helpers/error-interceptor';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';

@NgModule({
  declarations: [
    AppComponent,
    CardComponent,
    NavComponent,
    CategoryComponent,
    NoteComponent,
    ModeComponent,
    RepeatRateComponent,
    LoginComponent,
    RegisterComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    ReactiveFormsModule,
    FormsModule,
  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true },
    { provide: HTTP_INTERCEPTORS, useClass: ErrorInterceptor, multi: true },
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
