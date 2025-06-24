# Employee Salary Management System – ASP.NET Core MVC

This is a simple yet functional web-based employee salary management system built using **ASP.NET Core MVC**. It allows users to manage employee records, calculate salaries based on given formulas, and perform CRUD operations with ease.

## 🎯 Features

- Add, Edit, Delete, and View employees
- Automatic salary calculation based on:
  - Dearness Allowance (40% of Basic)
  - Conveyance Allowance (10% of DA or ₹250 – whichever is lower)
  - House Rent Allowance (25% of Basic or ₹1500 – whichever is higher)
  - Professional Tax (slab-based deduction)
- Filter/search employees by name
- Display of net salary (without showing gross explicitly)
- Form validations and user-friendly input placeholders
- Gender dropdown with enforced selection
- Added datepicker using **Flatpickr**
- Clean Bootstrap UI

## 🧮 Salary Calculation Logic

**Earnings**
- **Dearness Allowance (DA)** = 40% of Basic
- **Conveyance Allowance (CA)** = 10% of DA or ₹250 (whichever is lower)
- **House Rent Allowance (HRA)** = 25% of Basic or ₹1500 (whichever is higher)

**Deductions**
- **Professional Tax (PT)**:
  - Gross ≤ 3000: ₹100
  - 3000 < Gross ≤ 6000: ₹150
  - Gross > 6000: ₹200

**Total Salary** = Basic + DA + CA + HRA – PT  
**(Gross is used for PT calculation but not displayed)**

## 💡 Technologies Used

- ASP.NET Core MVC (.NET 6 or later)
- In-Memory Database (EF Core)
- Bootstrap 5
- Flatpickr (for modern date picker)

## 📂 Folder Structure

Controllers/
└── EmployeeController.cs

Models/
├── Employee.cs
└── EmployeeViewModel.cs

Views/
└── Employee/
├── Index.cshtml
├── Create.cshtml (used for both Create & Edit)
└── Shared/
└── _Layout.cshtml

DbContext/
└── ApplicationContext.cs



## ⚙️ How to Run

1. Clone the repo  

2. Open the solution in Visual Studio 

3. Run the app  
   Hit `Ctrl + F5` or use `dotnet run`

4. Navigate to:  
   `https://localhost:5001/Employee/Index`

No database setup required – it uses EF Core’s in-memory DB for demo purposes.

## 🙌 Credits

This was built as a practical assignment/project for learning and demonstrating ASP.NET Core MVC CRUD operations with a real-world use case.


