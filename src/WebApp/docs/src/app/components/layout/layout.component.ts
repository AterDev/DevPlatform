import { Component, OnInit } from '@angular/core';
import { NavigationStart, Router } from '@angular/router';
import { AuthService } from 'src/app/share/services/auth.service';

@Component({
  selector: 'app-layout',
  templateUrl: './layout.component.html',
  styleUrls: ['./layout.component.css']
})
export class LayoutComponent implements OnInit {
  isLogin = false;
  username = '';
  constructor(
    private service: AuthService,
    private router: Router
  ) {
    // this layout is out of router-outlet, so we need to listen router event and change isLogin status
    router.events.subscribe((event) => {
      if (event instanceof NavigationStart) {
        console.log(event);
        this.isLogin = this.service.isLogin;
        this.username = this.service.username;
      }
    });
  }
  ngOnInit(): void {

  }
  login(): void {
    this.router.navigateByUrl('/login');
  }

  logout(): void {
    this.service.logout();
    this.router.navigateByUrl('/index');
    location.reload();
  }
}
