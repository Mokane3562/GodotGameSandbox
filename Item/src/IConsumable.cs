namespace Item;

public interface IConsumable
{
    public uint UsesRemaining { get; }
    public Action EffectOnConsume { get; }
}