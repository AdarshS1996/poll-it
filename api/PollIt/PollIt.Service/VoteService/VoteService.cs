using Microsoft.EntityFrameworkCore;
using PollIt.Core;
using PollIt.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PollIt.Service.VoteService
{
    public class VoteService
    {
        private readonly DatabaseContext _databaseContext;

        public VoteService(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public VoteDto PostVote(VoteDto voteDto)
        {
            var vote = VoteMapper.ToEntity(voteDto);
            _databaseContext.Add(vote);
            _databaseContext.SaveChanges();

            return GetVote(vote.VoteId);
        }

        public VoteDto GetVote(int voteId)
        {
            var vote = _databaseContext.Votes.FirstOrDefault(x => x.VoteId == voteId);
            if (vote == null)
            {
                throw new System.Exception("Resource not found");
            }

            var voteDto = VoteMapper.ToDto(vote);

            return voteDto;
        }

        public int GetVoteCountByQuestionId(int questionId)
        {
            var question = _databaseContext.Questions.Include(x => x.QuestionOptions)
                                                     .ThenInclude(x => x.Votes)
                                                     .FirstOrDefault(x => x.QuestionId == questionId
                                                                          && !x.IsRemoved);
            int totalVotes = default;
            foreach (var questionOption in question.QuestionOptions.Where(x => !x.IsRemoved))
            {
                totalVotes += questionOption.Votes.Count;
            }
            return totalVotes;
        }

        public int GetVoteCountByQuestionOptionId(int questionOptionId)
        {
            var questionOption = _databaseContext.QuestionOptions.Include(x => x.Votes)
                                                                 .FirstOrDefault(x => x.QuestionOptionId == questionOptionId
                                                                                      && !x.IsRemoved);
            return questionOption.Votes.Count;
        }
    }
}
