Console.WriteLine("Roman Koshchei IPZ-12-1");
Console.WriteLine("Variant 14 (1 in list)");
Console.WriteLine("Study Email: romankoshchey@gmail.com");
Console.WriteLine("Lab work 6");

public record Food(string Name, int Calories);

public class SmartRefrigerator
{
    private List<Food> foods = [];

    public void PutFood(Food food)
    {
        foods.Add(food);
    }

    public Food? GetFood(string name)
    {
        return foods.FirstOrDefault(x => x.Name == name);
    }
}