namespace AWC.Infra.Results
{
    public class UpsertCommandResult
    {
        public int Result { get; set; }
        public Guid? InsertedId { get; set; }
    }
}
