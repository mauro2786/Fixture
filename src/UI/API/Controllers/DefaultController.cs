using Fixture.Domain;
using Fixture.Persistence;
using System.Collections;
using System.Collections.Generic;
using System.Web.Http;

namespace API.Controllers
{
    public class DefaultController : ApiController
    {
        private ITournamentRepository tournamentRepository;

        //public DefaultController() { }

        public DefaultController(ITournamentRepository tournamentRepository)
        {
            this.tournamentRepository = tournamentRepository;
        }

        [HttpGet]
        [Route("dame")]
        public IEnumerable<Tournament> Get()
        {
            return tournamentRepository.Get();
        }
    }
}
