# JanTaskTracker
Full-stack project task and employee management app with CRUD functionality for projects, tasks, employees, departments, and roles using ASP.NET Core, Angular, Bootstrap, and SQL Server.

Process:
<ul>
  <li>SQL Server Management Studio
    <ul>
      <li>Connect to Server
        <ul>
          <li>Server Type: Database Engine</li>
          <li>Server Name: localhost</li>
          <li>Authentication: Windows Authentication</li>
          <li>Connect</li>
        </ul>
      </li>
      <li>Create a new Database
        <ul>
          <li>In the <strong>Object Explorer</strong>, right-click on Databases and select <strong>New Database</strong></li>
          <li>Database Name: TaskTrackrDb</li>
        </ul>
      </li>
      <li>Configure a User
        <ul>
          <li>Expand the <strong>Security</strong> node.</li>
          <li>Right-click <strong>Logins</strong> and select <strong>New Login</strong></li>
          <li>In the <strong>Login - New</strong> dialog:
            <ul>
              <li>Login Name: Enter a username</li>
              <li>Authentication: Choose SQL Server Authentication and set a password.</li>
            </ul>
          </li>
          <li>In the left panel, go to <strong>User Mapping</strong>, check your database (TaskTrackrDb), and assign the db_owner role.</li>
        </ul>
      </li>
      <li>Configure the Connection String in appsettings.json
        <ul>
          <li><code>"DefaultConnection": "Server=(localdb)\\MSSQLLocalDB;Database=TaskTrackrDb;Trusted_Connection=True;"</code></li>
        </ul>
      </li>
    </ul>
  </li>
  <li>Create ASP.NET Core API
    <ul>
      <li>Add Required NuGet Packages
        <ul>
          <li><code>Microsoft.EntityFrameworkCore</code></li>
          <li><code>Microsoft.EntityFrameworkCore.SqlServer</code></li>
          <li><code>Microsoft.EntityFrameworkCore.Tools</code></li>
        </ul>
      </li>
      <li>Create Models(Department, Role, Employee, Project, ProjectTask) with data annotations.</li>
      <li>Create DTOs to transfer only the required data between the client and server. Also to avoid exposing the navigation properties that cause cycles.
        <ul>
          <li>DTOs allow you to shape the data sent to the client and avoid exposing the navigation properties that cause cycles.
          </li>
        </ul>
      </li>
      <li>Create Database Context JanTaskTrackerDbContext
        <ul>
          <li>This serves as a bridge between the application and the database using Entity Framework Core.</li>
          <li>DbContext is used for querying data, tracking changes, saving data and managing relationships.</li>
          <li>Restrict delete behavior to prevent cascading deletes for roles and departments.</li>
        </ul>
      </li>
      <li>Create Controllers for each Model.</li>
      <li>Configure Program.cs to use connection string to SQL Server</li>
      <li>Create migrations and apply to the database to create tables
        <ul>
          <li>Add Migration: ~<code>dotnet ef migrations add InitialCreate</code></li>
          <li>Apply Migration: ~<code>dotnet ef database update</code></li>
        </ul>
      </li>
      <li>Seed database with dummy data
        <ul>
          <li>Create SeedData.cs.</li>
          <li>Modify Program.cs to call the <code>SeedData.Initialize</code> method during application startup.</li>
          <li>Add migrations and apply to the database to create tables
            <ul>
              <li>Add Migration: ~<code>dotnet ef migrations add SeedDataMigration</code></li>
              <li>Apply Migration: ~<code>dotnet ef database update</code></li>
            </ul>
          </li>
          <li>Clean and Recreate Database (Development Only)
            <ul>
              <li>~<code>dotnet ef database drop</code></li>
              <li>~<code>dotnet ef migrations remove</code></li>
              <li>~<code>dotnet ef migrations add InitialCreate</code></li>
              <li>~<code>dotnet ef database update</code></li>
            </ul>
          </li>
        </ul>
      </li>
      <li>Test all methods on Swagger.
      </li>
    </ul>
  </li>
  <li>Frontend with Angular and Bootstrap
    <ul>
      <li>Create models(Department, Role, Employee, Project, ProjectTask).</li>
      <li>Create services to handle communication with the database.</li>
      <li>Install Bootstap: ~<code>npm install bootstrap</code></li>
      <li>Create components for project-list and user-list.</li>
    </ul>
  </li>

</ul>

Projects List
<img src="/screenshots/1-ProjectsList.png"><br>

Create New Project
<img src="/screenshots/2-CreateNewProject.png"><br>

Edit Project
<img src="/screenshots/3-EditProject.png"><br>

Add Project Task
<img src="/screenshots/4-AddProjectTask.png"><br>

Edit Project Task
<img src="/screenshots/5-EditProjectTask.png"><br>

Add Employee
<img src="/screenshots/6-AddEmployee.png"><br>

Edit Employee
<img src="/screenshots/7-EditEmployee.png"><br>

Add Department
<img src="/screenshots/8-AddDepartment.png"><br>

Edit Department
<img src="/screenshots/9-EditDepartment.png"><br>

Add Role
<img src="/screenshots/10-AddRole.png"><br>

Edit Role
<img src="/screenshots/11-EditRole.png"><br>