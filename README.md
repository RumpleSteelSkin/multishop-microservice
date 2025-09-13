# 🛒 MultiShop Microservices Project

**MultiShop** is a **.NET educational project** designed with microservice architecture, enriched with various modern technologies.  
The main goal is to practice **enterprise-level software development** and gain hands-on experience with **modern tools and architectures**.  

---

## 🚀 Project Overview

### 🔹 Architectures
- Hybrid Architecture
- Microservices
- N-Tier Architecture
- Onion Architecture
- Polyglot Design
- Dependency Injection

### 🔹 Design Patterns
- CQRS
- DDD (Domain Driven Design)
- Mediator
- Repository

### 🔹 Databases
- **MSSQL**
- **PostgreSQL**
- **MongoDB**
- **Redis**
- **RabbitMQ**
- **Google Cloud Storage**

### 🔹 ORMs
- **Entity Framework Core**
- **Dapper**

### 🔹 Security
- Bearer Authentication
- IdentityServer
- JWT (JSON Web Token)
- OAuth 2.0

### 🔹 Tools
- DBeaver
- Docker
- JetBrains Rider
- Portainer
- Postman
- Swagger
- Visual Studio
- SSMS
- MongoDB Compass
- Redis Insight
- PgAdmin4

### 🔹 Frontend
- ASP.NET Core MVC
- Bootstrap
- Charts
- CSS, HTML, JavaScript, jQuery
- Google Fonts, FontAwesome
- Razor
- OwlCarousel
- Responsive Design
- SignalR

### 🔹 Libraries / NuGet Packages
- AutoMapper
- IdentityServer4
- MediatR
- Microsoft.AspNetCore.* packages
- EntityFrameworkCore (SqlServer, PostgreSQL, SQLite)
- MongoDB.Driver
- Serilog
- StackExchange.Redis
- Swashbuckle (Swagger)
- Ocelot
- Npgsql
- Google.Cloud.Storage
- RabbitMQ.Client
- MailKit

### 🔹 Others
- RapidAPI (Weather & Exchange APIs)
- Localization
- MailKit (SMTP Mail Sending)

---

## 🗄️ Databases & Services

The project runs multiple databases inside **Docker containers**.  

| Database      | Technology | Container |
|---------------|------------|-----------|
| MSSQL         | OrderDb    | Docker    |
| MSSQL         | IdentityDb | Docker    |
| MSSQL         | CommentDb  | Docker    |
| MSSQL         | CargoDb    | Docker    |
| MSSQL         | DiscountDb | Local     |
| PostgreSQL    | MessageDb  | Docker    |
| MongoDB       | CatalogDb  | Docker    |
| Redis         | BasketDb   | Docker    |
| RabbitMQ      | Queue      | Docker    |

> 📌 All databases are managed via **Portainer**.  
> 📌 Connection strings are configured in `appsettings.json` files.  

---

## 📊 Overview

Running containers in Portainer:  

- BasketDb (Redis)  
- CargoDb (MSSQL)  
- CommentDb (MSSQL)  
- IdentityDb (MSSQL)  
- OrderDb (MSSQL)  
- CatalogDb (MongoDB)  
- MessageDb (PostgreSQL)  
- RabbitMQ (Message Queue)  
- RedisInsight (Redis UI)   
- Portainer (Container Management UI)  

---
