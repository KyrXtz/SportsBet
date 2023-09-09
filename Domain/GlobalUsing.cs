﻿global using IdGen;
global using Ardalis.Specification;
global using SportsBet.Domain.SeedWork;
global using MediatR;
global using Ardalis.GuardClauses;
global using SportsBet.Domain.Aggregates;
global using SportsBet.Domain.ValueObjects;
global using Ardalis.SmartEnum;
global using SportsBet.Domain.Enums;
global using SportsBet.Domain.Aggregates.IntegrationEventOutbox;
global using SportsBet.Domain.Enums.Players;
global using SportsBet.Domain.ValueObjects.Players;
global using SportsBet.Domain.Enums.Matches;
global using SportsBet.Domain.ValueObjects.Matches;
global using SportsBet.Domain.ValueObjects.Competitors;
global using SportsBet.Domain.ValueObjects.Countries;
global using SportsBet.Domain.ValueObjects.EventLogs;
global using SportsBet.Domain.ValueObjects.Leagues;
global using SportsBet.Domain.ValueObjects.Series;
global using SportsBet.Domain.ValueObjects.Sports;
global using SportsBet.Domain.Aggregates.Competitors;
global using SportsBet.Domain.Aggregates.Matches;
global using SportsBet.Domain.Aggregates.Countries;
global using SportsBet.Domain.Aggregates.Sports;
global using SportsBet.Domain.Aggregates.Leagues;
global using SportsBet.Domain.Aggregates.Players;
global using SportsBet.Domain.Aggregates.Series;
global using SportsBet.Domain.Events.Series;
global using SportsBet.Domain.Events.Sports;
global using SportsBet.Domain.Events.Competitors;
global using SportsBet.Domain.Events.Matches;
global using SportsBet.Domain.Events.Countries;
global using SportsBet.Domain.Events.Leagues;
global using SportsBet.Domain.Events.Players;
global using SportsBet.Domain.Enums.EventLogs;
global using System.ComponentModel.DataAnnotations.Schema;
global using Newtonsoft.Json;
global using SportsBet.Domain.Enums.Squads;
global using SportsBet.Domain.ValueObjects.Squads;
global using SportsBet.Domain.Aggregates.Squads;
global using SportsBet.Domain.Aggregates.MatchEvents;
global using SportsBet.Domain.Events.MatchesEvents;
global using SportsBet.Domain.ValueObjects.ErroredCommandsLog;