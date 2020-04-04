#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["Email.API/Email.API.csproj", "Email.API/"]
COPY ["Es.EventBus.RabbitMQ/Es.EventBus.RabbitMQ.csproj", "Es.EventBus.RabbitMQ/"]
COPY ["Es.EventBus/Es.EventBus.csproj", "Es.EventBus/"]
RUN dotnet restore "Email.API/Email.API.csproj"
COPY . .
WORKDIR "/src/Email.API"
RUN dotnet build "Email.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Email.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Email.API.dll"]