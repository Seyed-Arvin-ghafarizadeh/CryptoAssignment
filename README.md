# Crypto Assignment – ASP.NET Core MVC

## 📌 Project Overview

This project is a simple **ASP.NET Core MVC web application** that allows a user to enter a **cryptocurrency code** (for example: `BTC`) and view its value converted into multiple currencies.

The application demonstrates:
- ASP.NET Core MVC fundamentals
- API consumption using `HttpClient`
- Clean code and separation of concerns
- Basic error handling

---

## 🎯 User Story

As a user running the application  
I can enter a cryptocurrency code (e.g. BTC)  
So that I can see its value in different currencies

---

## ✅ Acceptance Criteria

- The application accepts a cryptocurrency code (e.g. `BTC`)
- Values are shown for the following currencies:
  - USD
  - EUR
  - BRL
  - GBP
  - AUD
- For known codes such as `BTC`, results are displayed correctly
- The project builds and runs in one step

---

## 🧩 Technical Details

- **Framework:** ASP.NET Core MVC
- **Language:** C#
- **API Used:** FastForex API (currency exchange rates)
- **IDE:** Visual Studio Code
- **Runtime:** .NET 7 / .NET 8

> Note: Cryptocurrency prices in USD are hardcoded for demonstration purposes, while currency conversions are done using live exchange rates from FastForex.

---

## 🌐 API Integration

### FastForex API
Used to fetch real-time currency exchange rates.

Example endpoint:
