import { Component, OnInit } from '@angular/core';
import { AuthService } from './_services/auth.service';
import { NgxSpinnerService } from 'ngx-spinner';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'DattingApp-SPA';

  constructor(private authService: AuthService) {}

  ngOnInit() {    
    this.authService.initToken();
  }

}
