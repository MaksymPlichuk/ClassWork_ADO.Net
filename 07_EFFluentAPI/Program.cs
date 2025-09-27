namespace _07_EFFluentAPI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var Db = new DbCRUD();
            Db.ShowCategoryInfo();
            Db.ShowCityInfo();
            Db.ShowCountryInfo();
            Db.ShowPositionInfo();
            Db.ShowProductInfo();
            Db.ShowShopInfo();
            Db.ShowWorkerInfo();

        }
    }
}
