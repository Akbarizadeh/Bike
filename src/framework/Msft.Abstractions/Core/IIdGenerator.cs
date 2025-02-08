namespace MsftFramework.Abstractions.Core;

public interface IIdGenerator<out TId>
{
    TId New();
}
