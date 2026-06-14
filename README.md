# KMC Event Management System

## Project Overview

KMC Event Management System is a web-based application developed using ASP.NET Core MVC, ASP.NET Web API, Entity Framework Core, and SQL Server. The system enables users to register, log in, view events, register for events, and manage event-related information efficiently.

---

## Features

### User Management
- User Registration
- User Login
- Role-based User Management (Participant / Organizer)

### Event Management
- View Available Events
- Event Details Page
- Event Registration

### Registration Management
- Register for Events
- View Registered Events

### Database Management
- SQL Server Database Integration
- Entity Framework Core ORM
- Relational Database Design

---

## Technologies Used

### Frontend
- ASP.NET Core MVC
- Razor Views
- Bootstrap 5
- HTML5
- CSS3

### Backend
- ASP.NET Core Web API
- C#

### Database
- Microsoft SQL Server
- Entity Framework Core

### Development Tools
- Visual Studio 2022
- SQL Server Management Studio (SSMS)
- GitHub

---

## System Modules

### Account Module
- User Registration
- User Login

### Event Module
- Event Listing
- Event Details

### Registration Module
- Event Registration
- Registered Events View

---

## Database Tables

### Users
- UserId
- FullName
- Email
- Password
- Role

### Events
- EventId
- Title
- Category
- Description
- EventDate
- Location
- OrganizerId

### Registrations
- RegistrationId
- UserId
- EventId
- RegistrationDate

---

## Installation Guide

### Clone Repository

```bash
git clone https://github.com/afeefshafi/KMC-Event-Management-System.git
```

### Open Project

Open:

```text
KMCEventManagement.sln
```

using Visual Studio 2022.

### Database Setup

1. Open SQL Server Management Studio.
2. Create a database named:

```sql
KMCEventDB
```

3. Execute the provided:

```text
EventManagementDB.sql
```

script.

### Run Application

1. Set Multiple Startup Projects.
2. Start both:
   - KMCEventManagement (API)
   - KMCEventManagement.Web (MVC)

3. Press F5.

---

## Author

**Afeef Shafi**

Higher Diploma in Computing & Software Engineering  
Cardiff Metropolitan University, UK

---

## License

This project was developed for academic purposes as part of the SOC (Software Engineering and Operations) module assessment.
