import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { AuthService } from '../common/services/auth.service'
import { GlobalService } from '../global.service';
import { ETypeLogin } from '../common/type-login.enum';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {


  typeLogin: ETypeLogin;
  ETypeLogin: any;
  sub: any;
  operation: string;

  constructor(private authService: AuthService, private route: ActivatedRoute, private router: Router) {
    this.typeLogin = GlobalService.getAuthSettings().TYPE_LOGIN;
    this.ETypeLogin = ETypeLogin;

    console.log(this.typeLogin);
  }

  ngOnInit() {

    this.sub = this.route.params.subscribe(params => {
      this.operation = params['operation'];
    });


    if (this.operation == "out") {
      console.log(this.operation);
      this.authService.logout();
    }
    else {
      this.authService.loginSso();
    }
  }

}
