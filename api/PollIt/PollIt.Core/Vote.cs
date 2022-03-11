namespace PollIt.Core
{
    public class Vote
    {
        public int VoteId { get; set; }

        public int QuestionOptionId { get; set; }
        public virtual QuestionOption QuestionOption { get; set; }
    }
}
