import { Injectable } from '@angular/core';
import { throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { Http } from '@angular/http';

@Injectable({
  providedIn: 'root'
})
export class ProductService {

  constructor(private client: Http) { }

  async getAll() {
    try {
        const res: any = await this.client.get(`/api/Product/GetAll`).toPromise();
        return res.json();
    }
    catch (e) {
        console.log(e);
    }
  }

  async add(model: any) {
    try {
      const res: any = await this.client.post(`/api/Product/Add`, model).toPromise();
      if (res) {
          return true;
      }
      return false;
    }
    catch (e) {
      console.log(e);
    }
  } 

  async update(model: any) {
    try {
      const res: any = await this.client.post(`/api/Product/Update`, model).toPromise();
      if (res) {
          return true;
      }
      return false;
    }
    catch (e) {
      console.log(e);
    }
  }

  async delete(model: any) {
    try {
      const res: any = await this.client.post(`/api/Product/Delete`, model).toPromise();
      if (res) {
          return true;
      }
      return false;
    }
    catch (e) {
      console.log(e);
    }
  }

  async getById(model: any) {
    const res: any = await this.client.post(`/api/Product/GetById`, model).pipe(
        catchError(this.handleError)
    ).toPromise();
    return res.json();
  }

  async filter(model: any) {
    const res: any = await this.client.post(`/api/Product/Filter`, model).pipe(
        catchError(this.handleError)
    ).toPromise();
    return res.json();
}

  handleError(error) {
    return throwError(error.json());
  }
}
