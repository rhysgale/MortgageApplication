# MortgageApplication
A simple project for receiving mortgage products

# Setup
The projects use both .NET Core 3.1 and .NET Standard 2.1, so you will need the latest VS 2019 installed, and potentially the .NET Core SDK.

Once done, open both the MortgageAPI and MortgageApplication solutions in visual studio. Once done, run the API (Swagger enabled if you go to "/swagger"), then run the website.

Once running the API, the API url should be copied and pasted into the MortgageApplication -> appsettings.json -> ApiUrl setting (If it differs from the one already there)

Then once done, the website should be loaded up and you will be able to input user details, then get mortgage products returned based off your given criteria. 

#NUGET
The API Models project is setup to product a NUGET package on build. I have currently added the models project from the API as a project reference into the MortgageApplication website for simplicity (So theres no need to build the NUGET, reference it and restore it to the project to get it to build) 

# Database
The database used is the Entity Framework Core InMemoryDatabase, with data created in MortgageAPI -> BankContext -> DataGenerator.cs. This is then called from Program.cs to populate the in memory database.


