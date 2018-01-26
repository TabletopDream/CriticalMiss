FROM microsoft/aspnetcore:2.0 AS base
WORKDIR /app
EXPOSE 5000

FROM microsoft/aspnetcore-build:2.0 AS build
WORKDIR /src
COPY *.sln ./
COPY CriticalMiss.UI/CriticalMiss.UI.csproj CriticalMiss.UI/
COPY CriticalMiss.Common/CriticalMiss.Common.csproj CriticalMiss.Common/
RUN dotnet restore
COPY . .
WORKDIR /src/CriticalMiss.UI
RUN dotnet build -c Release -o /app

FROM build AS publish
RUN dotnet publish -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "CriticalMiss.UI.dll"]
