namespace SportsBet.Domain.Specifications.EventLogs
{
    public class GetNotCompletedIntegrationEventOutboxItemsSpecification : Specification<IntegrationEventOutboxItem>
    {
        public GetNotCompletedIntegrationEventOutboxItemsSpecification()
        {
            Query.Where(p => p.Status != IntegrationEventOutboxItemStatus.Published && p.Status != IntegrationEventOutboxItemStatus.InProgress && p.Status != IntegrationEventOutboxItemStatus.Failed).OrderBy(p => p.CreatedOn);
        }
    }
}

