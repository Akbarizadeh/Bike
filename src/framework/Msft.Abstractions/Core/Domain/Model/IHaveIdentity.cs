namespace MsftFramework.Abstractions.Core.Domain.Model;

public interface IHaveIdentity<out TId> : IHaveIdentity
{
    new TId Id { get; }
    object IHaveIdentity.Id => Id!;
}

public interface IHaveIdentity
{
    object Id { get; }
}
