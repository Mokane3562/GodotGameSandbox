namespace Item;

public record ExampleItem() : BaseItem(
    0x0000000,
    "Example Item",
    "Just an example that does nothing",
    0,
    0,
    false,
    ItemConstants.StackSizeLimit,
    false,
    () => { });