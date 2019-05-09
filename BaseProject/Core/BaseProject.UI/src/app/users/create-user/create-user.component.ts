import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { AuthService } from '../../_services/auth.service';

import { FormGroup, Validators, FormBuilder } from '@angular/forms';

import { Router } from '@angular/router';
import { AlertifyService } from 'src/app/_services/alertify.service';
import { MustMatch } from 'src/app/_helpers/must-match';


@Component({
  selector: 'app-create-user',
  templateUrl: './create-user.component.html',
  styleUrls: ['./create-user.component.css']
})
export class CreateUserComponent implements OnInit {
  
  userRegister: any = {};
  createUserForm: FormGroup;

  constructor(private authService: AuthService,  private router: Router, private alertService: AlertifyService, private fb: FormBuilder) { }

  ngOnInit() {
     this.createRegisterForm();
  }

  createRegisterForm() {
    this.createUserForm = this.fb.group(
        {
        firstName: ['', Validators.required],
        lastName: ['', Validators.required],
        email: ['',  [Validators.required, Validators.email]],
        confirmEmail: [''],
        password: ['', [Validators.required, Validators.minLength(8),Validators.maxLength(10)] ],
        confirmPassword: ['']
      },
      {
        validator: [ MustMatch('password', 'confirmPassword'), MustMatch('email', 'confirmEmail')  ]
      }
    );
  }

  get f() { return this.createUserForm.controls; }


  createUser() {
     if (this.createUserForm.invalid) {return;}

     this.userRegister = Object.assign({}, this.createUserForm.value);
     this.authService.register(this.userRegister).subscribe(() => {
        this.alertService.success('Registration successful');        
      }, error => {
        this.alertService.error(error);
      }, () => {
        // this.authService.login(this.userRegister).subscribe(() => {
          this.router.navigate(['/users']);
        // });
      });
  }

  cancel() {
    this.router.navigate(['/users']);
  }

}
