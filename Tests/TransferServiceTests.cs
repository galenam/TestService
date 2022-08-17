using System;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

public class TransferServiceTests
{
    readonly TransferService _transferService;
    public TransferServiceTests()
    {
        var mockLogger = new Mock<ILogger<TransferService>>();
        _transferService = new TransferService(mockLogger.Object);
        _transferService.Create("{\"id\":\"cfaa0d3f-7fea-4423-9f69-ebff826e2f92\",\"operationDate\":\"2019-04-02T13:10:20.0263632+03:00\",\"amount\":23.05}");
    }

    [Fact]
    public void CreateTestSuccess()
    {
        var json = "{\"id\":\"cfaa0d3f-7fea-4423-9f69-ebff826e2f89\",\"operationDate\":\"2019-04-02T13:10:20.0263632+03:00\",\"amount\":23.05}";
        var result = _transferService.Create(json);
        Assert.NotNull(result);
    }

    [Fact]
    public void CreateTestFail()
    {
        var json = "{\"id\":\"cfaa0d3f-7fea-4423-9f69-ebff826e2f\",\"operationDate\":\"2019-04-02T13:10:20.0263632+03:00\",\"amount\":23.05}";
        var result = _transferService.Create(json);
        Assert.Null(result);
    }

    [Fact]
    public void GetTestSuccess()
    {
        var entity = new Entity
        {
            Id = new Guid("cfaa0d3f-7fea-4423-9f69-ebff826e2f93"),
            OperationDate = new DateTime(2022, 8, 18, 0, 0, 0, 0, DateTimeKind.Local),
            Amount = 123.45M
        };
        var json = _transferService.Transfer(entity);
        Assert.Equal("{\"id\":\"cfaa0d3f-7fea-4423-9f69-ebff826e2f93\",\"operationDate\":\"2022-08-18T00:00:00.0000000+03:00\",\"amount\":123.45}",
            json);
    }
}