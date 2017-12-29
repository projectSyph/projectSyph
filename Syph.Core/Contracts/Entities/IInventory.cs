namespace Syph.Core.Contracts
{
    public interface IInventory
    {
        ISpawn[][] PlayerInventory { get; }
    }
}