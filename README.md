# MortgageApplication
A simple project for receiving mortgage products

# Setup
The projects use both .NET Core 3.1 and .NET Standard 2.1, so you will need the latest VS 2019 installed, and potentially the .NET Core SDK.

Once done, open both the MortgageAPI and MortgageApplication solutions in visual studio. Once done, run the API (Swagger enabled if you go to "/swagger"), then run the website.

Once running the API, the API url should be copied and pasted into the MortgageApplication -> appsettings.json -> ApiUrl setting (If it differs from the one already there)

Then once done, the website should be loaded up and you will be able to input user details, then get mortgage products returned based off your given criteria. 

#NUGET
The API publishes the "Models" project as a NUGET package, which is then consumed by MortgageApplication. If the project doesn't build because of this, the API -> Models project needs building,
then in the output window tells you where the NUGET package has been published to. Add a reference to this in the NUGET package manager, then install it to the MortgageApplication project. 

# Database
The database used is the Entity Framework Core InMemoryDatabase, with data created in MortgageAPI -> BankContext -> DataGenerator.cs. This is then called from Program.cs to populate the in memory database.


