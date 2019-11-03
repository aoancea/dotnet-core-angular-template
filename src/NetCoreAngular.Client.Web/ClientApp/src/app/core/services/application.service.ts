import { Injectable } from '@angular/core';

@Injectable()
export class ApplicationService {

    public baseUrl: string;

    constructor() {
        this.baseUrl = document.getElementsByTagName('base')[0].href;
    }
}