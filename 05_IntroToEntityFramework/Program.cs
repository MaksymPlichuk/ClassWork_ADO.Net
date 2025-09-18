namespace _05_IntroToEntityFramework
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var db = new MusicCollectionDBContext())
            {
                db.Database.EnsureDeleted();
                db.Database.EnsureCreated();
                DBCRUD crud = new DBCRUD();
                crud.addPlaylist();
            }

        }
    }
}
