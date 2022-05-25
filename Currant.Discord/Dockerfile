FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Currant/Currant.csproj", "Currant/"]
RUN dotnet restore "Currant/Currant.csproj"
COPY . .
WORKDIR "/src/Currant"
RUN dotnet build "Currant.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Currant.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Currant.dll"]
