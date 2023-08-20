namespace DIServiceLifetime.Services
{
    public class SingletonGuidService : ISingletonGuidService
    {
        public SingletonGuidService()
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
