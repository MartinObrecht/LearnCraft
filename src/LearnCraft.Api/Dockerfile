# Use a .NET 7.0 SDK image as the base
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build

# Set the working directory in the container to /src
WORKDIR /src

# Copy the project file to the container
COPY ["LearnCraft.Api.csproj", "./"]

# Restore the NuGet packages
RUN dotnet restore

# Copy the rest of the source code to the container
COPY . .

# Build the project
RUN dotnet build -c Release --no-restore

# Publish the project
RUN dotnet publish -c Release -o /app --no-restore

# Use a .NET 7.0 runtime image as the base
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base

# Set the working directory in the container to /app
WORKDIR /app

# Expose ports 80 and 443 in the container
EXPOSE 80
EXPOSE 443

# Copy the published output from the build stage to the container
COPY --from=build /app .

# Set the entry point for the application
ENTRYPOINT ["dotnet", "LearnCraft.Api.dll"]
