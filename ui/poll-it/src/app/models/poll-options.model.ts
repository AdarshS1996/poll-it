import { Vote } from "./vote.model";

export class PollOption {
    questionOptionId: number;
    option: string;
    creationDateTimeUtc: Date;
    updationDateTimeUtc: Date;
    totalVotes: number;
    votes: Vote[];

    constructor() {
        this.votes = [];
    }
}