#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["Book.API/Book.API.csproj", "Book.API/"]
COPY ["Es.EventBus.RabbitMQ/Es.EventBus.RabbitMQ.csproj", "Es.EventBus.RabbitMQ/"]
COPY ["Es.EventBus/Es.EventBus.csproj", "Es.EventBus/"]
RUN dotnet restore "Book.API/Book.API.csproj"
COPY . .
WORKDIR "/src/Book.API"
RUN dotnet build "Book.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Book.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Book.API.dll"]