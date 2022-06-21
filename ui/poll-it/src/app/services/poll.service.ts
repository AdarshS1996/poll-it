import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable} from 'rxjs';
import { environment } from 'src/environments/environment';
import { Polls } from '../models/polls.model';

@Injectable()
export class PollService {
    constructor(protected httpClient: HttpClient) {}

    getQuestions(): Observable<Polls[]> {
        return this.httpClient.get<Polls[]>(environment.apiEndpoint + 'Questions');
    }

    getQuestionById(guid: string) {
        return this.httpClient.get<Polls>(environment.apiEndpoint + 'Questions/' + guid);
    }

    postQuestion(question: Polls): Observable<Polls> {
        return this.httpClient.post<Polls>(environment.apiEndpoint + 'Questions', question);
    }
}
