#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["QuickOrderCliente.Api/QuickOrderCliente.Api.csproj", "QuickOrderCliente.Api/"]
COPY ["QuickOrderCliente.PostgresDB/QuickOrderCliente.PostgresDB.csproj", "QuickOrderCliente.PostgresDB/"]
COPY ["QuickOrderCliente.Application/QuickOrderCliente.Application.csproj", "QuickOrderCliente.Application/"]
COPY ["QuickOrderCliente.Domain/QuickOrderCliente.Domain.csproj", "QuickOrderCliente.Domain/"]
COPY ["QuickOrderCliente.IoC/QuickOrderCliente.IoC.csproj", "QuickOrderCliente.IoC/"]
COPY ["QuickOrderCliente.Tests/QuickOrderCliente.Tests.csproj", "QuickOrderCliente.Tests/"]
RUN dotnet restore "./QuickOrderCliente.Api/QuickOrderCliente.Api.csproj"
COPY . .
WORKDIR "/src/QuickOrderCliente.Api"
RUN dotnet build "./QuickOrderCliente.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./QuickOrderCliente.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "QuickOrderCliente.Api.dll"]