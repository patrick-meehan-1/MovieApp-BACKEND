# Build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# copy csproj and restore as distinct layers
COPY ["CineSwipe.csproj", "./"]
RUN dotnet restore "CineSwipe.csproj"

# copy everything and publish
COPY . .
RUN dotnet publish "CineSwipe.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
EXPOSE 80
ENV ASPNETCORE_URLS=http://+:80

COPY --from=build /app/publish ./
ENTRYPOINT ["dotnet", "CineSwipe.dll"]
