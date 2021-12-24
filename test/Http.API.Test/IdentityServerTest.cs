using IdentityModel.Client;
using Newtonsoft.Json.Linq;
using static IdentityModel.OidcConstants;

namespace Http.API.Test;
public class IdentityServerTest
{
    public string? AccessToken { get; set; }

    [Fact]
    public async Task Should_DiscoveryIdentityServerAsync()
    {
        var client = new HttpClient();
        var disco = await client.GetDiscoveryDocumentAsync("https://localhost:5001");
        Assert.False(disco.IsError);
    }


    [Fact]
    public async Task Should_GetTokenAsync()
    {
        var client = new HttpClient();
        var disco = await client.GetDiscoveryDocumentAsync("https://localhost:5001");
        var tokenResponse = await client.RequestClientCredentialsTokenAsync(new ClientCredentialsTokenRequest
        {
            Address = disco.TokenEndpoint,
            ClientId = "http.api",
            ClientSecret = "511536EF-F270-4058-80CA-1C89C192F69A",
            Scope = "api"
        });

        Assert.False(tokenResponse.IsError);
    }

    [Fact]
    public async Task Should_CallAuthorizationAPI()
    {
        await GetAccessTokenAsync();
        var apiClient = new HttpClient();
        apiClient.SetBearerToken(AccessToken);
        var response = await apiClient.GetAsync("http://localhost:5002/api/testAuth");
        Assert.True(response.IsSuccessStatusCode);
    }


    [Fact]
    public async Task Should_CallAuthorizationAPIScope()
    {
        await GetAccessTokenAsync();
        var apiClient = new HttpClient();
        apiClient.SetBearerToken(AccessToken);
        var response = await apiClient.GetAsync("http://localhost:5002/api/testAuthApiScope");
        Assert.True(response.IsSuccessStatusCode);
    }

    protected async Task GetAccessTokenAsync()
    {
        var client = new HttpClient();
        var disco = await client.GetDiscoveryDocumentAsync("https://localhost:5001");
        var tokenResponse = await client.RequestClientCredentialsTokenAsync(new ClientCredentialsTokenRequest
        {
            Address = disco.TokenEndpoint,
            ClientId = "http.api",
            ClientSecret = "511536EF-F270-4058-80CA-1C89C192F69A",
            Scope = "api"
        });
        AccessToken = tokenResponse.AccessToken;
    }

}
