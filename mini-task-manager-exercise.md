# Mini Task Manager API

A small in-memory task management system.

Goal: build a simple ASP.NET Core Web API without a database.

Use only:

- In-memory collections (`List`, `Dictionary`, etc.)
- Controllers
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

# Suggested Structure

```text
Controllers/
Services/
Models/
DTOs/
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
