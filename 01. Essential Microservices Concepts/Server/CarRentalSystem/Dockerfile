FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["CarRentalSystem/CarRentalSystem.Dealers.csproj", "CarRentalSystem/"]
COPY ["CarRentalSystem.Common/CarRentalSystem.Common.csproj", "CarRentalSystem.Common/"]
RUN dotnet restore "CarRentalSystem/CarRentalSystem.Dealers.csproj"
COPY . .
WORKDIR "/src/CarRentalSystem"
RUN dotnet build "CarRentalSystem.Dealers.csproj" -c Debug -o /app/build

FROM build AS publish
RUN dotnet publish "CarRentalSystem.Dealers.csproj" -c Debug -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CarRentalSystem.Dealers.dll"]