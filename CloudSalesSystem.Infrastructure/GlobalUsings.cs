// Global using directives

global using System.Data;
global using System.Net;
global using System.Net.Http.Json;
global using CloudSalesSystem.Application.Abstractions.Clock;
global using CloudSalesSystem.Application.Abstractions.CloudServices;
global using CloudSalesSystem.Application.Abstractions.CloudServices.Models;
global using CloudSalesSystem.Application.Abstractions.Data;
global using CloudSalesSystem.Application.Exceptions;
global using CloudSalesSystem.Application.Licenses;
global using CloudSalesSystem.Domain.Abstractions;
global using CloudSalesSystem.Domain.Accounts;
global using CloudSalesSystem.Domain.Customers;
global using CloudSalesSystem.Domain.CustomerSubscriptions;
global using CloudSalesSystem.Domain.Licenses;
global using CloudSalesSystem.Domain.Repositories;
global using CloudSalesSystem.Domain.SubscriptionItems;
global using CloudSalesSystem.Domain.Subscriptions;
global using CloudSalesSystem.Infrastructure.Clock;
global using CloudSalesSystem.Infrastructure.CloudComputing;
global using CloudSalesSystem.Infrastructure.CloudComputing.Mock;
global using CloudSalesSystem.Infrastructure.Data;
global using CloudSalesSystem.Infrastructure.Repositories;
global using Dapper;
global using MediatR;
global using Microsoft.EntityFrameworkCore;
global using Microsoft.EntityFrameworkCore.Metadata.Builders;
global using Microsoft.Extensions.Caching.Memory;
global using Microsoft.Extensions.Configuration;
global using Microsoft.Extensions.DependencyInjection;
global using Npgsql;
global using RichardSzalay.MockHttp;