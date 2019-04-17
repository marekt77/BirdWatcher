FROM microsoft/dotnet:2.2-sdk as builder

RUN mkdir -p /root/src/app
WORKDIR /root/src/app
#COPY ["BirdWatcherBackend/BirdWatcherBackend.csproj", "BirdWatcherBackend/"]
COPY . BirdWatcherBackend
WORKDIR /root/src/app/BirdWatcherBackend

RUN dotnet restore ./BirdWatcherBackend.csproj  
RUN dotnet publish -c release -o published -r linux-arm

EXPOSE 5000/tcp
ENV ASPNETCORE_URLS http://*:5000
ENV ASPNETCORE_ENVIRONMENT docker

FROM microsoft/dotnet:2.2-aspnetcore-runtime-stretch-slim-arm32v7

WORKDIR /root/  
COPY --from=builder /root/src/app/BirdWatcherBackend/published .

ENTRYPOINT ["dotnet", "BirdWatcherBackend.dll"]