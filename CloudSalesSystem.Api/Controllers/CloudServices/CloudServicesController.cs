﻿using CloudSalesSystem.Application.CloudServices.OrderLicense;

namespace CloudSalesSystem.Api.Controllers.CloudServices;

[Route("api/[controller]")]
[ApiController]
public class CloudServicesController : ControllerBase
{
    private readonly ISender _sender;

    public CloudServicesController(ISender sender)
    {
        _sender = sender;
    }

    [HttpGet]
    public async Task<IActionResult> GetServices(CancellationToken cancellationToken)
    {
        var result = await _sender.Send(new GetCloudServicesQuery(), cancellationToken);
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> OrderServiceLicense([FromBody] OrderLicenseCommand request,
        CancellationToken cancellationToken)
    {
        var result = await _sender.Send(request, cancellationToken);
        return Ok(result);
    }
}