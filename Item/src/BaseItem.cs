namespace Item;

public record BaseItem(
    uint Id,
    string Name,
    string Description,
    float UnitWeight,
    float UnitValue,
    bool IsUnique,
    uint MaxStackSize,
    bool IsDestroyable,
    Action Use) : IItemizable;
