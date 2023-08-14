using System.Net;
using CloudSalesSystem.Application.Abstractions.CloudServices.Models;
using RichardSzalay.MockHttp;

namespace CloudSalesSystem.Infrastructure.CloudComputing.Mock;

public class CloudComputingHttpClient
{
    public HttpClient GetHttpClientMock()
    {
        var handlerMock = new MockHttpMessageHandler();
        handlerMock.When($"https://api.cloudcomputingprovider/services/get-all")
            .Respond(
                HttpStatusCode.OK,
                JsonContent.Create(GetAvailableServicesMockResponse()));

        return handlerMock.ToHttpClient();
    }

    public HttpClient GetHttpClientMock(Guid serviceId, int amount)
    {
        var handlerMock = new MockHttpMessageHandler();
        var service = GetAvailableServicesMockResponse().FirstOrDefault(service => service.Id == serviceId);

        if (service is not null)
        {
            handlerMock.When($"https://api.cloudcomputingprovider/services/order?id={serviceId}&amount={amount}")
                .Respond(
                    HttpStatusCode.OK,
                    JsonContent.Create(new OrderServiceItemResponse(
                        Guid.NewGuid(), 
                        DateTime.Now,
                        serviceId, 
                        amount,
                        service.Price,
                        amount * service.Price)));
        }
        else
        {
            handlerMock.When($"https://api.cloudcomputingprovider/services/order?id={serviceId}&amount={amount}")
                .Respond(HttpStatusCode.NotFound, JsonContent.Create(new { }));
        }

        return handlerMock.ToHttpClient();
    }

    private static IReadOnlyCollection<AvailableServiceItem> GetAvailableServicesMockResponse() =>
        new List<AvailableServiceItem>
        {
            new(Guid.Parse("E913C473-25A3-49AA-A80E-D62DA922CA5E"), "Service_1", "Description_1", 415m),
            new(Guid.Parse("EA13C473-25A3-49AA-A80E-D62DA922CA5E"), "Service_2", "Description_2", 746m),
            new(Guid.Parse("EB13C473-25A3-49AA-A80E-D62DA922CA5E"), "Service_3", "Description_3", 215m),
            new(Guid.Parse("EC13C473-25A3-49AA-A80E-D62DA922CA5E"), "Service_4", "Description_4", 632m),
            new(Guid.Parse("ED13C473-25A3-49AA-A80E-D62DA922CA5E"), "Service_5", "Description_5", 823m),
            new(Guid.Parse("EE13C473-25A3-49AA-A80E-D62DA922CA5E"), "Service_6", "Description_6", 492m),
            new(Guid.Parse("EF13C473-25A3-49AA-A80E-D62DA922CA5E"), "Service_7", "Description_7", 158m),
            new(Guid.Parse("F013C473-25A3-49AA-A80E-D62DA922CA5E"), "Service_8", "Description_8", 673m),
            new(Guid.Parse("F113C473-25A3-49AA-A80E-D62DA922CA5E"), "Service_9", "Description_9", 512m),
            new(Guid.Parse("F213C473-25A3-49AA-A80E-D62DA922CA5E"), "Service_10", "Description_10", 289m),
            new(Guid.Parse("F313C473-25A3-49AA-A80E-D62DA922CA5E"), "Service_11", "Description_11", 638m),
            new(Guid.Parse("F413C473-25A3-49AA-A80E-D62DA922CA5E"), "Service_12", "Description_12", 419m),
            new(Guid.Parse("F513C473-25A3-49AA-A80E-D62DA922CA5E"), "Service_13", "Description_13", 749m),
            new(Guid.Parse("F613C473-25A3-49AA-A80E-D62DA922CA5E"), "Service_14", "Description_14", 589m),
            new(Guid.Parse("F713C473-25A3-49AA-A80E-D62DA922CA5E"), "Service_15", "Description_15", 741m),
            new(Guid.Parse("F813C473-25A3-49AA-A80E-D62DA922CA5E"), "Service_16", "Description_16", 123m),
            new(Guid.Parse("F913C473-25A3-49AA-A80E-D62DA922CA5E"), "Service_17", "Description_17", 572m),
            new(Guid.Parse("FA13C473-25A3-49AA-A80E-D62DA922CA5E"), "Service_18", "Description_18", 639m),
            new(Guid.Parse("FB13C473-25A3-49AA-A80E-D62DA922CA5E"), "Service_19", "Description_19", 205m),
            new(Guid.Parse("FC13C473-25A3-49AA-A80E-D62DA922CA5E"), "Service_20", "Description_20", 432m),
        };
}