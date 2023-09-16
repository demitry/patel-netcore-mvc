## Azure Part

# Private repo 
https://github.com/demitry/bulky.git

### Abbreviation for Azure Resources

https://learn.microsoft.com/en-us/azure/cloud-adoption-framework/ready/azure-best-practices/resource-abbreviations

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

#### Deploy

- We have publish option in VS
- Via Azure Portal

Via Azure Portal:

- App Services -> Create Web App
- Resource group: rg-bulky-live
- App Name: app-bulky
- Publish: code
- Runtime Stack: .NET8 Preview (my choice)
- OS: I choose Linux, because of .NET8 Preview (1 option), Patel choose Windows, 
    - but changed to Win .NET 7 with CI\CD
- Pricing Plan: Free F1

Deployment Tab
```
Configuring deployment with GitHub Actions during app creation isn't supported with your selections of operating system and App Service plan. If you want to keep these selections, you can configure deployment with GitHub Actions after the web app is created.
```
So CICD requires Windows, so need downgrade to .NET7

Continuous deployment: Enable

Enter github credentials

Networking Tab - Enable Public Access

Create

https://app-bulky.azurewebsites.net/

```
Your web app is running and waiting for your content
Deployment Center
Deployment logs
View logs
Last deployment
Failed on Saturday, September 16, 12:19:11 PM
The current .NET SDK does not support targeting .NET 8.0. Either target .NET 7.0 or lower,
```

So change target to .NET 7.0 and proceed

Deployment - Success

HTTP Error 500.30 - ASP.NET Core app failed to start

#### Update Connection String

appsettings.Production.json

```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*",
  "ConnectionStrings": {
    "DefaultConnection": "Server=tcp:sqlserver-bulky.database.windows.net,1433;Initial Catalog=sqldb-bulky;Persist Security Info=False;User ID=sqladmin;Password=;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"
  },
  "Stripe": {
    "PublishableKey": "pk_test_",
    "SecretKey": "sk_test_"
  },
  "FaceBook": {
    "AppId": "1525082148229934",
    "AppSecret": ""
  }
}
```

NB! NB! NB!

sqlserver-bulky | Networking

[x] Allow Azure services and resources to access this server

*Should be checked!!!*


app-bulky | Configuration

Explicitly:

New application setting: ASPNETCORE_ENVIRONMENT: Production

Save, Continue

### Azure Deployment in Action [186]
### Facebook Url [187]
### Facebook Url Error [188]
### Microsoft Social Login [210]
### Deploy Application to Azure using Visual Studio [212]
