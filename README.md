# MedReminder

Web system for managing medicine reminders, built with ASP.NET Core 9 Web API and Blazor WebAssembly.

🔗 Live demo: **https://med-lembrete-de-remedios.vercel.app**

## About the project

MedReminder is a web application that allows full control over ongoing or temporary medications. Each user can register their medicines, set intake times, mark doses as taken, and track treatment adherence history, with an authentication system and data isolation.

The project is split into two parts: a **Web API** in ASP.NET Core 9 that exposes the endpoints and handles persistence, and a **Blazor WebAssembly frontend** that consumes the API and runs entirely in the browser.

## How to test

Go to **https://med-lembrete-de-remedios.vercel.app** and you can:

1. **Create an account** — sign up with an email and password to get your own isolated area
2. **Register your medicines** — enter name, dosage, times, and treatment duration
3. **Mark doses** — confirm each dose taken and track the history

The API is hosted on Render's free plan. The first visit may take up to 30 seconds to load (cold start).

## Features

- User registration and login (ASP.NET Identity)
- Full medicine CRUD (create, list, edit, delete)
- Configuring intake times for each medicine
- Marking doses as taken, with date and time logging
- Treatment adherence history
- Notifications/reminders at the configured times (***THE APP MUST BE OPEN FOR THIS TO WORK!!!***)
- Data isolation: each user only sees their own medicines
- User feedback messages (success/error)
- Responsive interface

## Technologies

- **ASP.NET Core 9 Web API** — backend and REST endpoints (Minimal APIs)
- **Blazor WebAssembly** — SPA frontend running in the browser
- **Entity Framework Core 9** — ORM
- **ASP.NET Identity** — authentication and authorization
- **PostgreSQL (Neon)** — cloud database
- **Docker** — backend containerization
- **GitHub Actions** — CI/CD with automated build and deploy
- **Render** — Web API hosting
- **Vercel** — Blazor WASM frontend hosting
- **GitHub** — version control


## Deploy

Deployment is fully automated via **GitHub Actions**. On every push to the `main` branch, the `deploy.yml` workflow triggers two jobs in parallel:

- **Build and Deploy API (Render)** — builds the backend, publishes the Docker image, and triggers the deploy on Render. EF Core migrations are applied automatically on application startup.
- **Build and Deploy Frontend (Vercel)** — builds the Blazor WebAssembly project and publishes the static files to Vercel.



## Author

Ariel Mariussi

- Portfolio: **https://portfolio-ariel-cyan.vercel.app/**
- GitHub: **[@ArielMariussi](https://github.com/ArielMariussi)**
- Email: **[arielmariussi@gmail.com](mailto:arielmariussi@gmail.com)**
