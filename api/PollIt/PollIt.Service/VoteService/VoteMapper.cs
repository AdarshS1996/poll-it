using PollIt.Core;

namespace PollIt.Service.VoteService
{
    public static class VoteMapper
    {
        public static VoteDto ToDto(Vote vote)
        {
            var dto = new VoteDto()
            {
                VoteId = vote.VoteId,
                QuestionOptionId = vote.QuestionOptionId
            };
            return dto;
        }

        public static Vote ToEntity(VoteDto voteDto, Vote entity = null)
        {
            if (entity == null)
            {
                entity = new Vote()
                {
                    QuestionOptionId = voteDto.QuestionOptionId
                };
            }

            entity.QuestionOptionId = voteDto.QuestionOptionId;

            return entity;
        }
    }
}
