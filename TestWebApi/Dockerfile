FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["TestWebApi.csproj", "TestWebApi/"]
RUN dotnet restore "TestWebApi/TestWebApi.csproj"
WORKDIR "/src/TestWebApi"
COPY . .
RUN dotnet build "TestWebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TestWebApi.csproj" -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TestWebApi.dll"]