FROM mcr.microsoft.com/dotnet/aspnet:7.0-bullseye-slim as base
WORKDIR /app
EXPOSE 80
ENV ASPNETCORE_URLS=http://*:5001

FROM mcr.microsoft.com/dotnet/sdk:7.0 as build
WORKDIR /src
COPY Shared Shared
COPY Server Server
RUN dotnet restore "Server/RemoteCarDiagz.Server.csproj"
RUN dotnet restore "Shared/RemoteCarDiagz.Shared.csproj"
RUN dotnet build "Server/RemoteCarDiagz.Server.csproj" -c Release -o /app/build

FROM build as publish
RUN dotnet publish "Server/RemoteCarDiagz.Server.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "RemoteCarDiagz.Server.dll"]