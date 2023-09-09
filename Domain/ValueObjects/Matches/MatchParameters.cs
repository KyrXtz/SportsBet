namespace SportsBet.Domain.ValueObjects.Matches
{
    public class MatchParameters : ValueObject
    {
        //public string NeutrualGround { get; private set; }
        //public string HomeAdvantageId { get; private set; }
        //public string ScountConfirmed { get; private set; }
        //public string Booked { get; private set; }

        internal MatchParameters()
        {
        }

        public static MatchParameters Create()
        {
            return new MatchParameters();
        }

        protected override void Validate()
        {
            throw new NotImplementedException();
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return null;
        }
    }    
    
}
