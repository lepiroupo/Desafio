#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["src/Desafio.Api/Desafio.Api.csproj", "src/Desafio.Api/"]
COPY ["src/Desafio.Repository/Desafio.Repository.csproj", "src/Desafio.Repository/"]
COPY ["src/Desafio.Domain/Desafio.Domain.csproj", "src/Desafio.Domain/"]
COPY ["src/Desafio.App/Desafio.App.csproj", "src/Desafio.App/"]
COPY ["src/Desafio.ExchangeRates.Proxy/Desafio.ExchangeRates.Proxy.csproj", "src/Desafio.ExchangeRates.Proxy/"]
COPY ["src/Desafio.Cache/Desafio.Cache.csproj", "src/Desafio.Cache/"]
COPY ["src/Desafio.Message/Desafio.Message.csproj", "src/Desafio.Message/"]
COPY ["src/Desafio.Api.Model/Desafio.Api.Model.csproj", "src/Desafio.Api.Model/"]
RUN dotnet restore "src/Desafio.Api/Desafio.Api.csproj"
COPY . .
WORKDIR "/src/src/Desafio.Api"
RUN dotnet build "Desafio.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Desafio.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Desafio.Api.dll"]