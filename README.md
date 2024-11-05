
# Cron Expression Decoder 🕒
![image](https://github.com/user-attachments/assets/ddcde2ca-4348-4264-826a-7efd239e37e6)

A robust command-line tool for parsing cron expressions with clean architecture and SOLID principles.

## 🚀 Features

### ✨ Comprehensive Parsing

- Standard cron expressions with 5 time fields plus command
- Support for lists (e.g., `1,2,3`)
- Range expressions (e.g., `1-5`)
- Step values (e.g., `*/15`)
- All values (`*`)

### 🔧 Technical Highlights

- SOLID principles implementation
- Design patterns (Builder, DI)
- Fluent validation
- Comprehensive test coverage
- Clean architecture

## 📋 Prerequisites

- .NET 6.0 SDK or later
- Visual Studio 2022 (optional)

## 🎯 Quick Start

### Installation

Clone the repository:

```bash
git clone https://github.com/mahmutefe/CronExpressionDecoder.git
cd CronExpressionDecoder
```

Build the project:

```bash
dotnet build
```

Run the tests:

```bash
dotnet test
```

### Usage

Run the parser with a cron expression:

```bash
dotnet run -- "*/15 0 1,15 * 1-5 /usr/bin/find"
```

Example output:

```plaintext
minute        0 15 30 45
hour          0
day of month  1 15
month         1 2 3 4 5 6 7 8 9 10 11 12
day of week   1 2 3 4 5
command       /usr/bin/find
```

## 🏗️ Project Structure

```plaintext
CronParser/
├── 📁 Models/
│   ├── CronField.cs
│   └── CronExpression.cs
├── 📁 Services/
│   ├── 📁 Interfaces/
│   │   ├── ICronFieldParser.cs
│   │   ├── ICronExpressionValidator.cs
│   │   └── ICronExpressionParser.cs
│   └── 📁 Implementations/
│       ├── CronFieldParser.cs
│       ├── CronExpressionValidator.cs
│       └── CronExpressionParser.cs
├── Program.cs
└── 📁 Tests/
    ├── CronFieldParserTests.cs
    ├── CronExpressionValidatorTests.cs
    └── CronExpressionParserTests.cs
```

## 🎨 Design Patterns & Principles

### SOLID Principles

- **Single Responsibility**: Each class has a single, well-defined purpose
- **Open/Closed**: New cron expression formats can be added without modifying existing code
- **Liskov Substitution**: All implementations are substitutable for their base abstractions
- **Interface Segregation**: Granular interfaces for specific responsibilities
- **Dependency Inversion**: High-level modules depend on abstractions

### Design Patterns

- **Dependency Injection**: Used for loose coupling and better testability
- **Builder Pattern**: For constructing CronExpression objects
- **Strategy Pattern**: For different parsing strategies
- **Factory Method**: For creating parser instances

## 🧪 Testing

The project includes comprehensive unit tests using xUnit:

```bash
dotnet test --verbosity normal
```

Test categories include:

- Field parsing tests
- Expression validation tests
- Integration tests
- Edge cases

## 📝 Examples

### Basic Usage

```csharp
var parser = serviceProvider.GetRequiredService<ICronExpressionParser>();
var result = parser.Parse("*/15 0 1,15 * 1-5 /usr/bin/find");
Console.WriteLine(result.FormatOutput());
```

### Custom Validation

```csharp
var validator = new CronExpressionValidator();
validator.Validate("*/15 0 1,15 * 1-5 /usr/bin/find");
```

## 🤝 Contributing

1. Fork the repository
2. Create your feature branch (`git checkout -b feature/AmazingFeature`)
3. Commit your changes (`git commit -m 'Add some AmazingFeature'`)
4. Push to the branch (`git push origin feature/AmazingFeature`)
5. Open a Pull Request

## 📜 License

This project is licensed under the MIT License - see the LICENSE file for details.

## 🙏 Acknowledgments

- Thanks to all contributors
- Inspired by Unix cron syntax

## 📧 Contact

Your Name - [@mahmutefe](#)  
Project Link: [https://github.com/mahmutefe/CronExpressionDecoder](https://github.com/mahmutefe/CronExpressionDecoder)
