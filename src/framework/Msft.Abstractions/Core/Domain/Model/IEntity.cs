namespace MsftFramework.Abstractions.Core.Domain.Model;

public interface IEntity<out TId> : IHaveIdentity<TId>, IHaveCreator
{
}

public interface IEntity<out TIdentity, in TId> : IEntity<TIdentity>
    where TIdentity : IIdentity<TId>
{
}

public interface IEntity : IEntity<EntityId>
{
}
