import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import { catchError } from 'rxjs/operators';
import { throwError } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class PromotionService {

  constructor(private client: Http) { }

  async getAll() {
    try {
        const res: any = await this.client.get(`/api/Promotion/GetAll`).toPromise();
        return res.json();
    }
    catch (e) {
        console.log(e);
    }
  }

    async add(model: any) {
        try {
            const res: any = await this.client.post(`/api/Promotion/Add`, model).toPromise();
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
            const res: any = await this.client.post(`/api/Promotion/Update`, model).toPromise();
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
            const res: any = await this.client.post(`/api/Promotion/Delete`, model).toPromise();
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
        const res: any = await this.client.post(`/api/Promotion/GetById`, model).pipe(
            catchError(this.handleError)
        ).toPromise();
        return res.json();
    }

    async filter(model: any) {
        const res: any = await this.client.post(`/api/Promotion/Filter`, model).pipe(
            catchError(this.handleError)
        ).toPromise();
        return res.json();
    }

    handleError(error) {
        return throwError(error.json());
    }
}
