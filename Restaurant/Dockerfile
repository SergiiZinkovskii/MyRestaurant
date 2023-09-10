#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Restaurant/Restaurant.csproj", "Restaurant/"]
COPY ["Restaraunt.DAL/Restaurant.DAL.csproj", "Restaraunt.DAL/"]
COPY ["Restaraunt.Domain/Restaurant.Domain.csproj", "Restaraunt.Domain/"]
COPY ["Restauraunt.Services/Restaurant.Services.csproj", "Restauraunt.Services/"]
RUN dotnet restore "Restaurant/Restaurant.csproj"
COPY . .
WORKDIR "/src/Restaurant"
RUN dotnet build "Restaurant.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Restaurant.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Restaurant.dll"]