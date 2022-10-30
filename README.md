# DroneManagement

Made for demo purposes, this program creates 2 HTTP APIs. Both APIs support standard CRUD operations.
The project is written in ASP.NET Core, using docker for hosting.

## Launching the API
Download the project by either cloning the repo or download it as a ZIP.

Note: Drone API Endpoint named "Simulate HW Fault" does not function the this time.

Note2: Due to a small brain fart in terms of language terminology, one API has been named "Service".
Do take note that this API uses the term "Service" in a repair/maintenance scope. Not in a computer science scope. This is consistent throughout the whole code base.

### Manually/CLI
1. Navigate to the root folder of the project
2. Run the command `docker-compose up`
3. Wait for downloads to finish
4. Swagger access is available through `https://localhost:3000/swagger/index.html` and `http://localhost:3001/swagger/index.html`

### Visual Studio
1. Open Visual Studio and go to File -> Open -> Project/Solution
2. Select the .sln file in the project root
3. Press the "Docker Compose" prompt in the top 