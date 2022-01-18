using Nager.Date;
using TollCalculatorService.APIPrpject.DbContexts;
using TollCalculatorService.APIPrpject.Models;

namespace TollCalculatorService.APIPrpject.Repository
{
    public class TollCalculatorRepository : ITollCalculatorRepository
    {
        private ApplicationDbContext _dbContext;
        private List<TollFee> tollFeeInfos;
        private List<VehicleType> vehicleTypes;

        public TollCalculatorRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            tollFeeInfos = _dbContext.TollFees.ToList();
            vehicleTypes = _dbContext.VehicleTypes.ToList();
        }
        public int GetTollFee(VehicleType vehicle, DateTime[] dates)
        {
            DateTime intervalStart = dates[0];
            int totalFee = 0;
            foreach (DateTime date in dates)
            {
                int nextFee = GetTollFee(date, vehicle);
                int tempFee = GetTollFee(intervalStart, vehicle);

                long diffInMillies = date.Millisecond - intervalStart.Millisecond;
                long minutes = diffInMillies / 1000 / 60;

                if (minutes <= 60)
                {
                    if (totalFee > 0) totalFee -= tempFee;
                    if (nextFee >= tempFee) tempFee = nextFee;
                    totalFee += tempFee;
                }
                else
                {
                    totalFee += nextFee;
                }
            }
            if (totalFee > 60) totalFee = 60;
            return totalFee;
        }
        public int GetTollFee(DateTime date, VehicleType vehicle)
        {
            if (IsTollFreeDate(date) || IsTollFreeVehicle(vehicle)) return 0;

            var time = date.TimeOfDay;

            var tollFee = tollFeeInfos.FirstOrDefault(x => IsBetween(time, x.EventStart, x.EventEnd));
            if (tollFee != null)
            {
                var costType = _dbContext.CostTypes.FirstOrDefault(x => x.Id == tollFee.CostTypeId);
                if (costType != null)
                {
                    return costType.Cost;
                }
            }
            return 0;
        }
        private bool IsTollFreeVehicle(VehicleType vehicle)
        {
            foreach (var item in vehicleTypes)
            {
                if (item.Name.Equals(vehicle.Name))
                    return item.IsTollFree;
            }
            return false;
        }
        private bool IsHoliday(DateTime date)
        {
            return DateSystem.IsPublicHoliday(date, CountryCode.SE);
        }

        private bool IsTollFreeDate(DateTime date)
        {
            return IsHoliday(date) || IsHoliday(date.AddDays(1)) ||
                   date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday ||
                   date.Month == 7;// July is a free month
        }

        private bool IsBetween(TimeSpan dateToCompare, TimeSpan start, TimeSpan end)
        {
            return dateToCompare >= start && dateToCompare <= end;
        }
    }
}
