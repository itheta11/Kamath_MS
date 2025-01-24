# Stage 1: Build
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /app

# Copy the project file(s) and restore dependencies
COPY *.csproj .
RUN dotnet restore

# Copy the rest of the application files and build the app
COPY . .
RUN dotnet publish -c Release -o /app/out

# Stage 2: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS runtime
WORKDIR /app

# Copy the published output from the build stage
COPY --from=build /app/out .

# Expose the default port for ASP.NET Core
EXPOSE 80

# Specify the entry point for the application
ENTRYPOINT ["dotnet", "KamathResidency.dll"]
