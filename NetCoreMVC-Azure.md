## Azure Part

### Create Azure SQL Server and Database [183]

Create SQL Database

- Resource group: rg-bulky-live
- Database name: sqldb-bulky
- Database Server name: sqlserver-bulky

- Use SQL authentication
  - User Id: sqladmin
  - Password: 

Want to use SQL elastic pool? No

Workload environment: Development

Configure database

Service Tier: Basic

ESTIMATED COST / MONTH: 4.90 USD

Create

sqldb-bulky (sqlserver-bulky/sqldb-bulky)

!!!!!!!!
Set server firewall
Public network access
Public Endpoints allow access to this resource through the internet using a public IP address. An application or resource that is granted access with the following network rules still requires proper authorization to access this resource. Learn more
Public network access

[x] **Selected Network**

Add your IP

!!!!!!!!
[x] **Allow Azure services and resources to access this server**

Save

sqldb-bulky (sqlserver-bulky/sqldb-bulky) | Connection strings

ADO.NET (Active Directory passwordless authentication)
```
Server=tcp:sqlserver-bulky.database.windows.net,1433;Initial Catalog=sqldb-bulky;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;Authentication="Active Directory Default";
```


ADO.NET (SQL authentication)
```
Server=tcp:sqlserver-bulky.database.windows.net,1433;Initial Catalog=sqldb-bulky;Persist Security Info=False;User ID=sqladmin;Password={your_password};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;
```

### Azure Production Deployment [185]
### Azure Deployment in Action [186]
### Facebook Url [187]
### Facebook Url Error [188]
### Microsoft Social Login [210]
### Deploy Application to Azure using Visual Studio [212]
