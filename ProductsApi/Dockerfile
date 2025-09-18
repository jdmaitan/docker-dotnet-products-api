# Usar la imagen oficial de .NET SDK para compilar
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copiar archivos y restaurar dependencias
COPY *.csproj ./
RUN dotnet restore

# Copiar todo el código fuente y compilar
COPY . ./
RUN dotnet publish -c Release -o /out

# Usar una imagen de runtime para ejecutar la API
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /out .

# Exponer el puerto en el contenedor
EXPOSE 8080

# Ejecutar la API
CMD ["dotnet", "ProductsApi.dll"]
