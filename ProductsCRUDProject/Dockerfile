# .NET SDK imaj�n� kullanarak projeyi derleyelim
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /app

# Projeyi Docker i�ine kopyalayal�m
COPY . .

# Projeyi derleyelim
RUN dotnet restore
RUN dotnet publish -c Release -o out

# .NET Runtime imaj�n� kullanarak projeyi �al��t�ral�m
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS runtime
WORKDIR /app
COPY --from=build /app/out .

# Uygulamay� ba�lat
ENTRYPOINT ["dotnet", "ProductsCRUDProject.dll"]
