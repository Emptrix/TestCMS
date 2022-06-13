## MicroService with Web and Database in ASP WEB NET CORE

#### The Web interface allows 3 types of data manipulations: Add, Edit or Delete User Accounts.

- **Create User:** Automatically assigns a GUI ID. Username must be entered manually.
- **Edit:** Allows the User to edit the selected existing username.
- **Delete:** Deletes the User of choice
#### Username Constraints: 
- Alphanumeric only
- Must be in between 6-30 characters
- Must not contain White Spaces
### Installation procedure
- Open Visual Studio 2022, Open the Project.
- Once loaded, click on "View" -> "SQL Server Object Explorer".
- In the SQL Server Object Explorer Window, expand "SQL Server" and expand a localdb.
- Right click on "Databases" and click on "Publish Data-tier Application.
- Under File on disk, click on "Browse" and navigate to the Test.dacpac file.  Open it. 
- Type "Test" as Database name and "Test.sql" as Publish script name.
- Hit Publish.
- Once the process completes successfully, in the Solution Explorer Window, go to "TestCMS" -> "Pages" -> "Users" -> and open/double click on "Globals.cs".
- In the SQL Server Object Explorer at the left panel, look for the "Test" database under "Databases" in your localdb.
- Click on "Test" and in the properties window at the bottom right of Visual Studio, scroll and find "Connection String".
- Copy the value of "Connection String" and paste it into Globals, CONNECTION_STRING const string variable. 
- Finally Press the Green Play Button at the top and run the TestCMS. A Web Interface should open.
- Navigate to the "Users" page to view and edit the database.