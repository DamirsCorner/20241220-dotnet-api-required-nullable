using System.Net;
using System.Net.Http.Json;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;

namespace RequiredAndNullable.Tests;

public class RequiredTests
{
    private WebApplicationFactory<Program> factory;

    [SetUp]
    public void Setup()
    {
        factory = new WebApplicationFactory<Program>();
    }

    [TearDown]
    public void TearDown()
    {
        factory.Dispose();
    }

    [Test]
    public async Task CallEndpointWithBothFields()
    {
        using var httpClient = factory.CreateClient();

        var response = await httpClient.PostAsJsonAsync(
            "/Sample",
            new { Optional = "optional", Required = "required" }
        );

        response.Should().BeSuccessful();
        response
            .Content.ReadAsStringAsync()
            .Result.Should()
            .Be("""{"optional":"optional","required":"required"}""");
    }

    [Test]
    public async Task CallEndpointWithRequiredFieldOnly()
    {
        using var httpClient = factory.CreateClient();

        var response = await httpClient.PostAsJsonAsync("/Sample", new { Required = "required" });

        response.Should().BeSuccessful();
        response
            .Content.ReadAsStringAsync()
            .Result.Should()
            .Be("""{"optional":null,"required":"required"}""");
    }

    [Test]
    public async Task CallEndpointWithNoFields()
    {
        using var httpClient = factory.CreateClient();

        var response = await httpClient.PostAsJsonAsync("/Sample", new { });

        response.Should().HaveStatusCode(HttpStatusCode.BadRequest);
    }
}
