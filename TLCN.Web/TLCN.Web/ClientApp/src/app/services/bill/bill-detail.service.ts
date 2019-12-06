import { Injectable } from '@angular/core';
import { HttpClient } from '../common/http-client';
import { throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class BillDetailService {

  constructor(
    private http: HttpClient
    
  ) { }

  async getAll() {
    const res: any = await this.http.get(`/api/BillDetail/GetAll`).pipe(
      catchError(this.handleError)
    ).toPromise();
    return res.json();
  }

  async add(model: any) {
    try {
      const res: any = await this.http.post(`/api/BillDetail/Add`, model).toPromise();
      if (res) {
          return true;
      }
      return false;
    }
    catch (e) {
      console.log(e);
    }
  } 

  async GetProductForClient(model: any) {
    const res: any = await this.http.post(`/api/BillDetail/GetProductForClient`, model).pipe(
        catchError(this.handleError)
    ).toPromise();
    return res.json();
  }


  handleError(error) {
    return throwError(error.json());
  }

}
