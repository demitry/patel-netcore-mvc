namespace DIServiceLifetime.Services
{
    public class TransientGuidService : ITransientGuidService
    {
        public TransientGuidService()
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
