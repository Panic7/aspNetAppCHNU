FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["WebApi/EventMicroservice.WebApi.csproj", "WebApi/"]
RUN dotnet restore "WebApi\EventMicroservice.WebApi.csproj"
COPY . .
WORKDIR "/src/WebApi"
RUN dotnet build "EventMicroservice.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "EventMicroservice.WebApi.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "EventMicroservice.WebApi.dll"]
