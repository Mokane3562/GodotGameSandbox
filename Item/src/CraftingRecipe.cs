namespace Item;

public record CraftingRecipe(Dictionary<IItemizable,int> Recipe);