import { Component, OnInit, HostListener } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { UserService } from 'src/app/_services/user.service';
import { AlertifyService } from 'src/app/_services/alertify.service';
import { User } from 'src/app/models/user';
import { FormGroup, Validators, FormBuilder } from '@angular/forms';

@Component({
  selector: 'app-edit-user',
  templateUrl: './edit-user.component.html',
  styleUrls: ['./edit-user.component.css']
})
export class EditUserComponent implements OnInit {
  updateUserForm: FormGroup;
  user: any = {};
  
  isUser: number;
  constructor(private route: ActivatedRoute, private router: Router, private fb: FormBuilder,
    private userService: UserService, private alertService: AlertifyService) { }

  
  
  ngOnInit() {
    this.route.data.subscribe(data => {
      this.user = (data.user);  
      this.createUpdateForm();
    });
  }


  createUpdateForm() {
    this.updateUserForm = this.fb.group(
      {
        id: [this.user.id, Validators.required],
        email: [this.user.email, [Validators.required, Validators.email]],
        firstName: [this.user.firstName, Validators.required],
        lastName: [this.user.lastName, Validators.required],
        phoneNumber: [this.user.phoneNumber],
      }
    );
  }
  get f() { return this.updateUserForm.controls; }

  updateUser() {
    if (this.updateUserForm.invalid) { return; }
    this.user = Object.assign({}, this.updateUserForm.value);

    this.userService.updateUser(this.user).subscribe(next => {
    }, error => {
      this.alertService.error(error);
    }, () => {
      // this.router.navigate(['/users']);
      this.alertService.success('Modified Successfully');
    });
  }

  cancel() {
    this.router.navigate(['/users']);
  }

}
