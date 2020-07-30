using System.Threading.Tasks;

namespace CarRentalSystem.Schedule.Services
{
    public interface IRentedCarService
    {
        Task UpdateInformation(int carAddId, string manufacturer, string model);
    }
}
