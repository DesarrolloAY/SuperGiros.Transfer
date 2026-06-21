# 1. Etapa de compilación
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

# Copiar archivos de proyectos para restaurar dependencias de todas las capas
COPY ["src/SuperGiros.Transfer.Services.gRPC/SuperGiros.Transfer.Services.gRPC.csproj", "src/SuperGiros.Transfer.Services.gRPC/"]
COPY ["src/SuperGiros.Transfer.Application.UseCases/SuperGiros.Transfer.Application.UseCases.csproj", "src/SuperGiros.Transfer.Application.UseCases/"]
COPY ["src/SuperGiros.Transfer.Application.Interfaces/SuperGiros.Transfer.Application.Interfaces.csproj", "src/SuperGiros.Transfer.Application.Interfaces/"]
COPY ["src/SuperGiros.Transfer.Domain/SuperGiros.Transfer.Domain.csproj", "src/SuperGiros.Transfer.Domain/"]
COPY ["src/SuperGiros.Transfer.Persistence/SuperGiros.Transfer.Persistence.csproj", "src/SuperGiros.Transfer.Persistence/"]
COPY ["src/SuperGiros.Transfer.Messaging/SuperGiros.Transfer.Messaging.csproj", "src/SuperGiros.Transfer.Messaging/"]
COPY ["src/SuperGiros.Transfer.Infrastructure/SuperGiros.Transfer.Infrastructure.csproj", "src/SuperGiros.Transfer.Infrastructure/"]

# Ejecutar la restauración limpia con el mapa completo de dependencias
RUN dotnet restore "src/SuperGiros.Transfer.Services.gRPC/SuperGiros.Transfer.Services.gRPC.csproj"

# Copiar todo el resto del código fuente de la solución
COPY . .
WORKDIR "/src/src/SuperGiros.Transfer.Services.gRPC"
RUN dotnet build "SuperGiros.Transfer.Services.gRPC.csproj" -c Release -o /app/build

# Publicar la aplicación optimizada para producción
FROM build AS publish
RUN dotnet publish "SuperGiros.Transfer.Services.gRPC.csproj" -c Release -o /app/publish /p:UseAppHost=false

# 2. Etapa de ejecución final (Runtime ligero de ASP.NET 10)
FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS final
WORKDIR /app
COPY --from=publish /app/publish .

# Exponer los puertos configurados nativamente en Kestrel (Program.cs)
EXPOSE 5240
EXPOSE 5241

ENTRYPOINT ["dotnet", "SuperGiros.Transfer.Services.gRPC.dll"]