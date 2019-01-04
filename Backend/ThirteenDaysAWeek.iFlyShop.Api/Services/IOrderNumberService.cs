namespace ThirteenDaysAWeek.iFlyShop.Api.Services
{
    public interface IOrderNumberService
    {
        string GetNewOrderNumber(int size);
    }
}