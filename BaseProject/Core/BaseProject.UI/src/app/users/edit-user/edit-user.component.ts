import { Component, OnInit, HostListener, AfterViewInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { UserService } from 'src/app/_services/user.service';
import { AlertifyService } from 'src/app/_services/alertify.service';
import { User } from 'src/app/models/user';
import { FormGroup, Validators, FormBuilder } from '@angular/forms';
import { RolesService } from 'src/app/_services/roles.service';
import { elementEnd } from '@angular/core/src/render3';

@Component({
  selector: 'app-edit-user',
  templateUrl: './edit-user.component.html',
  styleUrls: ['./edit-user.component.css']
})
export class EditUserComponent implements OnInit, AfterViewInit {
  updateUserForm: FormGroup;
  user: User ;
  roles: any = [];

  constructor(private route: ActivatedRoute, private router: Router, private fb: FormBuilder,
              private userService: UserService, private alertService: AlertifyService,
              private rolesSerice: RolesService) {}

  
 
  ngOnInit() {
    this.route.data.subscribe(data => {
      this.user = (data.user);
      this.createUpdateForm();
     
    });
  }
  ngAfterViewInit(){
    this.getAllRoles(); 
  }


  createUpdateForm() {
    this.updateUserForm = this.fb.group(
      {
        id: [this.user.id, Validators.required],
        email: [this.user.email, [Validators.required, Validators.email]],
        firstName: [this.user.firstName, Validators.required],
        lastName: [this.user.lastName, Validators.required],
        phoneNumber: [this.user.phoneNumber],
        roles: [this.user.roles]
      }
    );
  }
  get f() { return this.updateUserForm.controls; }

  updateUser() {
    if (this.updateUserForm.invalid) { return; }
    this.user = Object.assign({}, this.updateUserForm.value);
    this.user.roles = this.getRolesSelected();
    this.userService.updateUser(this.user).subscribe(next => {
    }, error => {
      this.alertService.error(error);
    }, () => {
      this.alertService.success('Modified Successfully');
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

  getAllRoles(){
    this.rolesSerice.getAllRoles().subscribe( data =>  {
     this.roles = data.roles;
     this.matchRoles();
    }, error => {
      this.alertService.error(error);
    })
  }

  cancel() {
    this.router.navigate(['/users']);
  }

  matchRoles(){
    // tslint:disable-next-line:prefer-for-of
    for (let i = 0; i < this.user.roles.length; i++) {
        // tslint:disable-next-line:prefer-for-of
        for (let j = 0; j < this.roles.length;j++){
           if (this.user.roles[i] === this.roles[j].name){
              this.roles[j].checked = true;
              break;
           }
        }
    }
  }

}
