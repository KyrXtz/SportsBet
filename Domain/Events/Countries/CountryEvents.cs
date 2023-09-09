namespace SportsBet.Domain.Events.Countries
{
    public class CountryAddedEvent : BaseDomainEvent
    {
        public Country NewCountry { get; private set; }

        public CountryAddedEvent(Country newCountry)
        {
            NewCountry = newCountry;
        }
    }

    public class CountryUpdatedEvent : BaseDomainEvent
    {
        public Country UpdatedCountry { get; private set; }

        public CountryUpdatedEvent(Country updatedCountry)
        {
            UpdatedCountry = updatedCountry;
        }
    }

    public class CountryMappedEvent : BaseDomainEvent
    {
        public Country MappedCountry { get; private set; }

        public CountryMappedEvent(Country mappedCountry)
        {
            MappedCountry = mappedCountry;
        }
    }

    public class CountryUnmappedEvent : BaseDomainEvent
    {
        public Country UnmappedCountry { get; private set; }

        public CountryUnmappedEvent(Country unmappedCountry)
        {
            UnmappedCountry = unmappedCountry;
        }
    }
}
