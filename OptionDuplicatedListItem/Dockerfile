FROM mcr.microsoft.com/dotnet/nightly/sdk:9.0 AS build-env
WORKDIR /App

# Copy everything
COPY . ./
# Restore as distinct layers
RUN dotnet restore OptionDuplicatedListItem.csproj
# Build and publish a release
RUN dotnet publish OptionDuplicatedListItem.csproj -c Release -o out --no-restore  /p:UseAppHost=false

# Build runtime image
FROM mcr.microsoft.com/dotnet/nightly/sdk:9.0

EXPOSE 5000

ENV Kestrel__Endpoints__Http__Url=http://0.0.0.0:5000

WORKDIR /App
COPY --from=build-env /App/out .
ENTRYPOINT ["dotnet", "OptionDuplicatedListItem.dll"]