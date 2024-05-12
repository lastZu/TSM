FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 5253

ENV ASPNETCORE_URLS=http://+:5253

USER app
FROM --platform=$BUILDPLATFORM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG configuration=Release
WORKDIR /src
COPY ["src/TSM.WorkLogs.Api/TSM.WorkLogs.Api.csproj", "src/TSM.WorkLogs.Api/"]
RUN dotnet restore "src/TSM.WorkLogs.Api/TSM.WorkLogs.Api.csproj"
COPY . .
WORKDIR "/src/src/TSM.WorkLogs.Api"
RUN dotnet build "TSM.WorkLogs.Api.csproj" -c $configuration -o /app/build

FROM build AS publish
ARG configuration=Release
RUN dotnet publish "TSM.WorkLogs.Api.csproj" -c $configuration -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TSM.WorkLogs.Api.dll"]
