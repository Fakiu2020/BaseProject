import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import {HttpClientModule} from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import {FormsModule, ReactiveFormsModule} from '@angular/forms';
import { AppComponent } from './app.component';
import { HttpClient } from 'selenium-webdriver/http';
import { NavComponent } from './nav/nav.component';
import { AuthService } from './_services/auth.service';
import { HomeComponent } from './home/home.component';
import { CreateUserComponent, } from './users/create-user/create-user.component';
import { ErrorInterceptorProvider } from './_helpers/error.interceptor';
import { AlertifyService } from './_services/alertify.service';
import { ListUserComponent } from './users/list-user/list-user.component';
import { LoginComponent } from './auth/login/login.component';

import { UserService } from './_services/user.service';

// ngx bootstrap
import { BsDropdownModule, TabsModule, BsDatepickerModule, PaginationComponent, PaginationModule, ButtonsModule } from 'ngx-bootstrap';
import { RouterModule } from '@angular/router';
import { appRoutes } from './routes';
import { ModalModule } from 'ngx-bootstrap';
import { TooltipModule } from 'ngx-bootstrap/tooltip';
import { AccordionModule } from 'ngx-bootstrap/accordion';

// jwt
import { JwtModule } from '@auth0/angular-jwt';


import { NgxGalleryModule } from 'ngx-gallery';
import { FileUploadModule } from 'ng2-file-upload';
import {TimeAgoPipe} from 'time-ago-pipe';
import { SidebarComponent } from './sidebar/sidebar.component';

import { PerfectScrollbarModule } from 'ngx-perfect-scrollbar';
import { PERFECT_SCROLLBAR_CONFIG } from 'ngx-perfect-scrollbar';
import { PerfectScrollbarConfigInterface } from 'ngx-perfect-scrollbar';

// guards
import { AuthGuard } from './_guards/auth.guard';
import { EditUserComponent } from './users/edit-user/edit-user.component';
import { DetailUserResolver } from './_resolvers/detail-user-resolvers';
import { ListUserResolver } from './_resolvers/list-user-resolvers';
import { LoaderService } from './_services/loader.service';
import { LoaderComponent } from './loader/loader.component';
import { LoaderInterceptor } from './_helpers/loader.interceptor';
import { PreventUnsavedChanges } from './_guards/prevent-unsaved-changes.guard';
import { RolesService } from './_services/roles.service';


export function tokenGetter() {
   return localStorage.getItem('token');
 }

const DEFAULT_PERFECT_SCROLLBAR_CONFIG: PerfectScrollbarConfigInterface = {
   suppressScrollX: true
 };

@NgModule({
   declarations: [
      AppComponent,
      NavComponent,
      HomeComponent,
      LoginComponent,
      CreateUserComponent,
      LoaderComponent,
      ListUserComponent,
      EditUserComponent,
      TimeAgoPipe,
      SidebarComponent
   ],
   imports: [
      BrowserModule,
      HttpClientModule,
      FormsModule,
      AppRoutingModule,
      AccordionModule.forRoot(),
      BsDropdownModule.forRoot(),
      TooltipModule.forRoot(),
      ModalModule.forRoot(),
      TabsModule.forRoot(),
      BsDatepickerModule.forRoot(),
      RouterModule.forRoot(appRoutes),
      NgxGalleryModule,
      FileUploadModule,
      PaginationModule.forRoot(),
      ReactiveFormsModule,
      ButtonsModule.forRoot(),
      PerfectScrollbarModule,
      JwtModule.forRoot({
         config: {
           tokenGetter,
           whitelistedDomains: ['localhost:52676'],
           blacklistedRoutes: ['localhost:52676/api/auth']
         }
       })
   ],
   providers: [
      AuthService,
      LoaderService,
      RolesService,
      AuthGuard,
      ErrorInterceptorProvider,
      LoaderInterceptor,
      AlertifyService,
      DetailUserResolver,
      ListUserResolver,
      PreventUnsavedChanges,
      UserService,
      {
         provide: PERFECT_SCROLLBAR_CONFIG,
         useValue: DEFAULT_PERFECT_SCROLLBAR_CONFIG
       }
   ],
   bootstrap: [
      AppComponent
   ]
})
export class AppModule { }
