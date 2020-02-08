# URL Shortener

This project encodes long URLs to short ones and keeps them in Postgres Database which is connected to the .NET Core webapi project with Entity Framework.

## Getting Started

To get you a copy of the project up your system and to run and build it on your local machine pay attention to Prerequisites and execute the following commands.

### Prerequisites

Make sure you have Postgres installed. Clone the project and then change directory to the src directory.  i.e.`./src`

```bas
cd src
```



To add new migration files and to update the database execute the following commands while you're in src directory.

```bash
dotnet ef migrations add urlshortener.DbMig1
dotnet ef database update
```

### Building and Running

Go to the src directory and get all NuGet Packages with the following command.

```bash
dotnet restore
```

Then Build and Run the project:

```bash
dotnet build
dotnet run
```

You can then see the results on port 5000 or 5001 on your machine.

 [http://localhost:5000](http://localhost:5000/) 

 [http://localhost:5001](http://localhost:5001/) 

## The Logic of The Controllers

In the Post method the long URL given in JSON format will first be tested to see if it's validated. With the long URL being invalid the status with be 400. If the long URL is valid a short URL will be generated and the database will be updated with the two corresponding URLs. The results will be shown as a JSON format.

 [http://localhost:5000](http://localhost:5000/)/urls

In the Get method the program will search for the short URL in Database. If there is such short URL it will redirect to the corresponding long URL. If not the status will be 404.

 [http://localhost:5000](http://localhost:5000/)/asdfgASD