namespace PGGame;

public class Exercise13
{
    public void RunGame()
    {
        Console.Clear();
        Console.Title = "Soup Shop";
        (Form form, Ingredient ingredient, Flavor flavor) soup = (Form.Soup, Ingredient.Mushroom, Flavor.Cayenne);
        Console.WriteLine($"Soup of the day: {soup.form} with {soup.ingredient} and {soup.flavor} flavor.");
        do
        { 
            GetOrder();
        } while (HelperFunctions.PlayAgain("Do you want to order another soup? [y] / [n]"));
    }

    private void GetOrder()
    {
        Console.WriteLine("\nWhat soup do you want?");
        int soup = HelperFunctions.GetNumber($"Do you want 1 {Form.Stew}, 2 {Form.Soup} or 3 {Form.Curry}?", 1, 3);
        int ingredient = HelperFunctions.GetNumber($"Do you want 1 {Ingredient.Mushroom}, 2 {Ingredient.Carrot} or 3 {Ingredient.Chicken}?", 1, 3);
        int flavor = HelperFunctions.GetNumber($"Do you want flavor 1 {Flavor.Garlic}, 2 {Flavor.Cayenne} or 3 {Flavor.Ginger}?", 1, 3);

        Form orderedForm = soup switch
        {
            1 => Form.Stew,
            2 => Form.Soup,
            3 => Form.Curry
        };
        Ingredient orderedIngredient = ingredient switch
        {
            1 => Ingredient.Mushroom,
            2 => Ingredient.Carrot,
            3 => Ingredient.Chicken
        };
        Flavor orderedFlavor = flavor switch
        {
            1 => Flavor.Garlic,
            2 => Flavor.Cayenne,
            3 => Flavor.Ginger
        };
        
        Console.WriteLine($"Your soup: {orderedForm} with {orderedIngredient} and {orderedFlavor} flavor.");;
    }
    
    private enum Form
    {
        Stew,
        Soup,
        Curry
    };

    private enum Ingredient
    {
        Mushroom,
        Chicken,
        Carrot
    };

    private enum Flavor
    {
        Garlic,
        Cayenne,
        Ginger
    };
}