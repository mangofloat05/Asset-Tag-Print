# Asset Tag Printer

This application prints asset tags from a CSV file to a POS printer.

## Architecture

The application is a .NET console application. It reads a CSV file containing asset information, and for each row, it formats and prints an asset tag using a connected POS printer.

## How to Run

1.  **Prerequisites**:
    *   .NET SDK
    *   A POS printer compatible with POS for .NET.
    *   `Microsoft Point of Service for .NET v1.14` (POS for .NET) SDK must be installed. This will typically install the necessary assemblies in the `C:\Program Files (x86)\Microsoft Point of Service\` directory.

2.  **Project Setup**:
    *   The project is configured to reference the `Microsoft.PointOfService.dll` assembly from the standard installation path of the POS for .NET SDK. If you have installed the SDK in a different location, you may need to update the project file (`AssetTagPrinter.csproj`).

3.  **Running the application**:
    *   Place a `data.csv` file in the same directory as the executable. The CSV file should have a header and columns for asset details (e.g., `ItemName`, `SKU`, `Price`).
    *   Run the application from the command line:
        ```bash
        dotnet run
        ```

## Design Decisions

*   **POS for .NET**: The application uses the `Microsoft.PointOfService` library as specified, which is the standard for interacting with POS devices on Windows.
*   **CSV Input**: A simple CSV file is used for input to make it easy for users to provide asset data.
*   **Console Application**: A console application was chosen for simplicity and to focus on the core functionality of printing.
