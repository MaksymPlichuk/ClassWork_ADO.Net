namespace _06_EFMigrations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var db = new MusicCollectionDBContext())
            {
                DBCRUD crud = new DBCRUD();
                //crud.addPlaylist();
                crud.ShowSongsInAlbumAboveAverage();
                // crud.ShowTop3SongsAlbumsByArtist();  HELP!!!!!!!!
                crud.FindSongByText();
            }
        }
    }
}
