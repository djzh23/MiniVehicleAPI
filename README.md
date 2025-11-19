# MiniVehicleAPI

[![Build Status](https://img.shields.io/badge/build-passing-brightgreen.svg)](https://github.com/djzh23/MiniVehicleAPI/actions)
[![.NET](https://img.shields.io/badge/.NET-9.0-purple.svg)](https://dotnet.microsoft.com/download/dotnet/9.0)
[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT)

A robust and modern REST API for vehicle management, built with **Clean Architecture** and **.NET 9**.

---

## 🚀 Live Demo 

- ##### create a customer / get customers
![GIF showing how to create a customer with Swagger](assets/images/create-customer-demo.gif)

---

## ✨ Core Features

This project goes beyond simple CRUD operations to showcase industry best practices and advanced architectural concepts.

-   🏗️ **Scalable Architecture:** Built on **Clean Architecture** principles to ensure long-term maintainability, testability, and a clear separation of concerns.
-   🚀 **High-Performance Core:** Powered by **.NET 9** framework, delivering exceptional performance and access to modern C# features.
-   🗄️ **Robust Data Persistence:** Utilizes **Entity Framework Core** with a reliable **PostgreSQL** database for efficient and secure data management.
-   ✅ **Quality Assured:** Features a comprehensive suite of **unit tests** to guarantee code correctness and prevent regressions.
-   🐳 **Seamless Deployment:** Fully containerized with **Docker** and Docker Compose for a consistent, one-command setup in any environment.
-   🔍 **Intelligent Validation:** Implements smart validation logic, including unique checks for Vehicle Identification Numbers (VINs), to enforce data integrity at the API level.

---

## 🛠️ Tech Stack

![C#](https://img.shields.io/badge/c%23-%23239120.svg?style=for-the-badge&logo=c-sharp&logoColor=white)
[![.NET](https://img.shields.io/badge/.NET-9.0-5C2D91?style=for-the-badge&logo=.net&logoColor=white)](https://dotnet.microsoft.com/download/dotnet/9.0)
![PostgreSQL](https://img.shields.io/badge/PostgreSQL-316192?style=for-the-badge&logo=postgresql&logoColor=white)
![Docker](https://img.shields.io/badge/docker-%230db7ed.svg?style=for-the-badge&logo=docker&logoColor=white)

---

## 🏁 Quick Start

Clone the repository and launch the entire application (including the database) with Docker Compose.

```bash
git clone https://github.com/djzh23/MiniVehicleAPI.git
cd MiniVehicleAPI
docker-compose up --build
```