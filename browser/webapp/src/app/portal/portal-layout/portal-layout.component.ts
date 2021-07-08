import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-portal-layout',
  templateUrl: './portal-layout.component.html',
  styleUrls: ['./portal-layout.component.css']
})
export class PortalLayoutComponent implements OnInit {
  isLogin = false;
  username = '';
  constructor(
    private service: AuthService,
    private router: Router
  ) { }

  ngOnInit(): void {
    this.isLogin = this.service.isLogin;
    this.username = this.service.username;
  }



  logout(): void {
    this.service.logout();
    this.router.navigateByUrl('/index');
  }


}
