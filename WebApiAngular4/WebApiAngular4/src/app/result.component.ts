import { Component, Input, OnChanges, EventEmitter, Output } from '@angular/core';
import { Observable } from "rxjs/Observable";
import { DataInterface } from './data-interface';
import { Form } from './form.component';

@Component({
    selector: 'result', 
    styleUrls: ['./app.component.css'],
    template:
    ` <div ><label>Resulting Text: </label>
        <br>
        <textarea [(ngModel)]='serverResult' readonly='true'> </textarea>
        <br>
        <button (click)="GoBack()" >Go back</button>
      </div>
  `
    
})

export class ResultComponent {
    @Input() serverResult: string;
    @Output() goBack: EventEmitter<boolean> = new EventEmitter<boolean>();
    GoBack() {
        this.goBack.emit(true);
    }
}