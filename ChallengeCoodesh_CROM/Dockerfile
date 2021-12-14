#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:3.1 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["ChallengeCoodesh_CROM/ChallengeCoodesh_CROM.csproj", "ChallengeCoodesh_CROM/"]
RUN dotnet restore "ChallengeCoodesh_CROM/ChallengeCoodesh_CROM.csproj"
COPY . .
WORKDIR "/src/ChallengeCoodesh_CROM"
RUN dotnet build "ChallengeCoodesh_CROM.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ChallengeCoodesh_CROM.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ChallengeCoodesh_CROM.dll"]