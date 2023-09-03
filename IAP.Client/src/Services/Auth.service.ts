import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { UserLoginModel } from 'src/Models/UserLogin.Model'
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private baseUrl = '/Logging';

  constructor(private http: HttpClient) { }

  login(login: string, password: string): Observable<any> {
    const userLoginModel: UserLoginModel = { login, password };
    return this.http.post<any>(this.baseUrl, userLoginModel);
  }
}