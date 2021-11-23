import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.css'],
})

/**
 * @Description Here the necessary properties are taken for the validation
 * @props {String}
 *
 */
export class SignupComponent implements OnInit {
  [x: string]: any;
  username = '';
  email = '';
  password = '';
  ConfirmPassword = '';

  valid = {
    username: true,
    email: true,
    password: true,
    ConfirmPassword: true,
  };
  constructor() {}

  ngOnInit(): void {}
  validate(type: string): void {
    // vadilate is used to vadilate with schema given
    const usernamePattern = /^[\w-.]*$/;
    const emailPattern = /\S+@\S+\.\S+/;

    if (type === 'username') {
      if (this.username.length < 5) {
        this.valid.username = false;
      } else {
        this.valid.username = usernamePattern.test(this.username);
      }
    } else if (type === 'email') {
      this.valid.email = emailPattern.test(this.email);
    } else if (type === ('ConfirmPassword' || 'password')) {
      if (this.password !== this.ConfirmPassword) {
        this.valid.password = false;
      } else {
        this.valid.password = true;
      }
    }
  }

  // here on onkey is binding to respond to any DOM event

  onkey(event: any, type: string) {
    if (type === 'username') {
      this['username'] = event.target.value;
    } else if (type === 'email') {
      this.email = event.target.value;
    } else if (type === 'password') {
      this.password = event.target.value;
    } else if (type === 'ConfirmPassword') {
      this.ConfirmPassword = event.target.value;
    }

    this.validate(type);
  }
}
