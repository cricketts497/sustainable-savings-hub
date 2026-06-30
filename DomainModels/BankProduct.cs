namespace DomainModels
{
    public class BankProduct
    {
        required public string Id { get; init; }

        required public string ProviderId { get; init; }

        required public string Name { get; init; }

        public List<string> Features { get; init; } = [];
    }
}
