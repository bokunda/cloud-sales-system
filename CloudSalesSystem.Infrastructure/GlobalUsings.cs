// Global using directives

global using System.Data;
global using System.Net.Http.Json;
global using CloudSalesSystem.Application.Abstractions.Clock;
global using CloudSalesSystem.Application.Abstractions.CloudComputing;
global using CloudSalesSystem.Application.Abstractions.CloudComputing.Models;
global using CloudSalesSystem.Application.Abstractions.Data;
global using CloudSalesSystem.Application.Exceptions;
global using CloudSalesSystem.Domain.Abstractions;
global using CloudSalesSystem.Domain.Accounts;
global using CloudSalesSystem.Domain.Customers;
global using CloudSalesSystem.Domain.CustomerSubscriptions;
global using CloudSalesSystem.Domain.Licenses;
global using CloudSalesSystem.Domain.Products;
global using CloudSalesSystem.Domain.SubscriptionItems;
global using CloudSalesSystem.Domain.Subscriptions;
global using CloudSalesSystem.Infrastructure.Clock;
global using CloudSalesSystem.Infrastructure.CloudComputing;
global using CloudSalesSystem.Infrastructure.CloudComputing.Mock;
global using CloudSalesSystem.Infrastructure.Data;
global using Dapper;
global using MediatR;
global using Microsoft.EntityFrameworkCore;
global using Microsoft.EntityFrameworkCore.Metadata.Builders;
global using Microsoft.Extensions.Configuration;
global using Microsoft.Extensions.DependencyInjection;
global using Newtonsoft.Json;
global using Npgsql;