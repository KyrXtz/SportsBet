namespace TestDefinitions.Builders.Countries
{
    public class CountryBuilder
    {
        private CountryBetContext countryBetContext = new CountryBetContext(1, 1, DateTime.Now);
        private int sportId = 1;
        private int providerId = 1;
        private int bBRegionId = 1;
        private int mappingAgentId = 1;
        private DateTime mappedAt = DateTime.Now;
        private string name = "countryName";
        private string code = "countryISOCode";

        public Country Build()
        {
            var country = Country.Create(code, name, sportId, providerId);
            country.Map(bBRegionId, mappingAgentId);
            return country;
        }
        public CountryBuilder WithName(string name)
        {
            this.name = name;
            return this;
        }
        public CountryBuilder WithCode(string code)
        {
            this.code = code;
            return this;
        }
        public CountryBuilder WithSportId(int sportId)
        {
            this.sportId = sportId;
            return this;
        }
        public CountryBuilder WithProviderId(int providerId)
        {
            this.providerId = providerId;
            return this;
        }
        public CountryBuilder WithBetContext(int bBRegionId, int mappingAgentId, DateTime mappedAt)
        {
            this.bBRegionId = bBRegionId;
            this.mappingAgentId = mappingAgentId;
            this.mappedAt = mappedAt;
            return this;
        }

        public static implicit operator Country(CountryBuilder instance)
        {
            return instance.Build();
        }
    }
}
