FROM mcr.microsoft.com/dotnet/core/sdk:2.2 AS build
WORKDIR /app

# copy csproj and restore as distinct layers
COPY GuidMaker/*.sln ./GuidMaker/
COPY GuidMaker/*.csproj ./GuidMaker/
WORKDIR /app/GuidMaker
RUN dotnet restore
WORKDIR /app

# copy everything else and build app
COPY GuidMaker/. ./GuidMaker/
WORKDIR /app/GuidMaker
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/core/aspnet:2.2 AS runtime
WORKDIR /app
COPY --from=build /app/GuidMaker/out ./
ENTRYPOINT ["dotnet", "GuidMaker.dll"]
