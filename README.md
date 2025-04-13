# Console-Based Command Processor with Undo Functionality (C#)

This C# console application demonstrates the implementation of the Command design pattern to create a flexible and extensible command processor. It supports a variety of operations—increment, decrement, double, random addition—and includes an undo feature to revert the most recent command. The project emphasizes clean code architecture, efficient memory usage through design patterns (such as the Singleton), and object-oriented best practices.

## Features

### Command Pattern Implementation
- **Encapsulation of Commands:**  
  Each operation (increment, decrement, double, random addition) is implemented as a separate command class. This promotes loose coupling between the command invoker and the receiver.
  
- **Undo Functionality:**  
  A history stack is maintained to allow users to reverse the last executed command, ensuring reliable error correction.

- **Extensibility:**  
  New command operations can easily be added with minimal changes to existing code.

### Design Patterns and Best Practices
- **Singleton Pattern:**  
  The `ClassDecimalProcess` uses a Singleton pattern to manage a shared numeric state, ensuring that only one instance of the context exists during runtime.
  
- **Object-Oriented Principles:**  
  The solution leverages interfaces and modular classes (each command has `exec()` and `undo()` methods) to support scalable and maintainable code.

### User Interaction
- **Interactive Console Interface:**  
  The application prompts the user to input either a command name or its corresponding number. The menu is displayed in blue, while other text output appears in white.
  
- **Dynamic Input Handling:**  
  Users can view the current value, execute commands, and perform undo operations in real-time.

## Getting Started

### Prerequisites
- **.NET SDK:**  
  Ensure you have the .NET SDK installed (for example, .NET 6.0 or later).  
- **Development Environment:**  
  Use Visual Studio or Visual Studio Code for building and running the project.

### Building and Running the Application

1. **Clone the Repository:**
   ```bash
   git clone https://github.com/avazaghaei/command-processor.git
