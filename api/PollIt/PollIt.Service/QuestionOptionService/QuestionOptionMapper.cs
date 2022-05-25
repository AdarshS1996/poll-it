using PollIt.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PollIt.Service.QuestionOptionService
{
    public static class QuestionOptionMapper
    {
        public static QuestionOptionDto ToDto(QuestionOption questionOption)
        {
            var dto = new QuestionOptionDto()
            {
                QuestionOptionId = questionOption.QuestionOptionId,
                QuestionId = questionOption.QuestionId,
                Option = questionOption.Option,
                IsRemoved = questionOption.IsRemoved,
                CreationDateTimeUtc = questionOption.CreationDateTimeUtc
            };
            return dto;
        }

        public static List<QuestionOptionDto> ToDtos(List<QuestionOption> questionOptions)
        {
            return questionOptions.Select(questionOption => ToDto(questionOption)).ToList();
        }

        public static QuestionOption ToEntity(QuestionOptionDto questionOptionDto, QuestionOption entity = null)
        {
            if (entity == null)
            {
                entity = new QuestionOption()
                {
                    QuestionId = questionOptionDto.QuestionId,
                    CreationDateTimeUtc = DateTimeOffset.UtcNow
                };
            }

            entity.Option = questionOptionDto.Option;
            entity.IsRemoved = questionOptionDto.IsRemoved;

            return entity;
        }

        public static List<QuestionOption> ToEntities(List<QuestionOptionDto> questionOptionDtos)
        {
            return questionOptionDtos.Select(questionOptionDto => ToEntity(questionOptionDto)).ToList();
        }
    }
}
