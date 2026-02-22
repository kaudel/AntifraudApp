# See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

# This stage is used when running from VS in fast mode (Default for Debug configuration)
FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081


# This stage is used to build the service project
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/Yape.TransactionService.API/Yape.TransactionService.API.csproj", "src/Yape.TransactionService.API/"]
COPY ["src/Yape.TransactionService.Application/Yape.TransactionService.Application.csproj", "src/Yape.TransactionService.Application/"]
COPY ["src/Yape.TransactionService.Domain/Yape.TransactionService.Domain.csproj", "src/Yape.TransactionService.Domain/"]
COPY ["src/Yape.TransactionService.Infraestructure/Yape.TransactionService.Infraestructure.csproj", "src/Yape.TransactionService.Infraestructure/"]
RUN dotnet restore "./src/Yape.TransactionService.API/Yape.TransactionService.API.csproj"
COPY . .
WORKDIR "/src/src/Yape.TransactionService.API"
RUN dotnet build "./Yape.TransactionService.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

# This stage is used to publish the service project to be copied to the final stage
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Yape.TransactionService.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# This stage is used in production or when running from VS in regular mode (Default when not using the Debug configuration)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Yape.TransactionService.API.dll"]