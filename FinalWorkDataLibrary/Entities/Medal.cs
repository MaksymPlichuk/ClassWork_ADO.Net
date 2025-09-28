namespace FinalWorkDataLibrary.Entities
{
    public class Medal
    {
        public int Id { get; set; }
        public MedalType MedalType { get; set; }
        public int MedalTypeId { get; set; }
        public ICollection<Result> Results { get; set; }
    }
}
