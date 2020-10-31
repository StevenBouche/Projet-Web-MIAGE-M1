import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ForumComponent } from './forum.component';
import { AuthGuardService } from './auth/auth-guard.service';

import { AuthComponent } from './auth/auth.component';

const routes: Routes = [
  { path: '', component: ForumComponent, canActivate: [AuthGuardService] },
  { path: 'auth', component: AuthComponent }
];

@NgModule({
  declarations: [],
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class ForumRoutingModule { }
