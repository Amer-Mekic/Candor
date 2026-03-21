# Candor - Public Product Feedback Board
 
> **Stack:** .NET 10 · React.js · PostgreSQL · Docker · GitHub Actions  
> **Goal:** A Canny/UserVoice-style app where users submit feature requests, vote, and track status.
 
---

## 1. Project Overview
  
| Feature | Description |
|---|---|
| Submit ideas | Any user can post a feature request with title and description |
| Upvote | One vote per user per idea; toggle on/off |
| Status tracking | Admin marks ideas as Under Review / Planned / In Progress / Done |
| Comments | Users discuss ideas in a thread |
| Auth | Email/password + JWT |
| Admin panel | Moderate posts, change status, pin announcements |
 
### High-Level Architecture
 
```
┌──────────────┐     HTTPS      ┌──────────────────────┐
│  React       │ ─────────────▶ │  .NET 10 Web API     │
│  (Vite)      │ ◀───────────── │  (ASP.NET Core)      │
└──────────────┘   JSON/REST    └────────┬─────────────┘
                                         │
                              ┌──────────▼──────────┐
                              │   PostgreSQL 18     │
                              │   (EF Core)         │
                              └─────────────────────┘
```
 
All three services run as Docker containers orchestrated with Docker Compose locally.
 
### Key Design Decisions
 
- **Minimal dependencies** — EF Core for ORM, no extra ORMs or CQRS frameworks.
- **JWT auth** — stateless, easy to scale. Refresh tokens stored in the DB.
- **Soft deletes** — posts are never hard-deleted; `IsDeleted` flag lets admins restore.
- **Optimistic voting** — frontend updates count immediately, rolls back on error.
- **Cursor-based pagination** — scales better than OFFSET for large idea lists.
 
---
 
## 2. Data Model
 
### Entity Relationship Diagram
 
![Entity Relationship Diagram](docs/ERD-Candor.svg)

## Database

The database consists of six entities: **User**, **Idea**, **Category**, **Vote**, **Comment**, and **RefreshToken**.

### Entities & Relationships

**User** is the central entity. A user can author zero or more Ideas, write zero or more Comments, cast zero or more Votes, and hold zero or more RefreshTokens (one is created per login session). A user does not need to have any of these to exist in the system.

**Idea** is submitted by exactly one User. It optionally belongs to one Category, and a Category can group many Ideas. An Idea can have zero or more Votes and zero or more Comments.

**Vote** is a join between one User and one Idea, both mandatory. A user may vote on many Ideas, and an Idea may receive votes from many Users, but the combination of User and Idea is unique, so a user cannot vote on the same idea twice.

**Comment** belongs to exactly one Idea and is written by exactly one User, both mandatory. Comments support threading: a Comment optionally has a parent Comment (also in the same table), allowing one Comment to have zero or more direct replies, forming a recursive tree structure.

**Category** is an independent entity used to classify Ideas. It has no mandatory relationships, so a Category can exist with no Ideas assigned to it yet.

**RefreshToken** belongs to exactly one User and represents an active login session. A User can have many RefreshTokens across different devices or browsers.