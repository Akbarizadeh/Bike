using MsftFramework.Abstractions.Core.Domain.Model;

namespace MsftFramework.Core.Domain.Model;

public class AuditableEntity<TId> : Entity<TId>, IAuditableEntity<TId>
{
    public DateTime? LastModified { get; protected set; }
    public int? LastModifiedBy { get; protected set; }
}

public abstract class AuditableEntity<TIdentity, TId> : AuditableEntity<TIdentity>
    where TIdentity : Identity<TId>
{
}

public class AuditableEntity : AuditableEntity<Identity<long>, long>
{
}
