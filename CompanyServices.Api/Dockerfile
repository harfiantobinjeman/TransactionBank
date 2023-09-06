#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["CompanyServices.Api/CompanyServices.Api.csproj", "CompanyServices.Api/"]
RUN dotnet restore "CompanyServices.Api/CompanyServices.Api.csproj"
COPY . .
WORKDIR "/src/CompanyServices.Api"
RUN dotnet build "CompanyServices.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CompanyServices.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CompanyServices.Api.dll"]