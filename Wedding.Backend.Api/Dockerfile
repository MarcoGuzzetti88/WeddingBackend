#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["Wedding.Backend.Api/Wedding.Backend.Api.csproj", "Wedding.Backend.Api/"]
COPY ["Wedding.Backend.DAL/Wedding.Backend.DAL.csproj", "Wedding.Backend.DAL/"]
COPY ["Wedding.Backend.BLL/Wedding.Backend.BLL.csproj", "Wedding.Backend.BLL/"]
COPY ["Wedding.Backend.Domain/Wedding.Backend.Domain.csproj", "Wedding.Backend.Domain/"]
RUN dotnet restore "Wedding.Backend.Api/Wedding.Backend.Api.csproj"
COPY . .
WORKDIR "/src/Wedding.Backend.Api"
RUN dotnet build "Wedding.Backend.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Wedding.Backend.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Wedding.Backend.Api.dll"]