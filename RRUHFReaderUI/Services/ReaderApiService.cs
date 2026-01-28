using System.Net.Http.Json;
using RRUHFReaderUI.Models;

namespace RRUHFReaderUI.Services;

public class ReaderApiService
{
    private readonly IHttpClientFactory _httpClientFactory;

    public ReaderApiService(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    private HttpClient CreateClient() => _httpClientFactory.CreateClient("API");

    // Command methods
    public async Task<CommandResponse?> SendInventoryCommand(string address, int port = 8888)
    {
        var client = CreateClient();
        var response = await client.PostAsJsonAsync("/api/commands/inventory", 
            new CommandRequest(address, port));
        return await response.Content.ReadFromJsonAsync<CommandResponse>();
    }

    public async Task<CommandResponse?> GetDeviceInfo(string address, int port = 8888)
    {
        var client = CreateClient();
        var response = await client.PostAsJsonAsync("/api/commands/device-info", 
            new CommandRequest(address, port));
        return await response.Content.ReadFromJsonAsync<CommandResponse>();
    }

    public async Task<CommandResponse?> ConnectToReader(string address, int port = 8888)
    {
        var client = CreateClient();
        var response = await client.PostAsJsonAsync("/api/commands/connect", 
            new CommandRequest(address, port));
        return await response.Content.ReadFromJsonAsync<CommandResponse>();
    }

    // Query methods
    public async Task<List<ReaderDto>> GetReadersAsync()
    {
        var client = CreateClient();
        return await client.GetFromJsonAsync<List<ReaderDto>>("/api/readers") ?? new();
    }

    public async Task<List<TagDto>> GetTagsAsync(int? readerId = null)
    {
        var client = CreateClient();
        var url = readerId.HasValue ? $"/api/tags?readerId={readerId}" : "/api/tags";
        return await client.GetFromJsonAsync<List<TagDto>>(url) ?? new();
    }

    public async Task<List<TagTransactionDto>> GetTransactionsAsync(int? tagId = null, int? readerId = null, int limit = 100)
    {
        var client = CreateClient();
        var query = new List<string>();
        if (tagId.HasValue) query.Add($"tagId={tagId}");
        if (readerId.HasValue) query.Add($"readerId={readerId}");
        query.Add($"limit={limit}");
        
        var url = $"/api/transactions?{string.Join("&", query)}";
        return await client.GetFromJsonAsync<List<TagTransactionDto>>(url) ?? new();
    }

    public async Task<StatsSummary?> GetStatsSummaryAsync()
    {
        var client = CreateClient();
        return await client.GetFromJsonAsync<StatsSummary>("/api/stats/summary");
    }
}
