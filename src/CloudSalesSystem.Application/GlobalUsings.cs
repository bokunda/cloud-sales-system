// Global using directives

global using System.Data;
global using AutoMapper;
global using CloudSalesSystem.Application.Abstractions.CloudServices;
global using CloudSalesSystem.Application.Abstractions.CloudServices.Models;
global using CloudSalesSystem.Application.Abstractions.Data;
global using CloudSalesSystem.Application.Behaviors;
global using CloudSalesSystem.Application.CloudServices.GetCloudServiceDetails;
global using CloudSalesSystem.Application.CloudServices.GetCloudServices;
global using CloudSalesSystem.Application.CloudServices.OrderLicense;
global using CloudSalesSystem.Application.Exceptions;
global using CloudSalesSystem.Application.Licenses.AssignLicense;
global using CloudSalesSystem.Application.Licenses.RevokeLicense;
global using CloudSalesSystem.Application.Paging;
global using CloudSalesSystem.Application.SubscriptionItems.UpdateQuantity;
global using CloudSalesSystem.Domain.Abstractions;
global using CloudSalesSystem.Domain.Identity;
global using CloudSalesSystem.Domain.Licenses;
global using CloudSalesSystem.Domain.Repositories;
global using CloudSalesSystem.Domain.SubscriptionItems;
global using Dapper;
global using FluentValidation;
global using FluentValidation.AspNetCore;
global using MediatR;
global using Microsoft.Extensions.DependencyInjection;
global using Microsoft.Extensions.Logging;