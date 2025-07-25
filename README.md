# 💰 Personal Finance Manager with Multi-Account Support / Gerenciador Financeiro Pessoal com Múltiplas Contas

This is a desktop application built with **.NET (Windows Forms)** using **modern architectural patterns** like Clean Architecture and Domain-Driven Design (DDD).  
The purpose is to provide a simple yet powerful personal finance management solution for end users.

Este é um aplicativo desktop construído com **.NET (Windows Forms)** utilizando padrões arquiteturais modernos como **Clean Architecture** e **DDD**.  
O objetivo é oferecer uma solução simples e poderosa de controle financeiro pessoal para usuários finais.

---

## 📦 Tech Stack / Tecnologias

-   C# (.NET)
-   Windows Forms (UI)
-   SQLite (Local Database)
-   Entity Framework Core
-   ClosedXML (Excel Export)
-   iTextSharp (PDF Export)
-   BCrypt.Net (Encryption)
-   FluentValidation
-   Clean Architecture

---

## 🧱 Project Structure / Estrutura do Projeto

```
/FinanceApp
│
├── FinanceApp.Domain           # Domain layer: entities, interfaces, enums, value objects
├── FinanceApp.Application      # Application layer: services, use cases, DTOs
├── FinanceApp.Infrastructure   # Infra layer: database (SQLite), repositories, backup/export
├── FinanceApp.UI               # Presentation layer: Windows Forms
├── FinanceApp.Config           # Configuration: settings, DI, startup
├── FinanceApp.Tests            # Unit & integration tests
└── README.md                   # Project info
```

---

## ✅ Features / Funcionalidades

-   ✅ Multi-bank account management / Gerenciamento de múltiplas contas bancárias
-   ✅ Add/edit/delete incomes and expenses / Cadastro de receitas e despesas
-   ✅ Categorization (Food, Transport, etc.) / Classificação por categorias
-   ✅ Monthly spending reports / Relatórios mensais de gastos
-   ✅ Encrypted backup with password / Backup criptografado por senha
-   ✅ Export to Excel (.xlsx) and PDF / Exportação para Excel e PDF
-   ✅ Local SQLite database / Banco de dados local SQLite

---

## 🔐 Security / Segurança

-   Data encryption for backup files using user-defined password.
-   Passwords and sensitive data are stored hashed via **BCrypt**.

---

## 📈 Future Improvements / Melhorias Futuras

-   Cloud sync (OneDrive/Google Drive integration)
-   Mobile version (Xamarin/MAUI)
-   Notification for bill due dates
-   Dark mode

---

## 🚀 Getting Started / Primeiros Passos

1. Clone this repository:

```bash
git clone https://github.com/your-username/finance-app.git
```

2. Open `FinanceApp.sln` in **Visual Studio 2022+**

3. Restore dependencies and build the solution.

4. Run the application from the `FinanceApp.UI` project.

---

## 🧪 Tests / Testes

Run unit and integration tests from the `FinanceApp.Tests` project.

---

## 📄 License / Licença

[MIT License.](./LICENSE)

---

## ✉️ Contact / Contato

Carlos Eduardo  
[LinkedIn](https://www.linkedin.com/in/carlosecdasilva/) • [Email](mailto:carlos.eduardo.cs@outlook.com)
