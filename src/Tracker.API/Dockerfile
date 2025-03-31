FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/Tracker.API/Tracker.API.csproj", "src/Tracker.API/"]
COPY ["src/Tracker.Infrastructure/Tracker.Infrastructure.csproj", "src/Tracker.Infrastructure/"]
COPY ["src/Tracker.Domain/Tracker.Domain.csproj", "src/Tracker.Domain/"]
COPY ["src/Tracker.Application/Tracker.Application.csproj", "src/Tracker.Application/"]
RUN dotnet restore "src/Tracker.API/Tracker.API.csproj"
COPY . .
WORKDIR "/src/src/Tracker.API"
RUN dotnet build "Tracker.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "Tracker.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Tracker.API.dll"]
