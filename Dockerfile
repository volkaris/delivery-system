FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["testTask/testTask.csproj", "testTask/"]
RUN dotnet restore "testTask/testTask.csproj"
COPY . .
WORKDIR "/src/testTask"
RUN dotnet build "testTask.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "testTask.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "testTask.dll"]
