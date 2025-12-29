# AutomationPractice

AutomationPractice is a C# solution for automated web testing using SpecFlow, Selenium WebDriver, and NUnit. It demonstrates end-to-end browser automation targeting web features like login and interacting with dropdown menus.

## Features

- SpecFlow BDD support
- Selenium WebDriver for browser automation (Chrome by default, easily adaptable to Firefox)
- NUnit test framework integration
- Sample features: Login and Dropdown selection scenarios

## Getting Started

### Prerequisites

- Windows
- Visual Studio (2015 or later)
- .NET Framework 4.5.2 or later ([Install .NET 4.5.2 SDK](https://dotnet.microsoft.com/en-us/download/dotnet-framework/net452))
- [Chrome browser](https://www.google.com/chrome/) if running with default settings
- Chrome WebDriver executable (automatically referenced in `/Vendor` folder if populated by NuGet restore)

### Clone the Repository

```bash
git clone https://github.com/frankdoylezw/AutomationPractice.git
cd AutomationPractice
```

### Install Dependencies

In Visual Studio:
1. Open the solution `AutomationPractice.sln`.
2. Right-click the solution and select **Restore NuGet Packages**.
   - All necessary dependencies (Selenium WebDriver, SpecFlow, NUnit, etc.) from `packages.config` will be downloaded.

### Debugging and Running Tests

To start the project in Debug mode:

1. In Visual Studio, set the build configuration to `Debug`.
2. Restore NuGet packages if not done already.
3. Build the solution.
4. Open the **Test Explorer** window (`Test > Windows > Test Explorer`).
5. Click **Run All** or choose specific tests from the list.

> By default, tests will launch a Chrome browser instance using a driver from the `/Vendor` directory. Make sure ChromeDriver is correctly restored by NuGet; otherwise, download the driver manually and place it in `AutomationPractice/Vendor/`.

#### To run a SpecFlow Feature File

Right-click on a feature (such as `Features/Login.feature`) and select **Run SpecFlow Scenarios**.

### Editing the Browser Driver

To switch to Firefox, uncomment the relevant lines in [`Features/Hooks.cs`](https://github.com/frankdoylezw/AutomationPractice/blob/master/AutomationPractice/Features/Hooks.cs) and ensure GeckoDriver is available in the `Vendor` folder.

## Project Structure

- `AutomationPractice/Features/` – Feature files and hooks (SpecFlow)
- `AutomationPractice/PageObjects/` – Page Object Model classes
- `AutomationPractice/Steps/` – Step definitions for features
- `AutomationPractice/Vendor/` – Place ChromeDriver/GeckoDriver here if needed

## References

- [SpecFlow Documentation](https://specflow.org/)
- [Selenium WebDriver Documentation](https://www.selenium.dev/documentation/)
- [NUnit Documentation](https://nunit.org/)
