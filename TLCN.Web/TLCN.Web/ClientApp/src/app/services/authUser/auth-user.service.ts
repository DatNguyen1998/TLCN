import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import { throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class AuthUserService {

  constructor(private client: Http) { }

  async getAll() {
    try {
        const res: any = await this.client.get(`/api/AuthUser/GetAll`).toPromise();
        return res.json();
    }
    catch (e) {
        console.log(e);
    }
  }

  async add(model: any) {
    try {
      const res: any = await this.client.post(`/api/AuthUser/Add`, model).toPromise();
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
            const res: any = await this.client.post(`/api/AuthUser/Update`, model).toPromise();
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
            const res: any = await this.client.post(`/api/AuthUser/Delete`, model).toPromise();
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
    const res: any = await this.client.post(`/api/AuthUser/GetById`, model).pipe(
        catchError(this.handleError)
    ).toPromise();
    return res.json();
  }

  async filter(model: any) {
    const res: any = await this.client.post(`/api/AuthUser/Filter`, model).pipe(
        catchError(this.handleError)
    ).toPromise();
    return res.json();
}


  handleError(error) {
    return throwError(error.json());
  }
}
