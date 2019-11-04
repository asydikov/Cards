import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { CardComponent } from './card/card.component';
import { NoteComponent } from './note/note.component';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { AuthGuard } from './_helpers/auth-guard';

const routes: Routes = [
  { path: '', redirectTo: '/cards', pathMatch: 'full' },
  { path: 'cards', component: CardComponent, canActivate: [AuthGuard] },
  { path: 'notes', component: NoteComponent, canActivate: [AuthGuard] },
  { path: 'notes/:id', component: NoteComponent, canActivate: [AuthGuard] },
  { path: 'login', component: LoginComponent },
  { path: 'regirstration', component: RegisterComponent },
  { path: '**', component: CardComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
