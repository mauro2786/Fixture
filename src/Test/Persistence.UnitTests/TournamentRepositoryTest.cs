using Microsoft.VisualStudio.TestTools.UnitTesting;
using Fixture.Persistence;

namespace Persistence.UnitTests
{
    [TestClass]
    public class TournamentRepositoryTest
    {
        private ITournamentRepository tournamentRepository;

        public TournamentRepositoryTest(ITournamentRepository tournamentRepository)
        {
            this.tournamentRepository = tournamentRepository;
        }

        [TestMethod]
        public void TestMethod1()
        {
            tournamentRepository.Get();
        }
    }
}
