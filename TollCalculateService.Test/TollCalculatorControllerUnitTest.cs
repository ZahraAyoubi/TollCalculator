using Moq;
using System;
using TollCalculatorService.APIPrpject.Repository;
using TollCalculatorService.APIPrpject.Models;
using TollCalculatorService.APIPrpject.DbContexts;
using Xunit;

namespace TollCalculateService.Test
{
    public class TollCalculatorRepositoryUnitTest
    {
        private readonly TollCalculatorRepository _repo;
        private readonly Mock<ApplicationDbContext> _context;

        private readonly VehicleType _car = new VehicleType { Name = "car" };
        private readonly VehicleType _emergency = new VehicleType { Name = "emergency" };

        public TollCalculatorRepositoryUnitTest()
        {
            _context = new Mock<ApplicationDbContext>();
            _repo = new TollCalculatorRepository(_context.Object);
        }
        [Fact]
        public void GetTollFee_Should_Calculate_Toll()
        {
            DateTime[] date = new DateTime[]
             {

                new DateTime(2013, 10, 1, 8, 15, 0),
                new DateTime(2013, 10, 1, 8, 30, 1),
                new DateTime(2013, 10, 1, 8, 45, 2),
                new DateTime(2013, 10, 1, 9, 15, 3),
              };

            var result = _repo.GetTollFee(_car, date);

            Assert.NotEqual(0, result);
        }
        [Fact]
        public void GetTollFee_Should_be_Toll_Free_For_Holidays()
        {
            DateTime[] date = new DateTime[]
            {

                new DateTime(2013, 1, 1, 8, 15, 0),
                new DateTime(2013, 1, 1, 8, 30, 1),
                new DateTime(2013, 1, 1, 8, 45, 2),
                new DateTime(2013, 1, 1, 9, 15, 3),
             };

            var result = _repo.GetTollFee(_car, date);

            Assert.Equal(0, result);
        }
        [Fact]
        public void GetTollFee_Should_be_Toll_Free_For_Special_Vehicle()
        {
            DateTime[] date = new DateTime[]
 {

                new DateTime(2013, 10, 1, 8, 15, 0),
                new DateTime(2013, 10, 1, 8, 30, 1),
                new DateTime(2013, 10, 1, 8, 45, 2),
                new DateTime(2013, 10, 1, 9, 15, 3),
  };

            var result = _repo.GetTollFee(_emergency, date);

            Assert.Equal(0, result);
        }
    }
}