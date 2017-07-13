import { Component, Injectable } from '@angular/core';
import { Http, Response } from '@angular/http';
import 'rxjs/add/operator/map';
import { Observable } from "rxjs/Observable";

export class InputData {
    text: string;
    letter: string;
    stringToAdd: string;
}
export class Result {
    text: string;
    letter: string;
    stringToAdd: string;
}
@Component({
    selector: 'app-root',
    templateUrl: './app.component.html',
    styleUrls: ['./app.component.css'],
    template: `
      <div><label>Input text :</label>
      <br>
      <textarea [(ngModel)]="inData.text" ></textarea>
      </div>
      <div><label>Input letter :</label>
      <br>
      <input [(ngModel)]="inData.letter" >
      </div>
      <div><label>Input string : </label>
      <br>
      <input [(ngModel)]="inData.stringToAdd" >
      <br>
      </div>
      <div>
      <br>
      <button (click)="Clicked()">Replace the letter</button>
      <br>
      </div>
      <div *ngIf="result.text != ''" ><label>Resulting Text : </label>
      <br>
      <textarea [(ngModel)]="result.text" [readonly]="true" ></textarea>
      </div>`    
})

export class AppComponent {
    constructor(private http: Http) { }
    result: Result = {
        text: '',
        letter: '',
        stringToAdd: ''
    }
    inData: InputData = {
        text: '',
        letter: '',
        stringToAdd: ''
    };
    response: Response
    Clicked() {
        this.http.post('http://localhost:55680/api/values', this.inData)
            .map(res => res.json())
            .subscribe(
            response => {
                this.result = response;
            }, 
            err => { alert("err") } 
            )
    }
}