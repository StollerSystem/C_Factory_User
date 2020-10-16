# _MVC Factory_

#### _An app to manage enginners and machines at a factory, 10/9/20_

#### By _**Ben Stoller**_

## Description

This app will start you on the home page where you'll have an overview of all the machines and engineers currently added. From here you can go to manage machines, engineers or incidents. In manage machines you can view a list of all machines, add new ones and click on them to pull up the details page. From there you can see all the information as well as assign a repair engineer to the machine. 
From the engineer manager you can add new ones and select them from the list to view details. Once in the details you can edit, delete and assign them to a machine. 
In the incident manager you can create a new incident and then see a list of them on the index. If you click on an incindent you will be taken to the details page where you can edit, delete or assign the engineer and machine involved in the repair incident. 

## User Stories
* As the factory manager, I need to be able to see a list of all engineers, and I need to be able to see a list of all machines.
* As the factory manager, I need to be able to select an engineer, see their details, and see a list of all machines that engineer is licensed to repair. I also need to be able to select a machine, see its details, and see a list of all engineers licensed to repair it.
* As the factory manager, I need to add new engineers to our system when they are hired. I also need to add new machines to our system when they are installed.
* As the factory manager, I should be able to add new machines even if no engineers are employed. I should also be able to add new engineers even if no machines are installed
* As the factory manager, I need to be able to add or remove machines that a specific engineer is licensed to repair. I also need to be able to modify this relationship from the other side, and add or remove engineers from a specific machine.
* I should be able to navigate to a splash page that lists all engineers and machines. Users should be able to click on an individual engineer or machine to see all the engineers/machines that belong to it.


Stretch Goals Completed:

* Add all CRUD methods to both classes
* Add properties to specify if a machine is operational, malfunctioning, or in the process of being repaired
* Add properties to specify if an engineer is idle, or actively working on repairs
* Add inspection dates to the machines
* Add a table for incidents, showing which engineer repaired which machine
* Add styling to give life to the project




## Setup/Installation Requirements

NOTE - you can do the following to manually set up the databse for the project OR you can run the command 'dotnet ef database update' after you clone as explained below. 

## MySQL Workbench Schema Setup:
1. Open [MySql Workbench](https://www.mysql.com/products/workbench/) and connect to Local instance
2. Create a new sql tab by clicking the upper left icon: 'Create A New SQL Tab for Executing Queries'
3. Copy and paste the following code into "Query" and "Run":
---
### **Copy The Following Code:**
CREATE DATABASE `ben_stoller` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci */ /*!80016 DEFAULT ENCRYPTION='N' */;
USE ben_stoller;
CREATE TABLE `engineers` (
  `EngineerId` int NOT NULL AUTO_INCREMENT,
  `EngineerName` longtext,
  `EngineerStatus` longtext,
  `LicenseRenewal` longtext,
  PRIMARY KEY (`EngineerId`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
CREATE TABLE `incidentjoins` (
  `IncidentJoinId` int NOT NULL AUTO_INCREMENT,
  `IncidentId` int NOT NULL DEFAULT '0',
  `MachineId` int NOT NULL DEFAULT '0',
  `EngineerId` int NOT NULL DEFAULT '0',
  PRIMARY KEY (`IncidentJoinId`),
  KEY `IX_IncidentJoins_EngineerId` (`EngineerId`),
  KEY `IX_IncidentJoins_IncidentId` (`IncidentId`),
  KEY `IX_IncidentJoins_MachineId` (`MachineId`),
  CONSTRAINT `FK_IncidentJoins_Engineers_EngineerId` FOREIGN KEY (`EngineerId`) REFERENCES `engineers` (`EngineerId`) ON DELETE CASCADE,
  CONSTRAINT `FK_IncidentJoins_Incidents_IncidentId` FOREIGN KEY (`IncidentId`) REFERENCES `incidents` (`IncidentId`) ON DELETE CASCADE,
  CONSTRAINT `FK_IncidentJoins_Machines_MachineId` FOREIGN KEY (`MachineId`) REFERENCES `machines` (`MachineId`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
CREATE TABLE `incidents` (
  `IncidentId` int NOT NULL AUTO_INCREMENT,
  `IncidentTitle` longtext,
  `Description` longtext,
  `IncidentDate` longtext,
  PRIMARY KEY (`IncidentId`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
CREATE TABLE `machineengineers` (
  `MachineEngineerId` int NOT NULL AUTO_INCREMENT,
  `MachineId` int NOT NULL,
  `EngineerId` int NOT NULL,
  PRIMARY KEY (`MachineEngineerId`),
  KEY `IX_MachineEngineers_EngineerId` (`EngineerId`),
  KEY `IX_MachineEngineers_MachineId` (`MachineId`),
  CONSTRAINT `FK_MachineEngineers_Engineers_EngineerId` FOREIGN KEY (`EngineerId`) REFERENCES `engineers` (`EngineerId`) ON DELETE CASCADE,
  CONSTRAINT `FK_MachineEngineers_Machines_MachineId` FOREIGN KEY (`MachineId`) REFERENCES `machines` (`MachineId`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=16 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
CREATE TABLE `machines` (
  `MachineId` int NOT NULL AUTO_INCREMENT,
  `MachineName` longtext,
  `MachineStatus` longtext,
  `InspectionDate` longtext,
  PRIMARY KEY (`MachineId`)
) ENGINE=InnoDB AUTO_INCREMENT=12 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;


## Website Setup:
* Download or Clone project from Github repository.
* Open a terminal within Factory folder within the main project directory.
* Use command: 'dotnet restore' to install.
* After installation, type in 'dotnet build'.
* Use command 'dotnet ef database update' to scaffold the database for the project. 
* After build, run the program with 'dotnet run' in the terminal.
* If you don't have it already, create an "appsettings.json" file in the "ben_stoller" directory and Insert the code below with your user name and password for MySQL: 

> {
>  "ConnectionStrings": {
>      "DefaultConnection": "Server=localhost;Port=3306;database=ben_stoller;uid={YOUR USERNAME};pwd={YOUR USERNAME}"
>  }
>}

* Follow terminal prompts to see application run.


## Known Bugs

Currently when you create an Incident, you have to navigate to another page to assign an Engineer and a Machine to it. I'd like that to happen on the create page. 


## Support and contact details

https://github.com/StollerSystem

## Technologies Used

C#, .NET Core, LINQ, Entity Framework Core, MySql, CSHTML, CSS, Bootstrap and Markdown.


### License

MIT

Copyright (c) 2020 **_Ben Stoller_**

