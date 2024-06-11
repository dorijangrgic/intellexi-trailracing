# Stage 1: Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# Copy the entire source directory to the container
COPY /backend/src/ .

# Set the working directory to the CommandService project directory
WORKDIR /src/Intellexi.TrailRacing.CommandService

# Restore dependencies for the CommandService project
RUN dotnet restore "Intellexi.TrailRacing.CommandService.csproj"

# Build the project
RUN dotnet build "Intellexi.TrailRacing.CommandService.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Publish the project
RUN dotnet publish "Intellexi.TrailRacing.CommandService.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Stage 2: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app

# Copy the published files from the build stage
COPY --from=build /app/publish .

# Expose the port
EXPOSE 8080

# Define the entry point for the container
ENTRYPOINT ["dotnet", "Intellexi.TrailRacing.CommandService.dll"]
