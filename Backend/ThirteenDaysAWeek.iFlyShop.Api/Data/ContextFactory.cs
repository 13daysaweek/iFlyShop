namespace ThirteenDaysAWeek.iFlyShop.Api.Data
{
    public class ContextFactory : IContextFactory
    {
        public iFlyShopContext CreateInstance()
        {
            return new iFlyShopContext();
        }
}
}