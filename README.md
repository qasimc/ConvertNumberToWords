# ConvertNumberToWords

This application is developed in .NET core 2.1 and converts decimal numbers to words and stores them to a database.
The database connectionstring can be configured in appsettings.json file under the ConvertNumberToWordsUI project.

I have provided a few unit test projects as well just to demonstrate how testing can be done in this project.
The architecture of the project follows the Onion methodology where the domain has no dependency on any of the projects. 
I have defined interfaces for the service layer and the repository layer which are mapped to their concrete classes in the DependencyInjection project.
