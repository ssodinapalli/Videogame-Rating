/**
 * importing npm required npm modules
 * importing npm required ng modules
 * importing the necessary components for Routing
 *
 */

import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AboutComponent } from './components/about/about.component';
import { BottombarComponent } from './components/bottombar/bottombar.component';
import { ForgotPasswordComponent } from './components/forgot-password/forgot-password.component';
import { GamedetailsComponent } from './components/gamedetails/gamedetails.component';
import { HomeComponent } from './components/home/home.component';
import { LoginComponent } from './components/login/login.component';
import { MainpageComponent } from './components/mainpage/mainpage.component';
import { ReviewsComponent } from './components/reviews/reviews.component';
import { SignupComponent } from './components/signup/signup.component';
import { GamesComponent } from './games/games.component';

const routes: Routes = [
  { path: '', component: HomeComponent },
  {
    path: 'Signup',
    component: SignupComponent,
    data: { title: 'Signup' },
  },

  {
    path: 'Login',
    component: LoginComponent,
    data: { title: 'Login' },
  },
  {
    path: 'Games',
    component: GamesComponent,
    data: { title: 'List of Games' },
  },
  { path: 'About', component: AboutComponent },
  { path: 'Forgotpassword', component: ForgotPasswordComponent },
  { path: 'Mainpage', component: MainpageComponent },
  { path: 'Gamedetails', component: GamedetailsComponent },
  { path:'Reviews',component:ReviewsComponent},
  { path: 'bottombar',component:BottombarComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
