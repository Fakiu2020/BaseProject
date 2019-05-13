
import { Component, OnInit, TemplateRef } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { UserService } from 'src/app/_services/user.service';
import { AlertifyService } from 'src/app/_services/alertify.service';
import { Pagination } from 'src/app/models/pagination';
import { BsModalRef, BsModalService } from 'ngx-bootstrap';
import { User } from 'src/app/models/user';

@Component({
  selector: 'app-user-list',
  templateUrl: './list-user.component.html',
  styleUrls: ['./list-user.component.css']
})
export class ListUserComponent implements OnInit {
  users: any [];
  isLoading = false;

  pagination = new Pagination();
  userToDelete: User;
  config = {
    animated: true
  };

  modalRef: BsModalRef;
  constructor(private modalService: BsModalService,
              private route: ActivatedRoute,
              private router: Router,
              private userService: UserService,
              private alertify: AlertifyService) { }

  ngOnInit() {
    this.route.data.subscribe(data => {
      this.users = data.users.result; 
      this.pagination = data.users.pagination;
    });
  }


  createUser() {
    this.router.navigate(['/user/create']);
  }

  getAll() {
    this.isLoading = true;
    this.userService.getUsers(this.pagination).subscribe((res) => {
      this.users = res.result;
      this.isLoading = false;
      this.pagination = res.pagination;
    }, error => {
      this.isLoading = false;
      this.alertify.error(error);
    });
  }

  pageChanged(event: any): void {
    this.pagination.pageNumber = event.page;
    this.getAll();
  }

  goToEdit(userSelected) {
      this.router.navigate(['/user/edit', userSelected.id]);
  }


  removeConfirm(user,template: TemplateRef<any>){
    this.userToDelete=user;
    this.modalRef = this.modalService.show(template, this.config);
    
  }

  confirm(): void {    
    this.userService.deleteUser(this.userToDelete.id).subscribe(()=>{
      this.getAll();
      this.modalRef.hide();
      this.alertify.success("User deleted successfully");
    }, error => {
      this.alertify.error(error);
    });    
  }
 
  decline(): void {    
    this.modalRef.hide();
  }
}
