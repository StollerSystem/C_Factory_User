# _MVC Factory_

#### _An app to manage enginners and machines at a factory, 10/9/20_

#### By _**Ben Stoller**_

## Description



Stretch Goals:



## Setup/Installation Requirements

## MySQL Workbench Schema Setup:
1. Open [MySql Workbench](https://www.mysql.com/products/workbench/) and connect to Local instance
2. Create a new sql tab by clicking the upper left icon: 'Create A New SQL Tab for Executing Queries'
3. Copy and paste the following code into "Query" and "Run":
---
### **Copy The Following Code:**






## Website Setup:
* Download or Clone project from Github repository.
* Open a terminal within HairSalon folder within main project directory.
* Use command: 'dotnet restore' to install.
* After installation, type in 'dotnet build'.
* After build, run the program with 'dotnet run' in the terminal.
* If you don't have it already, create an "appsettings.json" file in the "HairSalon" directory and Insert the code below with your user name and password for MySQL: 

> {
>  "ConnectionStrings": {
>      "DefaultConnection": "Server=localhost;Port=3306;database=hair_salon;uid={YOUR USERNAME};pwd={YOUR USERNAME}"
>  }
>}

* Follow terminal prompts to see application run.


## Known Bugs

When creating an appointment a Client can be linked to ANY Stylist

## Support and contact details

https://github.com/StollerSystem

## Technologies Used

C#, .NET Core, LINQ, Entity Framework Core, MySql, CSHTML, CSS, Bootstrap and Markdown.


### License

MIT

Copyright (c) 2020 **_Ben Stoller_**

