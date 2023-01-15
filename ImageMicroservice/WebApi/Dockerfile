FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["WebApi/ImageMicroservice.WebApi.csproj", "WebApi/"]
RUN dotnet restore "WebApi\ImageMicroservice.WebApi.csproj"
COPY . .
WORKDIR "/src/WebApi"
RUN dotnet build "ImageMicroservice.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ImageMicroservice.WebApi.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ImageMicroservice.WebApi.dll"]
