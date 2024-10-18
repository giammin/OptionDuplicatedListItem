// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

const string json = """
           {
             "Pricing": {
               "Projects": {
                 "CatA": [
                   {
                     "Name": "Basic",
                     "Limit": 100,
                     "Price": 8.75
                   },
                   {
                     "Name": "Large",
                     "Limit": 500,
                     "Price": 19.5
                   }
                 ],
                 "CatB": [
                   {
                     "Name": "Basic",
                     "Limit": 100,
                     "Price": 280
                   },
                   {
                     "Name": "Large",
                     "Limit": 250,
                     "Price": 480
                   }
                 ]
               }
             }
           }
           """;

var config = System.Text.Json.JsonSerializer.Deserialize<ApiConfig>(json);

Console.WriteLine(System.Text.Json.JsonSerializer.Serialize(config));
public record ApiConfig
{
    public const string SectionName = "ApiConfig";
    public required Pricing Pricing { get; init; } = null!;
}

public record Pricing(Dictionary<ProjectCategory, IEnumerable<ProjectPricingPlan>> Projects);

public record ProjectPricingPlan(string Name, int Limit, decimal Price);

public enum ProjectCategory { CatA, CatB, }