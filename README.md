# SalesManager.API
Info about stack
	- .Net core 8
	- .EF Core
	-  MS SQL Server

# Installation instructions

1. Configure connection string in appsettings in SalesManager.Deploy and SalesManager.API
2. Restore backup from ./DB_backup folder or create DB manyally using EF core tools and run SalesManager.Deploy console app.
3. Configure CORS policy for your WEB app: add or change web app host in appsettings.json file of the SalesManager.API