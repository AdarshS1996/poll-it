using System;
using System.Collections.Generic;

namespace PollIt.Core
{
    public class QuestionOption
    {
        public int QuestionOptionId { get; set; }

        public int QuestionId { get; set; }
        public virtual Question Question { get; set; }

        public string Option { get; set; }

        public bool IsRemoved { get; set; }

        public DateTimeOffset CreationDateTimeUtc { get; set; }

        public DateTimeOffset? UpdationDateTimeUtc { get; set; }

        public virtual ICollection<Vote> Votes { get; set; }
    }
}
