# E-commerce-.Net
I am creating a Ecommerce in .Net and Angular

## Database Model
Below is the entity-relationship diagram of the database. This model serves as the foundation for the backend architecture, enabling us to provide comprehensive e-commerce services.
```
+----------------+         +-----------------+         +---------------+
|     Users      |         |     Orders      |         |    Products   |
+----------------+         +-----------------+         +---------------+
| PK: Id         |<---+    | PK: Id          |         | PK: Id        |
| UserName       |    |    | UserId          |---+     | Name          |
| Email          |    +----| TotalAmount     |   |     | Description   |
| Password       |         | Status          |   |     | Price         |
| Address        |         | CreatedAt       |   |     | Stock         |
| Phone          |         | UpdatedAt       |   |     | CategoryId    |---+
| City           |         +-----------------+   |     +---------------+   |
+----------------+                |              |             ^           |
                                  v              v             |           |
                        +-----------------+    +---------------+           |
                        |   OrderItems    |    |   Payment     |           |
                        +-----------------+    +---------------+           |
                        | PK: Id          |    | PK: Id        |           |
                        | OrderId         |    | OrderId       |           |
                        | ProductId       |----| PaymentMethod |           |
                        | Quantity        |    | Amount        |           |
                        | PriceAtTime     |    | Status        |           v
                        +-----------------+    | TransactionId |    +---------------+
                                               +---------------+    |   Categories   |
                                                      |            +---------------+
                                                      |            | PK: Id        |
                        +-----------------+           |            | Name          |
                        |    Shipping     |           |            | Description   |
                        +-----------------+           |            +---------------+
                        | PK: Id          |           |
                        | OrderId         |<----------+
                        | ShippingAddress |
                        | City            |
                        | Country         |
                        | RecipientName   |
                        | Status          |
                        | TrackingNumber  |
                        +-----------------+
```

## 📋 Requisitos Previos
- [.NET SDK 9.0](https://dotnet.microsoft.com/download)
- [PostgreSQL 17+](https://www.postgresql.org/download/)
- [Git](https://git-scm.com/)
- IDE recomendado: [Visual Studio Code](https://code.visualstudio.com/) o [Rider](https://www.jetbrains.com/rider/)

## 🚀 Inicialización del Proyecto

### 1. Clonar el repositorio
```bash
git clone https://github.com/tu-usuario/NuevoProyectoBackend.git
cd NuevoProyectoBackend/NuevoProyecto.API
```

### 2. Configuración de la base de datos
- Crea una base de datos en PostgreSQL:
```
CREATE DATABASE nuevo_proyecto_db;
``` 
-Configura la cadena de conexión en appsettings.json:
```
"ConnectionStrings": {
  "DefaultConnection": "Host=localhost;Database=nuevo_proyecto_db;Username=postgres;Password=tu_contraseña;Port=5432"
}
```

### 3. Instalar dependencias
```
dotnet restore
dotnet ef migrations add InitialCreate
dotnet ef database update
```

### 4. Ejecutar la aplicación
```
dotnet run
```

## 🧩 Arquitectura del Proyecto: Interfaces y Clases Genéricas

### Estructura de capas
se hace una base de la arquitectura de software que esta utilizando. Es un microservicio, en el cual, contiene interface genericas de servicios, repositorios y clases genericas para servicios y repositorio que se pueden utilizar en cada clase. A continuación, se deja  la documentación aca abajo con UserService para que se tenga en cuentas para los demas modelos:
```
src/
├── Core/
│   ├── Entities/
│   │   ├── BaseEntity.cs          # Clase base para todas las entidades
│   │   ├── Category.cs            # Categoría de productos
│   │   ├── Order.cs               # Pedido realizado por usuario
│   │   ├── OrderItem.cs           # Elemento individual de un pedido
│   │   ├── Payment.cs             # Información de pago
│   │   ├── Product.cs             # Producto del catálogo
│   │   ├── Shipping.cs            # Información de envío
│   │   └── Users.cs               # Usuario del sistema
│   └── Interfaces/
│       ├── IGenericRepository.cs  # Interfaz genérica para operaciones CRUD
│       ├── IGenericService.cs     # Interfaz genérica para servicios
│       ├── IUserRepository.cs     # Interfaz específica para repositorio de usuarios
│       └── IUserService.cs        # Interfaz específica para servicio de usuarios
├── Infrastructure/
│   ├── Data/
│   │   └── ApplicationDbContext.cs # Contexto de base de datos (EF Core)
│   └── Repositories/
│       ├── GenericRepository.cs    # Implementación genérica de repositorio
│       └── UserRepository.cs       # Implementación de repositorio de usuarios
├── Application/
│   ├── DTOs/
│   │   ├── LoginDto.cs             # DTO para login de usuarios
│   │   ├── RegisterDto.cs          # DTO para registro de usuarios
│   │   └── UserDto.cs              # DTO para transferir datos de usuario
│   ├── Services/
│   │   ├── GenericService.cs       # Implementación genérica de servicios
│   │   └── UserServices.cs         # Implementación de servicio de usuarios
│   └── Mappings/
│       └── UserProfile.cs          # Perfiles de AutoMapper
└── Web/
    └── Controllers/
        └── UserController.cs       # Controlador de usuarios
```
