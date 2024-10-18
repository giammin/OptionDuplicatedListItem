using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

var apiSection = builder.Configuration.GetSection(ApiConfig.SectionName);
builder.Services.AddOptions<ApiConfig>().Bind(apiSection);

var app = builder.Build();

app.MapGet("/config", (IOptionsSnapshot<ApiConfig> config) => TypedResults.Ok(new { config.Value.Pricing }));

app.Run();

public record ApiConfig
{
    public const string SectionName = "ApiConfig";
    public required Pricing Pricing { get; init; } = null!;
}

public record Pricing(Dictionary<ProjectCategory, IEnumerable<ProjectPricingPlan>> Projects);

public record ProjectPricingPlan(string Name, int Limit, decimal Price);

public enum ProjectCategory { CatA, CatB, }