# MovieManager API

## Starting SQL Server
```powershell
$sa_password = "PASSWORD HERE" -> P@ssword123
docker run -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=$sa_password" -p 1433:1433 -v sqlvolume:/var/opt/mssql -d --rm --name mssql mcr.microsoft.com/mssql/server:2022-latest
```

## Setting ConnectionString to secret manager
```powershell
$sa_password = "PASSWORD HERE" -> P@ssword123
dotnet user-secrets set "ConnectionStrings:MovieManagerContext" "Server=localhost; Database=MovieManagerDB; User Id=sa; Password=$sa_password; TrustServerCertificate=True"
```