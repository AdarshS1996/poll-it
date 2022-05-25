using PollIt.Core;
using System;
using System.Collections.Generic;

namespace PollIt.Service.QuestionOptionService
{
    public class QuestionOptionDto
    {
        public int QuestionOptionId { get; set; }

        public int QuestionId { get; set; }

        public string Option { get; set; }

        public bool IsRemoved { get; set; }

        public DateTimeOffset CreationDateTimeUtc { get; set; }

        public DateTimeOffset? UpdationDateTimeUtc { get; set; }

        public int? TotalVotes { get; set; }

        public virtual List<Vote> Votes { get; set; }
    }
}
