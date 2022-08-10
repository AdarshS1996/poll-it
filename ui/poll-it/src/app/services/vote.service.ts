import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable} from 'rxjs';
import { environment } from 'src/environments/environment';
import { Vote } from '../models/vote.model';

@Injectable()
export class VoteService {
    constructor(protected httpClient: HttpClient) {}

    postVote(vote: Vote): Observable<Vote> {
        return this.httpClient.post<Vote>(environment.apiEndpoint + 'Votes', vote);
    }
}
