# Mini Task Manager API

A small in-memory task management system.

Goal: build a simple ASP.NET Core Web API without a database.

Use only:

- In-memory collections (`List`, etc.)
- MinimalApi
- Services
- Basic validation

---

# System Overview

The system manages tasks.

Each task contains:

- Title
- Description
- Priority
- CreatedAt
- Status

---

# Task Statuses

- New
- InProgress
- Done

---

# Business Rules

## Invalid operations

- A task cannot move directly from `New` to `Done`
- A completed task (`Done`) cannot be deleted

---

# Endpoints

---

## Create Task

### POST `/tasks`

Creates a new task.

---

## Get All Tasks

### GET `/tasks`

Supports filtering by:

- status
- priority

Example:

```http
GET /tasks?status=Done&priority=High
```

---

## Get Task By Id

### GET `/tasks/{id}`

Returns a single task.

---

## Start Task

### POST `/tasks/{id}/start`

Changes status:

```text
New -> InProgress
```

---

## Complete Task

### POST `/tasks/{id}/complete`

Changes status:

```text
InProgress -> Done
```

---

## Delete Task

### DELETE `/tasks/{id}`

Rules:

- Cannot delete tasks with status `Done`

---

## Get Statistics

### GET `/tasks/stats`

Returns:

- Total New tasks
- Total InProgress tasks
- Total Done tasks
- Total High Priority tasks

---

# Implementation Requirements

## 1. Use Only Task Methods

All endpoint handlers must return `Task` or `Task<T>`. Handlers should be declared as async methods.

Example:
```csharp
public async Task<IResult> CreateTask(CreateTaskDto dto, ITaskService service)
{
    // implementation
}
```

## 2. Use Only TypedResults

All responses must use `TypedResults` helpers:
- `TypedResults.Ok()`
- `TypedResults.Created()`
- `TypedResults.BadRequest()`
- `TypedResults.NotFound()`
- `TypedResults.Conflict()`

Example:
```csharp
return TypedResults.Ok(tasks);
return TypedResults.Created($"/tasks/{task.Id}", task);
return TypedResults.BadRequest(new { error = "Task cannot move from New to Done" });
```

## 3. Controller Implementation for Practice

Implement at least one endpoint operation in a **Controller** class (in addition to MinimalApi endpoints). This controller should:
- Use dependency injection for services
- Follow the same validation and business logic rules
- Return `TypedResults` responses
- Be async

Example:
```csharp
[ApiController]
[Route("api/[controller]")]
public class TasksController : ControllerBase
{
    private readonly ITaskService _service;
    
    public TasksController(ITaskService service) => _service = service;
    
    [HttpPost("{id}/complete")]
    public async Task<IResult> CompleteTask(int id)
    {
        // implementation using TypedResults
    }
}
```

---

# Suggested Structure

```text
Endpoints/
Services/
Models/
DTOs/
Controllers/
```

---

# Things To Practice

- REST API design
- Working with collections
- LINQ
- Validation
- Status transitions
- Separation of concerns
- Dependency Injection

---

# Bonus Features (Optional)

## Sorting

Support sorting by:

- priority
- createdAt

Example:

```http
GET /tasks?sortBy=createdAt
```

---

## Search

Search tasks by title.

Example:

```http
GET /tasks?search=report
```

---

## Auto Cleanup

Automatically remove tasks that were completed more than 10 minutes ago.

Hint:

Use `BackgroundService`.

---

## Request Logging

Add middleware that logs incoming requests.

---

# Difficulty Level

Beginner → Intermediate

Estimated time:

60–90 minutes


# Sql scripts
CREATE TABLE Priorities (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(50) NOT NULL UNIQUE
);

-- Insert priority values
INSERT INTO Priorities (Name) VALUES 
    ('Low'),
    ('Medium'),
    ('High');

-- Create TaskStatuses lookup table
CREATE TABLE TaskStatuses (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(50) NOT NULL UNIQUE
);

-- Insert status values
INSERT INTO TaskStatuses (Name) VALUES 
    ('New'),
    ('InProgress'),
    ('Done');

-- Create Tasks table
CREATE TABLE Tasks (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Title NVARCHAR(200) NOT NULL,
    Description NVARCHAR(MAX),
    PriorityId INT NOT NULL,
    StatusId INT NOT NULL DEFAULT 1, -- Default to 'New'
    CreatedAt DATETIME2 NOT NULL DEFAULT GETUTCDATE(),
    UpdatedAt DATETIME2 NOT NULL DEFAULT GETUTCDATE(),
    
    CONSTRAINT FK_Tasks_Priority FOREIGN KEY (PriorityId) 
        REFERENCES Priorities(Id),
    CONSTRAINT FK_Tasks_Status FOREIGN KEY (StatusId) 
        REFERENCES TaskStatuses(Id)
);
