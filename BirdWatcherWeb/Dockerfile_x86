#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["BirdWatcherWeb/BirdWatcherWeb.csproj", "BirdWatcherWeb/"]
RUN dotnet restore "BirdWatcherWeb/BirdWatcherWeb.csproj"
COPY . .
WORKDIR "/src/BirdWatcherWeb"
RUN dotnet build "BirdWatcherWeb.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BirdWatcherWeb.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

ENV ASPNETCORE_URLS http://*:5000
ENV ASPNETCORE_ENVIRONMENT docker

ENTRYPOINT ["dotnet", "BirdWatcherWeb.dll"]