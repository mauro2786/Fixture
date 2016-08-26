using Fixture.Domain;
using Fixture.Services;
using System.Collections.Generic;
using System.Web.Http;

namespace API.Controllers
{
    public class TournamentsController : ApiController
    {
        private ITournamentService tournamentService;

        public TournamentsController(ITournamentService tournamentService)
        {
            this.tournamentService = tournamentService;
        }

        // GET api/Tournaments/
        public IEnumerable<Tournament> Get() => tournamentService.Get();

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
