#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/TestTaskForIntravision.WebApi/TestTaskForIntravision.WebApi.csproj", "src/TestTaskForIntravision.WebApi/"]
COPY ["src/TestTaskForIntravision.Application/TestTaskForIntravision.Application.csproj", "src/TestTaskForIntravision.Application/"]
COPY ["src/TestTaskForIntravision.Infrastructure/TestTaskForIntravision.Infrastructure.csproj", "src/TestTaskForIntravision.Infrastructure/"]
COPY ["src/TestTaskForIntravision.Domain/TestTaskForIntravision.Domain.csproj", "src/TestTaskForIntravision.Domain/"]
RUN dotnet restore "./src/TestTaskForIntravision.WebApi/TestTaskForIntravision.WebApi.csproj"
COPY . .
WORKDIR "/src/src/TestTaskForIntravision.WebApi"
RUN dotnet build "./TestTaskForIntravision.WebApi.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./TestTaskForIntravision.WebApi.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TestTaskForIntravision.WebApi.dll"]