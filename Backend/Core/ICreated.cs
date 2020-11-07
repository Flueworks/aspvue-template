using NodaTime;

namespace Core
{
    /// <summary>
    /// Automatic update of Created property on save
    /// </summary>
    public interface ICreated
    {
        public Instant Created { get; set; }
    }

    /// <summary>
    /// Automatic update of Update property on save
    /// </summary>
    public interface IUpdated
    {
        public Instant Updated { get; set; }
    }
}