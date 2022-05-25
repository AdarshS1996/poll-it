using PollIt.Core;
using System;

namespace PollIt.Service.QuestionService
{
    public static class QuestionMapper
    {
        public static QuestionDto ToDto(Question question)
        {
            var dto = new QuestionDto()
            {
                QuestionId = question.QuestionId,
                Guid = question.Guid,
                QuestionTitle = question.QuestionTitle,
                IsRemoved = question.IsRemoved,
                CreationDateTimeUtc = question.CreationDateTimeUtc
            };
            return dto;
        }

        public static Question ToEntity(QuestionDto questionDto, Question entity = null)
        {
            if (entity == null)
            {
                entity = new Question()
                {
                    Guid = Guid.NewGuid(),
                    CreationDateTimeUtc = DateTimeOffset.UtcNow
                };
            }

            entity.QuestionTitle = questionDto.QuestionTitle;
            entity.IsRemoved = questionDto.IsRemoved;

            return entity;
        }
    }
}
