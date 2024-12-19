# JanTaskTracker
Full-stack task and employee management app with CRUD functionality for projects, tasks, employees, departments, and roles using ASP.NET Core, Angular, Bootstrap, and SQL Server.

Process:
<ul>
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
      <li></li>
    </ul>
  </li>

</ul>