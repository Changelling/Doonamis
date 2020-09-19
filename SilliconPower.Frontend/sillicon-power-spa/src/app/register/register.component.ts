import { Component, OnInit } from '@angular/core';
import { SilliconPowerService } from '../services/sillicon-power.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  user = {
    userName: '',
    password: '',
  };
  submitted = false;
  constructor(private silliconPowerService: SilliconPowerService) { }

  ngOnInit(): void {
  }

  registerUser(): void {
    const data = {
      userName: this.user.userName,
      password: this.user.password
    };

    this.silliconPowerService.register(data)
      .subscribe(
        response => {
          console.log(response);
          this.submitted = true;
        },
        error => {
          console.log(error);
        });
  }

  newUser(): void {
    this.submitted = false;
    this.user = {
      userName: '',
      password: ''
    };
  }
}
