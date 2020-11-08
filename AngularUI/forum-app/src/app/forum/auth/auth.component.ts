import { Component, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import LoginResult from 'src/models/auth/LoginResult';
import { RegisterView, LoginView, AccountView } from 'src/models/views/auth/AuthView';
import { AuthService } from 'src/services/auth/auth.service';
import { NotificationService } from 'src/services/notification/notification.service';
import { UserService } from 'src/services/user/user.service';

enum AuthState {
  LOGIN,
  REGISTER
}

@Component({
  selector: 'app-auth',
  templateUrl: './auth.component.html',
  styleUrls: ['./auth.component.scss']
})
export class AuthComponent implements OnInit {

  private state: AuthState;
  registerForm : FormGroup;
  loginForm : FormGroup;
  registerData: RegisterView = new RegisterView();
  loginData: LoginView = new LoginView();
  isLoading: boolean;

  @ViewChild("fileUpload", {static: false}) fileUpload: ElementRef;
  file : File;
  imgURL: any;

  constructor(
    public auth: AuthService,
    public user: UserService,
    public router: Router,
    private formBuilder: FormBuilder,
    private alert: NotificationService) {

    this.state = AuthState.REGISTER;
    this.isLoading = false;

    this.registerForm = formBuilder.group({
      firstName: [null, [Validators.required]],
      lastName: [null, [Validators.required]],
      email: [null, [Validators.required]],
      password: [null, [Validators.required]],
      pseudo: [null, [Validators.required]]
    });

    this.loginForm = formBuilder.group({
      email: [null, [Validators.required]],
      password: [null, [Validators.required]]
    });

  }

  ngOnInit(): void {

  }

  onClickLogin() : void {
    this.state = AuthState.LOGIN;
  }

  onClickRegister() : void {
    this.state = AuthState.REGISTER;
  }

  async onSubmitRegister(register: RegisterView) {
    this.isLoading = true;
    var user : AccountView = await this.user.registerUser(register);
    if(user!=undefined&&user._id!=undefined){
      this.alert.showSuccess("Success register","Success")
      this.state = AuthState.LOGIN;
      this.registerForm.reset();
    } else {
      this.alert.showError("Error on register","Error")
    }
    this.isLoading = false;
  }

  async onSubmitLogin(login : LoginView){

    this.isLoading = true;
    var loginResult : LoginResult = await this.auth.loginUser(login);

    if(loginResult==undefined)
      this.alert.showError("Error on login : "+loginResult.message,"Error");
    else if(loginResult.jwtToken==undefined||loginResult.refreshToken==undefined)
      this.alert.showError("Error on login : "+loginResult.message,"Error");
    else {
      this.alert.showSuccess("Success login - redirect","Success")
      this.loginForm.reset();
      this.router.navigate(['/']);
    }

    this.isLoading = false;
  }

  isRegister() : boolean {
    return this.state == AuthState.REGISTER;
  }

  isLogin() : boolean {
    return this.state == AuthState.LOGIN;
  }

}
