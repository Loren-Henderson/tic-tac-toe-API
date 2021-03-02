#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["MK-TicTacToe-Game/MK-TicTacToe-Game.csproj", "MK-TicTacToe-Game/"]
RUN dotnet restore "MK-TicTacToe-Game/MK-TicTacToe-Game.csproj"
COPY . .
WORKDIR "/src/MK-TicTacToe-Game"
RUN dotnet build "MK-TicTacToe-Game.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MK-TicTacToe-Game.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MK-TicTacToe-Game.dll"]