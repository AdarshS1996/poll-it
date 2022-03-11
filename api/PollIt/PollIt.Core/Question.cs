﻿using System;
using System.Collections.Generic;

namespace PollIt.Core
{
    public class Question
    {
        public int QuestionId { get; set; }

        public Guid Guid { get; set; }

        public string QuestionTitle { get; set; }

        public bool IsRemoved { get; set; }

        public DateTimeOffset CreationDateTimeUtc { get; set; }

        public DateTimeOffset? UpdationDateTimeUtc { get; set; }

        public virtual ICollection<QuestionOption> QuestionOptions { get; set; }
    }
}
