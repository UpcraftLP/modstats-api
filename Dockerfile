# syntax=docker.io/dockerfile:1
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["ModStats.API.csproj", "./"]
RUN dotnet restore "ModStats.API.csproj"
COPY . .
RUN dotnet build "ModStats.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ModStats.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app

COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ModStats.API.dll"]
