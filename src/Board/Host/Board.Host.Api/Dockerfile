FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
COPY . /app
WORKDIR /app/src/Board/Host/Board.Host.Api
RUN dotnet restore
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS runtime
WORKDIR /app
COPY --from=build /app/Board/Host/Board.Host.Api/out ./
ENTRYPOINT ["dotnet", "Advertisement.PublicApi.dll"]