ARG  DOTNET_VERSION=5.0

FROM mcr.microsoft.com/dotnet/sdk:${DOTNET_VERSION} AS build

COPY src/Api/bin/Debug/net5.0/ /app

FROM mcr.microsoft.com/dotnet/aspnet:${DOTNET_VERSION}-alpine

WORKDIR /app

COPY --from=build  /app .

EXPOSE 6060

ENTRYPOINT ["/usr/bin/dotnet", "/app/Api.dll"]