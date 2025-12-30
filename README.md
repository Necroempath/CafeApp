Cafe Management Application
Overview

Cafe Management Application is a desktop application built with C# and WPF that provides a unified interface and business logic for managing core cafe operations.
The system covers order processing, table management, waiter workflow, and payments, focusing on clean architecture, separation of concerns, and scalability.

The project is designed as an educational and architectural example of a modern .NET desktop application using proven patterns and practices.

Core Features

• Create, edit, and manage customer orders
• Assign orders to waiters
• Manage tables and their availability
• Track payments and order status
• Centralized UI for operational control

Architecture

The application follows the MVVM (Model–View–ViewModel) pattern to strictly separate UI, presentation logic, and domain logic.

Key Principles

• No business logic in Views
• ViewModels expose state and commands only
• Models represent domain and persistence layer
• All dependencies are injected
• Database schema is generated from code (Code First)

Technologies Used

• C#
• WPF
• MVVM
• Entity Framework Core
• Microsoft SQL Server
• EF Core Code First
• Microsoft.Extensions.DependencyInjection
• ICommand (Command pattern)

Dependency Injection

The application uses Microsoft’s built-in Dependency Injection container to manage object lifetimes and dependencies.

DI is used for:

• ViewModels
• Services
• Repositories
• DbContext

This approach improves testability, modularity, and long-term maintainability.

Data Access

Entity Framework Core is used as the ORM.

• Code First approach
• Strongly typed domain models
• Clear separation between data access and UI logic
• Automatic database schema generation and migration support

Command Pattern

UI interaction is implemented using the Command pattern via ICommand.

• Buttons and UI actions are bound to commands
• Commands delegate execution to ViewModels
• No code-behind logic for business actions

This ensures a clean and testable interaction layer.

Project Structure (Conceptual)

• Models – domain entities (Order, Waiter, Table, Payment)
• ViewModels – presentation logic and state
• Views – WPF UI (XAML)
• Services – business logic
• Data – EF Core DbContext and configurations
• Infrastructure – dependency injection setup
