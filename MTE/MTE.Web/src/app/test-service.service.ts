import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

const BaseRoute: string = 'http://localhost/MTE';

@Injectable({
  providedIn: 'root'
})

export class TestServiceService {

  constructor(private httpclient: HttpClient) { }

  public getStudents(): Promise<any> {
    let route = `${BaseRoute}/api/students`;

    let x = this.httpclient.get(route);
    return x.toPromise();
  }
}
