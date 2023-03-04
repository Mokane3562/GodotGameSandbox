namespace Item;

public interface IItemizable
{
    public uint Id { get; }
    public string Name { get; }
    public string Description { get; }
    public float UnitWeight { get; }
    public float UnitValue { get; }
    public bool IsUnique { get; }
    public uint MaxStackSize { get; }
    public bool IsDestroyable { get; }

    public Action Use { get; }
}