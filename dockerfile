FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /main-api-app

EXPOSE 80
EXPOSE 5000

# COPY csproj and restore as distinct layers
COPY ./*csproj ./
RUN dotnet restore

# COPY everything else and build app
COPY . .
RUN dotnet publish -c Release -o out

# Build image
FROM mcr.microsoft.com/dotnet/sdk:9.0
WORKDIR /main-api-app
COPY --from=build /main-api-app/out .
ENTRYPOINT ["dotnet", "perla-metro-api-main.dll"]