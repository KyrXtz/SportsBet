namespace SportsBet.Domain.Specifications.Competitors
{
    public class GetCompetitorsByIdsSpecification : Specification<Competitor>
    {
        public GetCompetitorsByIdsSpecification(params int[] ids)
        {
            Query.Where(t => ids.Contains(t.Id));
        }

        public GetCompetitorsByIdsSpecification(bool isIndividual, params int[] ids)
        {
            Query.Where(t => t.IsIndividual == isIndividual && ids.Contains(t.Id));
        }

        public GetCompetitorsByIdsSpecification(bool isIndividual, bool isMapped, params int[] ids)
        {
            Query.Where(t => t.IsIndividual == isIndividual && t.BetContext.MappedAt.HasValue == isMapped && ids.Contains(t.Id));
        }

    }
}