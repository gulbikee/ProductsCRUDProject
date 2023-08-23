# .NET SDK imajýný kullanarak projeyi derleyelim
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /app

# Projeyi Docker içine kopyalayalým
COPY . .

# Projeyi derleyelim
RUN dotnet restore
RUN dotnet publish -c Release -o out

# .NET Runtime imajýný kullanarak projeyi çalýþtýralým
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS runtime
WORKDIR /app
COPY --from=build /app/out .

# Uygulamayý baþlat
ENTRYPOINT ["dotnet", "ProductsCRUDProject.dll"]
