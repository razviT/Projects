import { Component } from '@angular/core';
import { Http, Response } from '@angular/http';
import { Injectable, Input, Output, EventEmitter } from '@angular/core';
import 'rxjs/add/operator/map';
import { Observable } from "rxjs/Observable";
import { Form } from './form.component';
import { ResultComponent } from './result.component';
import { DataInterface } from './data-interface';

@Injectable()

export class FormService {
    constructor(private http: Http, public result: ResultComponent) { }
    response: Response;
    PostData(inputData) {
        return this.http.post('http://localhost:55680/api/values', inputData)
            .map(res => res.text())
    }
}