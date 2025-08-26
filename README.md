# PakoLibrary — Document Sharing Platform

The **PakoLibrary** project is an ASP.NET Core MVC–based web application designed for sharing documents. It enables users to upload, manage, categorize, and view documents efficiently.

---

## 🚀 Features

- **Document Management**: Upload, edit, and delete documents.
- **Categorization & Tagging**: Organize documents with categories and tags.
- **Filtering & Search**: Browse documents using search or filters.
- **User Authentication (Optional)**: Secure document access with user authentication (can be extended).
- **File Preview & Download**: View or download documents directly within the app.

---

## 📂 Project Structure

```
PakoLibrary/
├── Controllers/         # MVC controllers
├── Models/              # Application data models
├── Views/               # Razor views (frontend UI)
├── Filters/             # Custom action filters (e.g. logging, authorization)
├── Migrations/          # Entity Framework Core migration files
├── wwwroot/             # Static assets (CSS, JS, images)
├── Program.cs           # Application entry point
├── appsettings.json     # Configuration settings
└── PakoLibrary.csproj   # .NET project file
```

---

## 📦 Installation & Running Locally

1. **Clone the repository**

   ```bash
   git clone https://github.com/UmtiPako/PakoLibrary.git
   ```

2. **Navigate into the project directory**

   ```bash
   cd PakoLibrary
   ```

3. **Install dependencies**

   ```bash
   dotnet restore
   ```

4. **Update configuration**

   - Edit `appsettings.json` (or `appsettings.Development.json`) with your database connection details and any other necessary settings.

5. **Apply database migrations**

   ```bash
   dotnet ef database update
   ```

6. **Run the application**

   ```bash
   dotnet run
   ```

7. Open your browser and go to `https://localhost:5001` (or whichever port is configured).

---

## 🛠 Technology Stack

- **ASP.NET Core MVC** – Web framework
- **Entity Framework Core** – ORM for database access
- **C#** – Primary language
- **Static Assets** – CSS, JS, and front-end resources in `wwwroot/`

---

## 🤝 Contributing

We welcome contributions! To get started:

1. Fork the repository.
2. Create a feature branch:
   ```bash
   git checkout -b feature/YourFeatureName
   ```
3. Implement your changes and commit:
   ```bash
   git commit -m "Add feature: your description"
   ```
4. Push to your fork:
   ```bash
   git push origin feature/YourFeatureName
   ```
5. Submit a Pull Request for review.

---

## 📄 License

This project is licensed under the **MIT License**. Please see the [LICENSE](LICENSE) file for full details.

