FROM mcr.microsoft.com/dotnet/aspnet:5.0
COPY bin/Release/net5.0/publish/ Server/
WORKDIR /Server
EXPOSE 5001
ENV ASPNETCORE_URLS=http://*:5001
ENTRYPOINT ["dotnet", "RemoteCarDiagz.Server.dll"]