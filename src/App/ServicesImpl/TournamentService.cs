﻿using Fixture.Persistence;
using System.Collections.Generic;
using Fixture.Domain;
using Fixture.Services;

namespace Fixture.ServicesImpl
{
    public class TournamentService : ITournamentService
    {
        private ITournamentRepository tournamentRepository;

        public TournamentService(ITournamentRepository tournamentRepository)
        {
            this.tournamentRepository = tournamentRepository;
        }

        public IEnumerable<Tournament> Get()
        {
            return tournamentRepository.Get();
        }

        public Tournament Get(int id)
        {
            return tournamentRepository.Get(id);
        }

        public Tournament Create(Tournament tournament)
        {
            return tournamentRepository.Create(tournament);
        }

        public Tournament Update(Tournament tournament)
        {
            return tournamentRepository.Update(tournament);
        }

        public void Delete(int id)
        {
            tournamentRepository.Delete(id);
        }
    }
}
