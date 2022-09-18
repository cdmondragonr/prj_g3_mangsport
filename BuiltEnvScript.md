
Getting Framework EF Global Install 
CL1:    otnet tool install --global dotnet-ef
CL2 -opt:   dotnet tool update --global dotnet-ef

Adding to the project packages EF
CL3:    dotnet add package Microsoft.EntityFrameworkCore --version 5.0.0
CL4:    dotnet add package Microsoft.EntityFrameworkCore.Tools --version 5.0.0
CL5:    dotnet add package Microsoft.EntityFrameworkCore.Design --version 5.0.0
CL6:    dotnet add package Microsoft.EntityFrameworkCore.SqlServer --version 5.0.0

Setting Migrations
Creating Miggrations: 
CL8:    dotnet ef migrations add Init
        & remove: dotnet ef migrations remove --startup-project --\Console\

Updating Migrations:
CL9:    dotnet ef database update

Executng migrations out main directory
Creating Miggrations: 
CL10:   dotnet ef database update  --startup-project ..\ConsoleApp\

Updating Migrations:
CL11:   dotnet ef migrations add Init --startup-project ..\ConsoleApp\

Adding package to domain layout to setting entitie atributes
CL12:   dotnet add package System.ComponentModel.Annotations --version 5.0.0

