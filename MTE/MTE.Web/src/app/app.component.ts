import { Component, OnInit } from '@angular/core';
import { TestServiceService } from './test-service.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
  providers: [TestServiceService]
})


export class AppComponent implements OnInit {
  
  public students: any;

  constructor(private testService: TestServiceService) {}

  public ngOnInit(): void {

    this.testService.getStudents().then(data => {
      this.students = data;
    }).catch(err => {
      console.log('Je ne comprend pas');
    });
  }
  
  title = 'MTE';
}
