# Weather Info API

This project contain a basic API to see informations of weather in some cities from Brazil.
The temperature is collect from [OpenWeather](http://openweathermap.org/) every 15 minutes, and save in a local text file.

With the API it's possible consult tempetures from the cities passing the name of city and a range of date (start and end). The result is a JSON structured with maily informations.

## Documentation

Inside of API, there is a Swagger page with routes created. Also, was created a little [Kanban](https://trello.com/b/IzeSIUwb/projeto-weatherinfo) to help me guide while coded (some tickets maybe isn't concluded).

### Other informations

The project was created using .NET Core, so a `dotnet run` it's all the is need to start the solution.