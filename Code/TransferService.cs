using System;
using System.Text.Json;
using Microsoft.Extensions.Logging;

public class TransferService : ITransferService
{
    static readonly JsonSerializerOptions _options;
    readonly ILogger<TransferService> _logger;
    static TransferService()
    {
        _options = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping
        };
        _options.Converters.Add(new DateTimeConverter());
    }

    public TransferService(ILogger<TransferService> logger)
    {
        _logger = logger;
    }

    public Entity Create(string json)
    {
        try
        {
            return JsonSerializer.Deserialize<Entity>(json, _options);
        }
        catch (Exception ex)
        {
            _logger.LogInformation(ex, "Wrong json");
        }
        return null;
    }

    public string Transfer(Entity e)
    {
        return JsonSerializer.Serialize(e, _options);
    }
}