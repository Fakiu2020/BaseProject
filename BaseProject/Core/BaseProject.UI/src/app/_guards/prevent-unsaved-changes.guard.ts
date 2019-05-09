import {Injectable} from '@angular/core';
import { CanDeactivate } from '@angular/router';
import { AlertifyService } from '../_services/alertify.service';
import { EditUserComponent } from '../users/edit-user/edit-user.component';

@Injectable()
export class PreventUnsavedChanges implements CanDeactivate<EditUserComponent> {
    /**
     *
     */
    constructor( private alertify: AlertifyService) {
    }

    canDeactivate(component: EditUserComponent) {
        if (component.updateUserForm.dirty){
            return confirm('Are you sure you want to continue?  Any unsaved changes will be lost');
        }
        return true;
    }
}