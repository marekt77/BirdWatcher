#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim-arm32v7 AS base
WORKDIR /app
EXPOSE 5000/tcp

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["BirdWatcherWeb/BirdWatcherWeb.csproj", "BirdWatcherWeb/"]
RUN dotnet restore "BirdWatcherWeb/BirdWatcherWeb.csproj" -r linux-arm
COPY . .
WORKDIR "/src/BirdWatcherWeb"
RUN dotnet build "BirdWatcherWeb.csproj" -c Release -o /app/build -r linux-arm

FROM build AS publish
RUN dotnet publish "BirdWatcherWeb.csproj" -c Release -o /app/publish -r linux-arm

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

ENV ASPNETCORE_URLS http://*:5000
ENV ASPNETCORE_ENVIRONMENT docker

ENTRYPOINT ["dotnet", "BirdWatcherWeb.dll"]