FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

# Copy project files and restore
COPY ["src/HeruConsoleApp/HeruConsoleApp.csproj", "src/HeruConsoleApp/"]
COPY ["src/Rinsen.Heru/Rinsen.Heru.csproj", "src/Rinsen.Heru/"]
RUN dotnet restore "src/HeruConsoleApp/HeruConsoleApp.csproj"

# Build and publish
COPY . .
WORKDIR "/src/HeruConsoleApp"
RUN dotnet build "HeruConsoleApp.csproj" -c Release -o /app/build
RUN dotnet publish "HeruConsoleApp.csproj" -c Release -o /app/build

# Runtime stage
FROM mcr.microsoft.com/dotnet/runtime:10.0
WORKDIR /app
COPY --from=publish /app/build .
ENTRYPOINT ["dotnet", "HeruConsoleApp.dll"]
