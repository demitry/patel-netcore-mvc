namespace DIServiceLifetime.Services
{
    public class ScopedGuidService : IScopedGuidService
    {
        public ScopedGuidService()
        {
            Id = Guid.NewGuid();
        }

        private Guid Id { get; }

        public string GetGuid()
        {
            return Id.ToString();
        }
    }
}
