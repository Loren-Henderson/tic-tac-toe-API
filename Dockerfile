FROM mcr.microsoft.com/dotnet/sdk:5.0 as build-env
WORKDIR /app
# Copy csproj and restore as distinct layers
COPY MK-TicTacToe-Game/*.csproj ./
RUN dotnet restore

# Copy everything else and build
COPY . ./
RUN dotnet publish -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:5.0
WORKDIR /dist
COPY --from=build-env /app/out .
CMD [ "dotnet", "MK-TicTacToe-Game.dll" ]