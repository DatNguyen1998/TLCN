import { Injectable } from '@angular/core';
import { HttpClient } from './http-client';
import { throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';

@Injectable()
export class AttachmentService {
  constructor(private client: HttpClient) { }

  //async getImage(id: string) {
  //  const res: any = await this.client.get(`/api/Attachment/getImage?id=${id}`).pipe(
  //    catchError(this.handleError)
  //  ).toPromise();
  //  return res.json();
  //}

  //async get(id: string, getBase64Value = false) {
  //  const res: any = await this.client.get(`/api/Attachment/get?id=${id}&getBase64Image=${getBase64Value}`).pipe(
  //    catchError(this.handleError)
  //  ).toPromise();
  //  return res.json();
  //}

  //async getList(ids: string[]) {
  //  const res: any = await this.client.post(`/api/Attachment/getList`, ids).pipe(
  //    catchError(this.handleError)
  //  ).toPromise();
  //  return res.json();
  //}

  //async upload(formData: any) {
  //  const res: any = await this.client.upload(`/api/Attachment/Upload`, formData).pipe(
  //    catchError(this.handleError)
  //  ).toPromise();
  //  return res.json();
  //}

  //async download(id: any) {
  //  const res: any = await this.client.getBlob(`/api/Attachment/download?id=${id}`).pipe(
  //    catchError(this.handleError)
  //  ).toPromise();
  //  return res.json();
  //}

  //async delete(id: any) {
  //  const res: any = await this.client.get(`/api/Attachment/delete?id=${id}`).pipe(
  //    catchError(this.handleError)
  //  ).toPromise();
  //  return res.json();
  //}

  handleError(error) {
    return throwError(error.json());
  }
}
