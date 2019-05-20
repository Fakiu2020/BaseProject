import { Component, OnInit } from '@angular/core';
import { AuthService } from '../_services/auth.service';
import { AlertifyService } from '../_services/alertify.service'; 
import { Router } from '@angular/router';



@Component({
  selector: 'app-sidebar',
  templateUrl: './sidebar.component.html',
  styleUrls: ['./sidebar.component.css']
})

export class SidebarComponent implements OnInit {
 
  userLogin: any = {};

  constructor(public authService: AuthService, private alertService: AlertifyService,
              private router: Router) { }

  ngOnInit() {
  }
  
  login() {
    this.authService.login(this.userLogin).subscribe(next => {
      this.alertService.success('Logged in successfully');
    }, error => {
      this.alertService.error(error);
    }, () => {
      this.router.navigate(['/members']);
    });
  }

  loggedIn() {
    return this.authService.loggedIn();
  }

  logout() {
    localStorage.removeItem('token');
    localStorage.removeItem('userEmail');
    this.authService.decodedToken = null;
    this.authService.currentUser = null;
    this.userLogin = {};
    this.router.navigate(['/login']);
  }

}
