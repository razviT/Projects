import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { Form } from './form.component';
import { ResultComponent } from './result.component';
import { FormService } from './form.service';
import { AppComponent } from './app.component';

@NgModule({
    declarations: [
        AppComponent, Form, ResultComponent
    ],
    imports: [
        BrowserModule,
        FormsModule,
        HttpModule,

    ],
    providers: [FormService, Form, ResultComponent],
    bootstrap: [AppComponent]
})
export class AppModule { }