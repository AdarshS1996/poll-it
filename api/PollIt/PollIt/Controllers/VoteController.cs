using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PollIt.Service.VoteService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PollIt.Controllers
{
    [Route("api/1.0/Votes")]
    [ApiController]
    public class VoteController : Controller
    {
        private readonly VoteService _voteService;

        public VoteController(VoteService voteService)
        {
            _voteService = voteService;
        }

        [HttpPost]
        public IActionResult PostVote([FromBody]VoteDto voteDto)
        {
            return Ok(_voteService.PostVote(voteDto));
        }
    }
}
