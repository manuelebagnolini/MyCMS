#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["MyCMS.Core/MyCMS.Core.csproj", "mycms.core/"]
COPY ["MyCMS.Data/MyCMS.Data.csproj", "mycms.data/"]
COPY ["MyCMS.Web.API/MyCMS.Web.API.csproj", "mycms.web.api/"]
RUN dotnet restore "mycms.web.api/MyCMS.Web.API.csproj"
COPY . .
WORKDIR "/src/MyCMS.Web.API"
RUN dotnet build "MyCMS.Web.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MyCMS.Web.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MyCMS.Web.API.dll"]