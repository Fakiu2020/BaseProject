import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import {HttpClientModule} from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import {FormsModule, ReactiveFormsModule} from '@angular/forms';
import { AppComponent } from './app.component';
import { SidebarComponent } from './sidebar/sidebar.component';
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


import { BrowserAnimationsModule } from '@angular/platform-browser/animations';



import {MatToolbarModule, MatExpansionModule, MatIconModule,
         MatButtonModule, MatMenuModule, MatCardModule,
         MatFormFieldModule, MatInputModule, MatTableModule,
         MatPaginatorModule, MatSortModule, MatProgressSpinnerModule, MatRadioModule,
         MatCheckboxModule, MatDialogModule, MatGridListModule, 
         MatSidenavModule, MatListModule,   }
from '@angular/material';


import { ModalConfirmComponent } from './_helpers/modal-confirm/modal-confirm.component';
import { LayoutModule } from '@angular/cdk/layout';
import { NavbarComponent } from './navbar/navbar.component';



export function tokenGetter() {
   return localStorage.getItem('token');
 }

const DEFAULT_PERFECT_SCROLLBAR_CONFIG: PerfectScrollbarConfigInterface = {
   suppressScrollX: true
 };

@NgModule({
   declarations: [
      AppComponent,
      SidebarComponent,
      HomeComponent,
      LoginComponent,
      CreateUserComponent,
      LoaderComponent,
      ListUserComponent,
      EditUserComponent,
      TimeAgoPipe,
      ModalConfirmComponent,
      NavbarComponent
   ],
   imports: [
      BrowserModule,
      HttpClientModule,
      FormsModule,
      AppRoutingModule,
      
      
      MatSortModule,
      MatGridListModule,
      MatRadioModule,
      MatDialogModule,
      MatCheckboxModule,
      MatProgressSpinnerModule,
      MatPaginatorModule,
      MatTableModule,
      MatExpansionModule,
      MatIconModule,
      MatFormFieldModule,
      MatCardModule,
      MatMenuModule,
      MatToolbarModule,
      MatIconModule,
      MatButtonModule,
      MatInputModule,

  
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
       }),
      BrowserAnimationsModule,
      LayoutModule,
      MatSidenavModule,
      MatListModule,
     
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
   entryComponents:[ListUserComponent,ModalConfirmComponent],
   bootstrap: [
      AppComponent
   ]
})
export class AppModule { }
