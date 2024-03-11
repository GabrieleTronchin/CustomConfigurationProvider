# Sample Project With SQL Configuration Provider

In this project, a custom configuration provider with reload functionality has been implemented.
The API project is a empty default Asp.net project, the SQL provider is realized within the project under the name: SQLConfigurationProvider, leveraging Dapper for data retrieval from SQL.

**Basic explanation of configuration providers**

> Configuration providers allow developers to retrieve configuration data from various sources, such as JSON files, environment variables, and Azure Key Vault. These configuration sources are abstracted behind a unified API.

Useful link:

https://learn.microsoft.com/en-us/dotnet/core/extensions/custom-configuration-provider
