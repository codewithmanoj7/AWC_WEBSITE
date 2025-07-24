namespace AWC.Infra.Interfaces
{
    public interface IParameterizedQuery
    {
        Dictionary<string, object?> Parameters { get; }
    }
}
