FROM microsoft/aspnetcore:2.0 AS base
WORKDIR /app
EXPOSE 5001

FROM microsoft/aspnetcore-build:2.0 AS build
WORKDIR /src
COPY *.sln ./
COPY CriticalMiss.WebService.Library/CriticalMiss.WebService.Library.csproj CriticalMiss.WebService.Library/
COPY CriticalMiss.Common/CriticalMiss.Common.csproj CriticalMiss.Common/
COPY CriticalMiss.Library/CriticalMiss.Library.csproj CriticalMiss.Library/
RUN dotnet restore
COPY . .
WORKDIR /src/CriticalMiss.WebService.Library
RUN dotnet build -c Release -o /app

FROM build AS publish
RUN dotnet publish -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "CriticalMiss.WebService.Library.dll"]
