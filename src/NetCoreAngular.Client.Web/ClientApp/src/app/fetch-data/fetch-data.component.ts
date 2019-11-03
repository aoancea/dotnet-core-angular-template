import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { ApplicationService } from '../core/services/application.service';

@Component({
    selector: 'app-fetch-data',
    templateUrl: './fetch-data.component.html'
})
export class FetchDataComponent {
    public forecasts: WeatherForecast[];

    constructor(
        private http: HttpClient,
        private applicationService: ApplicationService) {
        this.http.get<WeatherForecast[]>(this.applicationService.baseUrl + 'WeatherForecast').subscribe(result => {
            this.forecasts = result;
        }, error => console.error(error));
    }
}

interface WeatherForecast {
    date: string;
    temperatureC: number;
    temperatureF: number;
    summary: string;
}
