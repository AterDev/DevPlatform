#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["app/App.Api/App.Api.csproj", "app/App.Api/"]
COPY ["src/Services/Services.csproj", "src/Services/"]
COPY ["src/Share/Share.csproj", "src/Share/"]
COPY ["src/Entity/Entity.csproj", "src/Entity/"]
COPY ["src/Assist/Assist.csproj", "src/Assist/"]
COPY ["src/EntityFrameworkCore/EntityFrameworkCore.csproj", "src/EntityFrameworkCore/"]
RUN dotnet restore "app/App.Api/App.Api.csproj"
COPY . .
WORKDIR "/src/app/App.Api"
RUN dotnet build "App.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "App.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "App.Api.dll"]