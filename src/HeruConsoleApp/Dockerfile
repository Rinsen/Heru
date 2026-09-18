FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

COPY ["HeruConsoleApp.csproj", "./"]
RUN dotnet restore "HeruConsoleApp.csproj"

COPY . .
WORKDIR "/src/HeruConsoleApp"
RUN dotnet build "HeruConsoleApp.csproj" -c Release -o /app

FROM mcr.microsoft.com/dotnet/runtime:10.0 AS final
WORKDIR /app
COPY --from=build /app .
ENTRYPOINT ["dotnet", "HeruConsoleApp.dll"]
