using Microsoft.EntityFrameworkCore;
using PollIt.Data;
using PollIt.Service.QuestionOptionService;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PollIt.Service.QuestionService
{
    public class QuestionService
    {
        private readonly DatabaseContext _databaseContext;
        private readonly VoteService.VoteService _voteService;

        public QuestionService(DatabaseContext databaseContext,
                               VoteService.VoteService voteService)
        {
            _databaseContext = databaseContext;
            _voteService = voteService;
        }

        public List<QuestionDto> GetQuestions()
        {
            var questions = _databaseContext.Questions.Where(x => !x.IsRemoved).ToList();

            var questionDtos = questions.Select(question => QuestionMapper.ToDto(question)).ToList();

            questionDtos.ForEach(questionDto => questionDto.TotalVotes = _voteService.GetVoteCountByQuestionId(questionDto.QuestionId));

            return questionDtos;
        }

        public QuestionDto GetQuestion(string guid)
        {
            var question = _databaseContext.Questions
                                           .Include(x => x.QuestionOptions)
                                           .FirstOrDefault(x => x.Guid == new Guid(guid)
                                                                && !x.IsRemoved);
            if (question == null)
            {
                throw new System.Exception("Resource not found");
            }

            var questionDto = QuestionMapper.ToDto(question);
            if (question.QuestionOptions.Count > 0)
            {
                var questionOptions = question.QuestionOptions.Where(x => !x.IsRemoved).ToList();
                questionDto.QuestionOptions = QuestionOptionMapper.ToDtos(questionOptions);
                questionDto.QuestionOptions.ForEach(questionOption => questionOption.TotalVotes = _voteService.GetVoteCountByQuestionOptionId(questionOption.QuestionOptionId));
            }

            questionDto.TotalVotes = _voteService.GetVoteCountByQuestionId(questionDto.QuestionId);

            return questionDto;
        }

        public QuestionDto PostQuestion(QuestionDto questionDto)
        {
            var question = QuestionMapper.ToEntity(questionDto);
            _databaseContext.Questions.Add(question);
            _databaseContext.SaveChanges();

            questionDto.QuestionOptions.ForEach(x => x.QuestionId = question.QuestionId);
            question.QuestionOptions = QuestionOptionMapper.ToEntities(questionDto.QuestionOptions);
            _databaseContext.QuestionOptions.AddRange(question.QuestionOptions);
            _databaseContext.SaveChanges();

            return GetQuestion(question.Guid.ToString());
        }

        public string DeleteQuestion(string guid)
        {
            var question = _databaseContext.Questions
                                           .Include(x => x.QuestionOptions)
                                           .FirstOrDefault(x => x.Guid == new System.Guid(guid)
                                                                && !x.IsRemoved);
            if (question == null)
            {
                throw new System.Exception("Resource not found to delete");
            }

            question.IsRemoved = true;
            if (question.QuestionOptions.Count > 0)
            {
                question.QuestionOptions.ToList().ForEach(x => x.IsRemoved = true);
            }

            _databaseContext.SaveChanges();

            return "Question and it's options deleted successfully";
        }
    }
}
