import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { AuthService } from '../../_services/auth.service';

import { FormGroup, Validators, FormBuilder } from '@angular/forms';

import { Router } from '@angular/router';
import { AlertifyService } from 'src/app/_services/alertify.service';
import { MustMatch } from 'src/app/_helpers/must-match';
import { RolesService } from 'src/app/_services/roles.service';
import { User } from 'src/app/models/user';


@Component({
  selector: 'app-create-user',
  templateUrl: './create-user.component.html',
  styleUrls: ['./create-user.component.css']
})
export class CreateUserComponent implements OnInit {
  roles: any = [];
  rolesSelected: any = [];

  userRegister: User;
  createUserForm: FormGroup;

  constructor(private authService: AuthService,
              private router: Router,
              private rolesService: RolesService,
              private alertService: AlertifyService, private fb: FormBuilder) {this.userRegister=new User() }

  ngOnInit() {
    
    console.log(this.userRegister);
     this.createRegisterForm();
     this.getAllRoles();
  }

  createRegisterForm() {
    this.createUserForm = this.fb.group(
        {
        firstName: ['', Validators.required],
        lastName: ['', Validators.required],
        email: ['',  [Validators.required, Validators.email]],
        confirmEmail: [''],
        password: ['', [Validators.required, Validators.minLength(8), Validators.maxLength(10)] ],
        confirmPassword: [''],
        roles: [this.userRegister.roles]
      },
      {
        validator: [ MustMatch('password', 'confirmPassword'), MustMatch('email', 'confirmEmail')  ]
      }
    );
  }

  get f() { return this.createUserForm.controls; }


  save() {
  

     if (this.createUserForm.invalid) {return; }
     
     this.userRegister = Object.assign({}, this.createUserForm.value);
     this.userRegister.roles=this.getRolesSelected();
     this.authService.register(this.userRegister).subscribe(() => {
        this.alertService.success('Registration successful');
      }, error => {
        this.alertService.error(error);
      }, () => {
          this.router.navigate(['/users']);
      });
  }

  cancel() {
    this.router.navigate(['/users']);
  }

  getAllRoles() {
    this.rolesService.getAllRoles().subscribe( data => {
     this.roles = data.roles;
    }, error => {
      this.alertService.error(error);
    });
  }

  getRolesSelected(){
    const result = [];
    this.roles.forEach((value, key: string) => {
        if (value.checked === true){
          result.push(value.name);
        }
    });
    return result;
  }

}
