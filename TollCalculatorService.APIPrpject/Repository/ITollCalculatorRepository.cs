using TollCalculatorService.APIPrpject.Models;

namespace TollCalculatorService.APIPrpject.Repository
{
    public interface ITollCalculatorRepository
    {
        int GetTollFee(VehicleType vehicle, DateTime[] dates);
    }
}
