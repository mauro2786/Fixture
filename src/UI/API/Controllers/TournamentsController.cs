using System.Collections.Generic;
using System.Web.Http;
using Fixture.Domain;
using Fixture.Services;

namespace API.Controllers
{
    public class TournamentsController : ApiController
    {
        private ITournamentService tournamentService;

        public TournamentsController(ITournamentService tournamentService)
        {
            this.tournamentService = tournamentService;
        }

        // GET api/Tournaments/?extended=true
        public IEnumerable<Tournament> Get(bool extended = false) => tournamentService.Get(extended);

        // GET api/Tournaments/{id}
        public Tournament Get(int id) => tournamentService.Get(id);

        // POST api/Tournaments/
        public Tournament Create(Tournament tournament) => tournamentService.Create(tournament);

        // DELETE api/Tournaments/{id}        
        public void Delete(int id) => tournamentService.Delete(id);

        // PUT api/Tournaments/{id}
        public Tournament Put(int id, Tournament tournament)
        {
            tournament.Id = id;
            return tournamentService.Update(tournament);
        }
    }
}
