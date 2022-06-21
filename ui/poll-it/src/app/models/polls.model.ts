import { PollOption } from "./poll-options.model";

export class Polls {
    questionId: number;
    guid: string;
    questionTitle: string;
    creationDateTimeUtc: Date;
    updationDateTimeUtc: Date;
    totalVotes: number;
    totalOptions: number;
    pollOption: PollOption[];

    constructor()
    {
        this.pollOption = [];
    }
}