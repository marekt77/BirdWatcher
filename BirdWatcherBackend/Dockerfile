FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build-env
WORKDIR /app
EXPOSE 5000/tcp

# copy csproj and restore as distinct layer
COPY BirdWatcherBackend.csproj ./
RUN dotnet restore

#Copy everything else and build
COPY . ./
RUN dotnet publish "BirdWatcherBackend.csproj" -c Release -r linux-arm -o out

#Build runtime image
FROM microsoft/dotnet:2.2-aspnetcore-runtime-stretch-slim-arm32v7
WORKDIR /app
COPY --from=build-env /app/out .

ENV ASPNETCORE_URLS http://*:5000
ENV ASPNETCORE_ENVIRONMENT docker

ENTRYPOINT ["dotnet", "BirdWatcherBackend.dll"]