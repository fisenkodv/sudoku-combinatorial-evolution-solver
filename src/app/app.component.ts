import { Component } from '@angular/core';
import { Problem, DifficultProblem } from './models/problem.model';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  public problem: Problem = DifficultProblem;

  public getProblemValue(row: number, column: number): number {
    return this.problem.values[row][column];
  }

  public getProblemIndexes(): number[] {
    return this.problem.values.map((_, index) => index);
  }
}
