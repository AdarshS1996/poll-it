using PollIt.Service.QuestionOptionService;
using System;
using System.Collections.Generic;

namespace PollIt.Service.QuestionService
{
    public class QuestionDto
    {
        public int QuestionId { get; set; }

        public Guid Guid { get; set; }

        public string QuestionTitle { get; set; }

        public bool IsRemoved { get; set; }

        public DateTimeOffset CreationDateTimeUtc { get; set; }

        public DateTimeOffset? UpdationDateTimeUtc { get; set; }

        public int? TotalVotes { get; set; }

        public int? TotalOptions { get; set; }

        public List<QuestionOptionDto> QuestionOptions { get; set; }
    }
}
