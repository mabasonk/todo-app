# Todo Application

This repository contains a full-stack Todo application built with:

- **Backend:** ASP.NET Core Web API (.NET 8)
- **Frontend:** Angular 15

---

## Features

- Create, read, update, and delete todo items
- Backend stores todos with Entity Framework Core and SQLite (or other DB)
- Frontend interacts with backend via REST API
- Responsive UI built with Angular
- Integration tests included for backend API

---

## Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download)
- [Node.js & npm](https://nodejs.org/en/download/)
- [Angular CLI](https://angular.io/cli) (`npm install -g @angular/cli`)

---

## Setup & Run

### Backend (.NET API)

```bash
cd backend-folder
dotnet restore
dotnet ef database update
dotnet run
