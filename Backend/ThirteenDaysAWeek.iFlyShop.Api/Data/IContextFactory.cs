namespace ThirteenDaysAWeek.iFlyShop.Api.Data
{
    public interface IContextFactory
    {
        iFlyShopContext CreateInstance();
    }
}