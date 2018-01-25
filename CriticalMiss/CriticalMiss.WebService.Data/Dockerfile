FROM microsoft/aspnetcore:2.0-nanoserver-1709 AS base

WORKDIR /app
EXPOSE 5002

FROM microsoft/aspnetcore-build:2.0-nanoserver-1709 AS build
WORKDIR /src

COPY *.sln ./
COPY CriticalMiss.WebService.Data/CriticalMiss.WebService.Data.csproj CriticalMiss.WebService.Data/
COPY CriticalMiss.Data/CriticalMiss.Data.csproj CriticalMiss.Data/
COPY CriticalMiss.Common/CriticalMiss.Common.csproj CriticalMiss.Common/
RUN dotnet restore
COPY . .
WORKDIR /src/CriticalMiss.WebService.Data
RUN dotnet build -c Release -o /app

FROM build AS publish
RUN dotnet publish -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "CriticalMiss.WebService.Data.dll"]
