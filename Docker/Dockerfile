FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build-env
WORKDIR /App

# Copy everything else
COPY . ./

# Dotnet restore
RUN dotnet restore "Api/Api.csproj"

# Build
RUN dotnet publish Api/Api.csproj --self-contained false -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:7.0
WORKDIR /App
COPY --from=build-env /App/out .
ENTRYPOINT ["dotnet", "SportsBet.Api.dll"]