import { Component, OnInit } from '@angular/core';
import { AuthenticationService } from 'src/app/services/common/authentication.service';

@Component({
  selector: 'app-welcome-admin',
  templateUrl: './welcome-admin.component.html',
  styleUrls: ['./welcome-admin.component.css']
})
export class WelcomeAdminComponent implements OnInit {

  userName = '';

  constructor(
    private auth: AuthenticationService,
    
  ) { }

  ngOnInit() {
    this.userName = this.auth.currentUser.name;
  }

  logout() {
    this.auth.logout();
  }

}
