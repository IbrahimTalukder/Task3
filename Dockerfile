# Build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

WORKDIR /app

COPY . .

RUN dotnet restore

RUN dotnet publish -c Release -o /app/out


# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:8.0

WORKDIR /app

# Disable file watcher issue on Render
ENV DOTNET_USE_POLLING_FILE_WATCHER=1

COPY --from=build /app/out .

ENTRYPOINT ["dotnet", "Task3.dll"]