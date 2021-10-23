#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["HW4-Grup2.API/HW4-Grup2.API.csproj", "HW4-Grup2.API/"]
COPY ["HW4-Grup2.Application/HW4-Grup2.Application.csproj", "HW4-Grup2.Application/"]
COPY ["HW4-Grup2.Infrastructure/HW4-Grup2.Infrastructure.csproj", "HW4-Grup2.Infrastructure/"]
COPY ["HW4-Grup2.Domain/HW4-Grup2.Domain.csproj", "HW4-Grup2.Domain/"]
RUN dotnet restore "HW4-Grup2.API/HW4-Grup2.API.csproj"
COPY . .
WORKDIR "/src/HW4-Grup2.API"
RUN dotnet build "HW4-Grup2.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "HW4-Grup2.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "HW4-Grup2.API.dll"]