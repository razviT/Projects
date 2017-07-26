import { Component, Input, Output, OnInit,EventEmitter } from '@angular/core';
import { Observable } from "rxjs/Observable";
import { DataInterface } from './data-interface';
import { Form } from './form.component';
import { FormService } from './form.service';

@Component({
    selector: 'root',
    styleUrls: ['./app.component.css'],
    template:
    `
    <form *ngIf="formVisible" (clicked)="result = $event" (formVisible)="formVisible = $event"></form>  
    <result *ngIf="!formVisible" [serverResult]="result" (goBack)="formVisible = $event"></result>
    `
})

export class AppComponent {
    @Input() formVisible: boolean = true;
    @Input() result: string;
}