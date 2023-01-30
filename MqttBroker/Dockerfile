#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

#FROM mcr.microsoft.com/dotnet/runtime:7.0 AS base
# WORKDIR /app

FROM mcr.microsoft.com/dotnet/aspnet:7.0-bullseye-slim as base
WORKDIR /app
EXPOSE 1883
ENV ASPNETCORE_URLS=http://*:1883

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY . .
RUN dotnet restore "MqttBroker/RemoteCarDiagz.MqttBroker.csproj"
WORKDIR "/src/MqttBroker"
RUN dotnet build "RemoteCarDiagz.MqttBroker.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "RemoteCarDiagz.MqttBroker.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "RemoteCarDiagz.MqttBroker.dll"]