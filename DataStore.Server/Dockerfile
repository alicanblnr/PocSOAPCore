FROM mcr.microsoft.com/dotnet/sdk:3.1 AS base
WORKDIR /app

# Creates a non-root user with an explicit UID and adds permission to access the /app folder
# For more info, please refer to https://aka.ms/vscode-docker-dotnet-configure-containers
RUN adduser -u 5678 --disabled-password --gecos "" appuser && chown -R appuser /app
USER appuser

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["DataStore.Server/DataStore.Server.csproj", "DataStore.Server/"]
RUN dotnet restore "DataStore.Server/DataStore.Server.csproj"
COPY . .
WORKDIR "/src/DataStore.Server"
RUN dotnet build "DataStore.Server.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DataStore.Server.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DataStore.Server.dll"]

EXPOSE 80
EXPOSE 443
EXPOSE 8081

