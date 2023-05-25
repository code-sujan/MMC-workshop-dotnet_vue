### Download and Install postgresql 
https://www.postgresql.org/download/
- psql -U postgres (To connect to psql)
- \l (show list of db)
- \c (connect to db)
- \dt (show list of tables)
- \q (exit psql)

- dotnet tool install --global dotnet-ef

### Install Packages
- dotnet add package Npgsql.EntityFrameworkCore.PostgreSQL
- dotnet add package Microsoft.EntityFrameworkCore.Design
- dotnet add package EFCore.NamingConventions
- dotnet add package Microsoft.AspNetCore.Mvc.Razor.RuntimeCompilation