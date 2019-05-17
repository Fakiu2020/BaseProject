import { Injectable } from '@angular/core';
import { MatDialog } from '@angular/material';
import { ModalConfirmComponent } from '../_helpers/modal-confirm/modal-confirm.component';

@Injectable({
  providedIn: 'root'
})
export class ModalService {

  constructor(private dialog: MatDialog) { }

  openConfirmDialog(msg){
    return this.dialog.open(ModalConfirmComponent,{
       width: '390px',
       panelClass: 'confirm-dialog-container',
       disableClose: true,
       position: {  },
       data :{
         message : msg
       }
     });
   }
}
