import { Injectable } from '@angular/core';
import Swal from 'sweetalert2';

@Injectable({
  providedIn: 'root'
})
export class SweetAlertService {
  result:any;

  confirm(title: string, text: string, confirmButtonText?: string, cancelButtonText?: string) {
    return Swal.fire({
      title,
      text,
      icon: 'warning',
      showCancelButton: true,
      confirmButtonText: confirmButtonText || 'Yes',
      cancelButtonText: cancelButtonText || 'No'
    }).then((result) => {  
      if (result.value) {  
        return true;
      } else if (result.dismiss === Swal.DismissReason.cancel) {
        return false;
      }
      return true;
    });
  }

  success(title: string, text: string) {
    return Swal.fire({
      title,
      text,
      icon: 'success',
      timer: 3000,
      timerProgressBar: true
    });
  }

  error(title: string, text: string) {
    return Swal.fire({
      title,
      text,
      icon: 'error',
      timer: 3000,
      timerProgressBar: true
    });
  }

}
