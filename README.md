# Employee Management CLI

A simple command-line application built with C# to manage employee records. This project demonstrates fundamental object-oriented programming concepts like interfaces, inheritance, and sorting, while offering a user-friendly interactive menu system.

## Features

- **Add Employee**: Enter employee details such as ID, Name, Salary, and Gender.
- **Display Employees**: View all employee records.
- **Search Employee**: Look up employees by ID or Name.
- **Sort Employees**: Sort records by ID, Name, or Salary.
- **Exit**: Quit the application gracefully.

## Technical Highlights

- **Object-Oriented Design**:
  - Custom `Employee` class implementing `IComparable` for sorting by ID.
  - Additional comparers (`SortByName`, `SortBySalary`) implementing `IComparer` for sorting by other fields.
- **Interactive Menu**:
  - A dynamic menu interface for navigation using arrow keys.
  - User-friendly input handling and validation.
- **Error Handling**:
  - Recursive validation for invalid input.
  - Graceful handling of exceptions like `NullReferenceException`.

## Installation

1. Clone the repository:
   ```bash
   git clone https://github.com/YourUsername/Employee-Management-CLI.git
   ```
2. Navigate to the project directory
   ```bash
   cd Employee-Management-CLI
   ```
3. Open the project in your favorite IDE (e.g., Visual Studio).

## Usage
1. Build and run the project.
2. Use the arrow keys to navigate the menu and press Enter to select an option.
3. Follow the prompts to manage employee data.

## Project Video


https://github.com/user-attachments/assets/bd8231d9-8f0f-4bd5-9f6d-3fe91ac3812e

