using BalazorRealtimeCharts.Shared;

namespace BalazorRealtimeCharts.Server.Providers;

public static class MealDataProvider
{
    public static IEnumerable<MealItem> GetMealItems()
    {
        var rand = new Random();

        return new List<MealItem>()
        {
            new("Margherita", rand.Next(1, 80), MealCategory.Pizza),
            new("Funghi", rand.Next(1, 80), MealCategory.Pizza),
            new("Salami", rand.Next(1, 80), MealCategory.Pizza),
            new("Mista", rand.Next(1, 80), MealCategory.Pizza),
            new("Frutti di Mare", rand.Next(1, 80), MealCategory.Pizza),
            new("Tonno", rand.Next(1, 80), MealCategory.Pizza),
            new("Spinaci", rand.Next(1, 80), MealCategory.Pizza),
            new("Diavola", rand.Next(1, 80), MealCategory.Pizza),
            new("Vegetarin", rand.Next(1, 80), MealCategory.Pizza),
            new("Pomodoro", rand.Next(1, 80), MealCategory.Pasta),
            new("Arrabbiata", rand.Next(1, 80), MealCategory.Pasta),
            new("Carbonara", rand.Next(1, 80), MealCategory.Pasta),
            new("Vegetarin", rand.Next(1, 80), MealCategory.Pasta),
            new("Aglio olio", rand.Next(1, 80), MealCategory.Pasta),
            new("Bolognese", rand.Next(1, 80), MealCategory.Pasta),
            new("Caprese", rand.Next(1, 80), MealCategory.Salad),
            new("Mista", rand.Next(1, 80), MealCategory.Salad),
            new("Ceasar Salad", rand.Next(1, 80), MealCategory.Salad),
            new("Lasagne", rand.Next(1, 80), MealCategory.Lasagne),
            new("Lasagne vegetarian", rand.Next(1, 80), MealCategory.Lasagne),
            new("Lasagne quattro formaggi", rand.Next(1, 80), MealCategory.Lasagne),
        };
    }
}
