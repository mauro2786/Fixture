using Fixture.Domain;
using Fixture.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
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
        public IEnumerable<Tournament> Get()
        {
            return tournamentService.Get();
        }

        // GET api/Tournaments/{id}
        public Tournament Get(int id)
        {
            return tournamentService.Get(id);
        }

        // POST api/Tournaments/
        public Tournament Create(Tournament tournament)
        {
            return tournamentService.Create(tournament);
        }

        // PUT api/Tournaments/{id}
        public Tournament Put(int id, Tournament tournament)
        {
            tournament.Id = id;
            return tournamentService.Update(tournament);
        }

        // DELETE api/Tournaments/{id}
        public void Delete(int id)
        {
            tournamentService.Delete(id);
        }
    }
}
