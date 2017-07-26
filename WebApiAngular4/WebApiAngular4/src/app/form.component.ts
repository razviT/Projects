import { Component, Input, Output, OnInit, EventEmitter } from '@angular/core';
import { DataInterface } from './data-interface';
import { FormService } from './form.service';
@Component({
    selector: 'form',
    styleUrls: ['./app.component.css'],

    template:
    `
     <div>
       <label>Text :</label>
       <br>
       <textarea [ngModel]="data.text" (ngModelChange)="ValueChangeText($event)"></textarea> 
       <br>   
{{textComment}}
     </div>
     <div>
       <br>
       <label>Letter :</label>
       <br>
       <input [ngModel]="data.letter" (ngModelChange)="ValueChangeLetter($event)" maxLength=1>
       <br>
 {{letterComment}}
     </div>
     <div>
       <br>
       <label>String : </label>
       <br>
       <input [ngModel]="data.stringToAdd" (ngModelChange)="ValueChangeString($event)">
       <br>
 {{stringComment}}
<br>
<br>
<button (click)=DoIfClicked()>Replace letter</button>
     </div>  
    `
})

export class Form {
    @Input() result: string;
    @Output() clicked: EventEmitter<string> = new EventEmitter<string>();
    @Output() formVisible: EventEmitter<boolean> = new EventEmitter<boolean>();
    data: DataInterface = {
        text: '',
        letter: '',
        stringToAdd: ''
    }
    textComment: string = 'input text';
    letterComment: string = 'input letter';
    stringComment: string = 'input string';

    ValueChangeText(newValue) {
        this.data.text = newValue;
        let temp = this.data.text.replace(this.data.letter, '');
        if (this.data.text.length == 0)
            this.textComment = 'input text';
        else if (this.data.text.length != temp.length)
            this.letterComment = '';
        else this.textComment = '';
    }
    ValueChangeString(newValue) {
        this.data.stringToAdd = newValue;
        if (this.data.stringToAdd.length == 0)
            this.stringComment = 'input string';
        else this.stringComment = '';
    }     
    ValueChangeLetter(newValue) {
        this.data.letter = newValue;
        let temp = this.data.text.replace(newValue, '');      
        if (this.data.letter.length == 0)
            this.letterComment = 'input letter';
        else if (this.data.text.length == temp.length && this.data.letter.length==1)
            this.letterComment = 'Letter not found in text';
        else this.letterComment = '';
    }
    constructor(private service: FormService) { }

    DoIfClicked() {
        this.service.PostData(this.data).subscribe(response =>
        {
            this.result = response;
            this.clicked.emit(this.result);
            this.formVisible.emit(false)
        });
    }
}