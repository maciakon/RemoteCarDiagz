FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY Client Client
COPY Shared Shared
RUN dotnet build "Client/RemoteCarDiagz.Client.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Client/RemoteCarDiagz.Client.csproj" -c Release -o /app/publish

FROM nginx:stable AS final
WORKDIR /usr/share/nginx/html
COPY --from=publish /app/publish/wwwroot .
COPY Client/Nginx/nginx.conf /etc/nginx/nginx.conf