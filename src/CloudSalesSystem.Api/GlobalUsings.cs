// Global using directives

global using System.Reflection;
global using CloudSalesSystem.Api.Extensions;
global using CloudSalesSystem.Api.Health;
global using CloudSalesSystem.Api.Middleware;
global using CloudSalesSystem.Application;
global using CloudSalesSystem.Application.Abstractions.CloudServices;
global using CloudSalesSystem.Application.Abstractions.Data;
global using CloudSalesSystem.Application.Accounts.GetAccounts;
global using CloudSalesSystem.Application.CloudServices.GetCloudServices;
global using CloudSalesSystem.Application.CloudServices.OrderLicense;
global using CloudSalesSystem.Application.Exceptions;
global using CloudSalesSystem.Application.Licenses.AssignLicense;
global using CloudSalesSystem.Application.Licenses.RevokeLicense;
global using CloudSalesSystem.Infrastructure;
global using HealthChecks.UI.Client;
global using MediatR;
global using Microsoft.AspNetCore.Diagnostics.HealthChecks;
global using Microsoft.AspNetCore.Mvc;
global using Microsoft.EntityFrameworkCore;
global using Microsoft.Extensions.Diagnostics.HealthChecks;
global using Serilog;