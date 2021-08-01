ARG  DOTNET_VERSION=5.0
FROM mcr.microsoft.com/dotnet/sdk:${DOTNET_VERSION} AS build

COPY src /app/src
RUN dotnet publish /app/src/Api/Api.csproj -c Release -o /app/bin

FROM mcr.microsoft.com/dotnet/aspnet:${DOTNET_VERSION} AS runtime
WORKDIR /app/bin
COPY --from=build /app/bin .

EXPOSE 6060

ENTRYPOINT ["dotnet", "Api.dll"]