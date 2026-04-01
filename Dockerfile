FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY CineSwipe/CineSwipe/CineSwipe.csproj CineSwipe/
RUN dotnet restore CineSwipe/CineSwipe.csproj
COPY CineSwipe/CineSwipe/ CineSwipe/
RUN dotnet publish CineSwipe/CineSwipe.csproj -c Release -o /app

FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app .
ENV ASPNETCORE_URLS=http://+:8080
EXPOSE 8080
ENTRYPOINT ["dotnet", "CineSwipe.dll"]
