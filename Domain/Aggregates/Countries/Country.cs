namespace SportsBet.Domain.Aggregates.Countries;
public class Country : BaseEntity<long>, IAggregateRoot
{
    public CountryName Name { get; private set; }
    public CountryBetContext BetContext { get; private set; }
    public int ProviderId { get; private set; }
    public int SportId { get; private set; }

    private Country() { }

    internal Country(CountryName name,
        int sportId,
        int providerId)
    {
        Id = UniqueIdGenerator.CreateId();
        Name = name;
        SportId = sportId;
        ProviderId = Guard.Against.InvalidInput(providerId, nameof(providerId), providerId => providerId >= 0);

        _domainEvents.Add(new CountryAddedEvent(this));
    }

    public static Country Create(
        string code,
        string name,
        int sportId,
        int providerId)
    {
        var countryName = CountryName.Create(code: code,
            name: name);

        var country = new Country(name: countryName,
            sportId: sportId,
            providerId : providerId);

        return country;
    }

    public void Update(string code, string name)
    {
        var countryName = CountryName.Create(code: code,
            name: name);

        Name = countryName;

        _domainEvents.Add(new CountryUpdatedEvent(this));
    }

    public void UpdateCountryName(CountryName countryName)
    {
        Name = countryName;

        _domainEvents.Add(new CountryUpdatedEvent(this));
    }

    public void Map(int bBRegionId, int mappingAgentId)
    {
        var regionBetContext = CountryBetContext.Create(bBRegionId: bBRegionId,
            mappingAgentId: mappingAgentId,
            mappedAt: DateTime.UtcNow);

        BetContext = regionBetContext;

        _domainEvents.Add(new CountryMappedEvent(this));
    }

    public void Unmap()
    {
        var regionBetContext = CountryBetContext.Create(bBRegionId: null,
            mappingAgentId: null,
            mappedAt: null);

        BetContext = regionBetContext;

        _domainEvents.Add(new CountryUnmappedEvent(this));
    }

    public bool IsMapped()
    {
        return BetContext != null && BetContext.BBRegionId != default;
    }

    protected override void Validate()
    {
        throw new NotImplementedException();
    }
}
