using PollIt.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PollIt.Service.QuestionOptionService
{
    public class QuestionOptionService
    {
        private readonly DatabaseContext _databaseContext;

        public QuestionOptionService(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public int GetOptionCountByQuestionId(int questionId)
        {
            return _databaseContext.QuestionOptions.Where(x => x.QuestionId == questionId).Count();
        }
    }
}
