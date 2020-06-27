# MortgageApplication
A simple project for receiving mortgage products

# Setup
Setup is fairly simple. The projects use both .NET Core 3.1 and .NET Standard 2.1, so you will need the latest VS 2019 installed, and potentially the .NET Core SDK.

Once done, open both the MortgageAPI and MortgageApplication solutions in visual studio. Once done, run the API (Swagger enabled if you go to "/swagger"), then run the website.
If the API URL is different to the one in MortgageApplication -> Controllers -> ApiController -> Line 24/38 then this will need to be updated here. 

Then once done, the website should be loaded up and you will be able to input user details, then get mortgage products returned based off your given criteria. 

# Database
The database used is the Entity Framework Core InMemoryDatabase, with data created in MortgageAPI -> BankContext -> DataGenerator.cs. This is then called from Program.cs to populate the in memory database.


