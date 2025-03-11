Warehouse Management System - Project Description
Overview
The Warehouse Management System is a Windows Forms application developed using C#, Entity Framework Core (Code-First Approach), and SQL Server. This system helps a trading company efficiently manage multiple warehouses, track inventory, process supply and withdrawal orders, and facilitate the transfer of goods between different warehouses.

Key Features

✅ Warehouse Management: Add and manage multiple warehouses, each with a unique name and location.

✅ Item Management: Store detailed information about items, including name, category, and expiration date.

✅ Inventory Tracking: Monitor the stock levels of items across different warehouses.

✅ Supplier & Customer Management: Maintain records of suppliers and customers for smooth transactions.

✅ Supply Orders: Track incoming inventory from suppliers, including the quantity and manufacturing details.

✅ Withdrawal Orders: Manage outgoing inventory for customers and track stock depletion.

✅ Transfers Between Warehouses: Transfer stock from one warehouse to another with proper documentation.

✅ Reporting & Analysis: Generate reports on stock levels, expired items, and movement history.

Database Structure & Relationships
The system follows a relational database model with the following main relationships:

Warehouse (1) → (M) WarehouseItems (M) → (1) Item

Warehouse (1) → (M) SupplyOrder

Supplier (1) → (M) SupplyOrder

SupplyOrder (1) → (M) SupplyOrderDetails (M) → (1) Item

Warehouse (1) → (M) WithdrawalOrder

Customer (1) → (M) WithdrawalOrder

WithdrawalOrder (1) → (M) WithdrawalOrderDetails (M) → (1) Item

Warehouse (1) → (M) TransferOrder (M) → (1) Warehouse

TransferOrder (1) → (M) TransferOrderDetails (M) → (1) Item

Supplier (1) → (M) TransferOrderDetails

Technology Stack


Frontend: Windows Forms (C#)

Backend: C# (.NET 8)

Database: SQL Server (EF Core - Code First)

ORM: Entity Framework Core

Tools & Environment: Visual Studio, SQL Server Management Studio (SSMS), GitHub

Deployment & Execution

The project is built using Entity Framework Core Code-First Approach to manage the database schema.

Migrations are used to create and update the database structure dynamically.

The application supports user authentication and role-based access control (optional).

Expected Deliverables

Functional Windows Forms Application with a user-friendly interface.

Fully Configured SQL Server Database with all necessary relationships.

Detailed Reports & Analytics on warehouse stock and transactions.

Proper Error Handling & Validations to ensure data integrity.

This project ensures smooth warehouse operations, better inventory control, and efficient order management, making it an essential tool for any trading company dealing with multiple storage facilities. 🚀
