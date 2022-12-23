namespace BalazorRealtimeCharts.Shared;

public record MealItem(string Name, int Count, MealCategory Category);

public enum MealCategory
{
  Lasagne,
  Pasta,
  Pizza,
  Salad
}
