FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["PictureApi.csproj", "PictureApi/"]
RUN dotnet restore "PictureApi/PictureApi.csproj"
COPY . .
WORKDIR "/src/PictureApi"
RUN dotnet build "PictureApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PictureApi.csproj" -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PictureApi.dll"]