import { Component } from '@angular/core';
import { AuthService } from 'src/Services/Auth.service';

@Component({
  selector: 'app-login',
  template: `
    <form (submit)="onSubmit()">
      <input type="text" [(ngModel)]="username" name="username">
      <input type="password" [(ngModel)]="password" name="password">
      <button type="submit">Login</button>
    </form>
  `,
})
export class LoginComponent {
  username = '';
  password = '';

  constructor(private authService: AuthService) {}

  onSubmit() {
    this.authService.login(this.username, this.password).subscribe(
      () => console.log('Logged in'),
      (error) => console.log('Error:', error)
    );
  }
}