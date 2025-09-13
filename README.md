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
## Images
<img width="1910" height="982" alt="Register" src="https://github.com/user-attachments/assets/2879538a-23c3-4eb8-a8e8-c771fe0e30ba" />
<img width="1914" height="987" alt="Login" src="https://github.com/user-attachments/assets/2186cbf2-7ba6-4069-8259-53f5be16d255" />
<img width="1901" height="990" alt="Default1" src="https://github.com/user-attachments/assets/9d5be9e1-8a22-446b-a1ca-f1cda07ebd05" />
<img width="1911" height="986" alt="Default2" src="https://github.com/user-attachments/assets/c7a7535e-3c90-49c3-b745-be83ee085c1a" />
<img width="1910" height="986" alt="Default3" src="https://github.com/user-attachments/assets/fbeca6a5-50a1-4ab1-afc4-b72cb9595103" />
<img width="1910" height="972" alt="Default4" src="https://github.com/user-attachments/assets/a24dac40-71f2-4a88-9a51-de8271113529" />
<img width="1910" height="972" alt="Default5" src="https://github.com/user-attachments/assets/f2976295-b25d-4ca6-9c75-82097e415125" />
<img width="1911" height="723" alt="AdminStatisticsIndex" src="https://github.com/user-attachments/assets/9a2879f8-7a1b-45b5-aebe-9ce96ffcc273" />
<img width="1914" height="1032" alt="AdminProductsUpdate" src="https://github.com/user-attachments/assets/89e55aab-b7eb-4386-896c-ce2cb8696638" />
<img width="1915" height="1013" alt="AdminProductsIndex" src="https://github.com/user-attachments/assets/fa241ac7-aa08-4fc9-8712-101b285eafe1" />
<img width="1900" height="600" alt="AdminFeatureSlidersIndex" src="https://github.com/user-attachments/assets/ce85a40a-d57b-49be-a64b-167b81e5b7dc" />
<img width="1916" height="618" alt="AdminFeaturesIndex" src="https://github.com/user-attachments/assets/d1b959eb-cb0b-4edb-b2ba-11d9efb4c558" />
<img width="1917" height="1025" alt="AdminCategoriesIndex" src="https://github.com/user-attachments/assets/712da178-24b0-4a16-9d43-1379af2a1233" />
<img width="1905" height="909" alt="Portainer" src="https://github.com/user-attachments/assets/4243ce83-c0fc-4ac9-b9fc-95533b0ca7e2" />
