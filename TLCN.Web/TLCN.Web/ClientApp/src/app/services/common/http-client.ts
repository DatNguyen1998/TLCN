import { Injectable } from '@angular/core';
import { Http, Headers, ResponseType, ResponseContentType } from '@angular/http';
import { Router } from '@angular/router';

@Injectable()
export class HttpClient {
  constructor(private http: Http, private router: Router) { }

  createAuthorizationHeader(headers: Headers) {
    headers.append('Content-Type', 'application/json');
    headers.append('Authorization', 'Bearer ');
  }

  createAuthorizationHeaderForUploading(headers: Headers) {    
    headers.append('Authorization', 'Bearer ');
  }

  //get(url: string) {
  //  if (!this.authSvc.isLoggedIn) {
  //    this.redirectToLoginPage();
  //  }
  //  const headers = new Headers();
  //  this.createAuthorizationHeader(headers);
  //  return this.http.get(url, {
  //    headers: headers,
  //  });

  //}

  //post(url: string, data: any) {
  //  if (!this.authSvc.isLoggedIn) {
  //    this.redirectToLoginPage();
  //  }
  //  const headers = new Headers();
  //  this.createAuthorizationHeader(headers);
  //  return this.http.post(url, data, {
  //    headers: headers,
  //  });
  //}

  //upload(url: string, data: any) {
  //  if (!this.authSvc.isLoggedIn) {
  //    this.redirectToLoginPage();
  //  }    
  //  const headers = new Headers();
  //  this.createAuthorizationHeaderForUploading(headers);
  //  return this.http.post(url, data, {
  //    headers: headers,
  //  });    
  //}

  redirectToLoginPage() {
    this.router.navigate(['/login']);
  }
}
