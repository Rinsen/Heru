FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

# Copy project files and restore
COPY ["HeruConsoleApp/HeruConsoleApp.csproj", "HeruConsoleApp/"]
COPY ["Rinsen.Heru/Rinsen.Heru.csproj", "Rinsen.Heru/"]
RUN dotnet restore "src/HeruConsoleApp/HeruConsoleApp.csproj"

# Build and publish
COPY . .
WORKDIR "/src/HeruConsoleApp"
RUN dotnet build "HeruConsoleApp.csproj" -c Release -o out
RUN dotnet publish "HeruConsoleApp.csproj" -c Release -o out

# Runtime stage
FROM mcr.microsoft.com/dotnet/runtime:10.0
WORKDIR /app
COPY --from=build /out .
ENTRYPOINT ["dotnet", "HeruConsoleApp.dll"]
