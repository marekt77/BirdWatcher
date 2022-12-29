#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 5000/tcp

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
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