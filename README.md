# stroymarket-net-api

# Starting PostgreSQL server
```powershell
$sa_password = "[SA PASSWORD HERE]"
$ docker run --name some-postgres -e POSTGRES_PASSWORD=$sa_password-d postgres
```

# Setting the connection string to secret manager
```powershell
$sa_password = "[SA PASSWORD HERE]"
dotnet user-secrets set "ConnectionStrings:ProductStoreContext"
"Host=my_host;Username=my_user;Password=$sa_password;Database=my_db"
```