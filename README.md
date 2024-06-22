# Sistema de Gestión de Usuarios y Roles - API REST con ASP.NET Core y JWT
Este repositorio contiene una aplicación completa para la gestión de usuarios y roles, desarrollada como parte de una prueba de desarrollo para FYM Technology. La aplicación consta de una API REST construida con ASP.NET Core y documentada con Swagger, así como una aplicación cliente para consumir los servicios REST.



## Características principales:
- Registro de nuevos usuarios: Permite a un super administrador pre-creado registrar nuevos usuarios.
- Autenticación y autorización: Basada en JWT (JSON Web Tokens) para asegurar la API.
- Asignación de roles: Gestión de roles y asignación de estos a los usuarios.
- Consulta de información: Endpoints para consultar información de usuarios y roles.
- Aplicación cliente: Interfaz desarrollada en una tecnología compatible para consumir los servicios REST.
- Base de datos: Almacenamiento de datos en SQL Server con conexión encriptada.
- Manejo de excepciones: Captura y gestión adecuada de errores.

## Tecnologías utilizadas:
- ASP.NET Core
- Swagger
- SQL Server
- JWT para seguridad

---

## Solución de la prueba


## Configuración del Proyecto

### Requisitos Previos
- Visual Studio 2022
- .NET Core SDK 6.0 o superior

### Clonar el Repositorio
```bash
git clone https://github.com/MrDavidAlv/Gesti-n-de-Usuarios-y-Roles---API-REST-.NETcore
cd empleadosFYMtech
```
Este repositorio contiene una API desarrollada con ASP.NET Core para gestionar empleados y datos paramétricos como países y ciudades.

### Estructura de Carpetas y Archivos
La estructura del proyecto está organizada de la siguiente manera:
```
📁 empleadosFYMtech
    |
    ├── 📁 Controllers
    │   ├── 📄 AuthController.cs
    │   ├── 📄 ParametersControllers.cs
    │   └── 📄 UsersController.cs
    │
    ├── 📁 DataBase
    │   └── 📄 ApplicationDbContext.cs
    │
    ├── 📁 DTOs
    │   ├──📁Request
    │   │   └── 📄 UserLoginRequestDto.cs
    │   ├──📁Response
    │   │   └── 📄 ParameterResponseDto.cs
    │   └── 📄 UserRegisterDto.cs
    │
    ├── 📁 Interfaces
    │   ├── 📁 Repository
    │   │   ├── 📄 ICiudadRepository.cs
    │   │   ├── 📄 IPaisRepository.cs
    │   │   ├── 📄 IParameterRepository.cs
    │   │   └── 📄 IUserRepository.cs
    |   └── 📁 Service  
    |       ├── 📄 IAuthService.cs
    |       ├── 📄 IParameterService.cs
    |       ├── 📄 IRoleService.cs
    |       └── 📄 IUserService.cs
    │
    ├── 📁 Middleware
    │   └── 📄 ExceptionMiddleware.cs
    │
    ├── 📁 Models
    │   ├── 📄 Parametricas.cs
    │   ├── 📄 Rol.cs
    │   └── 📄 User.cs
    │
    ├── 📁 Repositories
    │   ├── 📄 CiudadRepository.cs
    │   ├── 📄 PaisRepository.cs
    │   └── 📄 UserRepository.cs
    │
    ├── 📁 Services
    │   ├── 📄 AuthService.cs
    │   ├── 📄 ParameterService.cs
    │   ├── 📄 RoleService.cs
    │   └── 📄 UserService.cs
    |
    ├─ 📄 appsettings.json
    ├─ 📄 appsettings.Development.json
    ├─ 📄 launchSettings.json
    ├─ 📄 README.md
    ├─ 📄 empleadosFYMtech.csproj
    ├─ 📄 Program.cs
    └─ 📄 Startup.cs

```

1. Controllers

    Contiene los controladores de la aplicación, responsables de manejar las solicitudes HTTP y devolver respuestas al cliente.

    - `AuthController.cs`: Controlador para la autenticación de usuarios.
    - `ParametersControllers.cs`: Controlador para manejar solicitudes relacionadas con parámetros.
    - `UsersController.cs`: Controlador para manejar solicitudes relacionadas con usuarios.

2. DataBase

    Contiene la configuración de la base de datos y el contexto de la base de datos.

    - `ApplicationDbContext.cs`: Clase que representa el contexto de la base de datos y gestiona las entidades y la conexión a la base de datos.

3. DTOs

    Contiene los Data Transfer Objects, que son objetos utilizados para transferir datos entre distintas capas de la aplicación.

    - **Request**:
        - `UserLoginRequestDto.cs`: DTO para la solicitud de inicio de sesión de usuario.
    - **Response**:
        - `ParameterResponseDto.cs`: DTO para la respuesta de parámetros.
        - `UserRegisterDto.cs`: DTO para la solicitud de registro de usuario.

4. Interfaces

    Contiene las interfaces que definen los contratos para los servicios y repositorios.

    - **Repository**:
        - `ICiudadRepository.cs`
        - `IPaisRepository.cs`
        - `IParameterRepository.cs`
        - `IUserRepository.cs`

    - **Service**:
        - `IAuthService.cs`
        - `IParameterService.cs`
        - `IRoleService.cs`
        - `IUserService.cs`

5. Middleware

    Contiene el middleware personalizado de la aplicación.

    - `ExceptionMiddleware.cs`: Middleware para manejar excepciones de manera centralizada.

6. Models

    Contiene las clases que representan las entidades del dominio de la aplicación.

    - `Parametricas.cs`
    - `Rol.cs`
    - `User.cs`

7. Repositories

    Contiene las implementaciones de los repositorios que interactúan con la base de datos.

    - `CiudadRepository.cs`
    - `PaisRepository.cs`
    - `UserRepository.cs`

8. Services

    Contiene las implementaciones de los servicios que contienen la lógica de negocio de la aplicación.

    - `AuthService.cs`
    - `ParameterService.cs`
    - `RoleService.cs`
    - `UserService.cs`

9. Archivos de Configuración y Otros

Contienen archivos de configuración y otros archivos esenciales para la aplicación.

- `.gitignore`: Especifica los archivos y directorios que Git debe ignorar.
- `Adjuntos.sql`: Archivo SQL que probablemente contiene scripts relacionados con la base de datos.
- `appsettings.json`: Archivo de configuración que contiene opciones de configuración de la aplicación.
- `Program.cs`: Punto de entrada principal de la aplicación.
- `Startup.cs`: Configuración de servicios y el pipeline de la aplicación.
- `README.md`: Archivo de documentación que proporciona información sobre el proyecto.

Cada directorio y archivo tiene un propósito específico para mantener la aplicación organizada, modular y fácil de mantener.

### Configuración de la Base de Datos
- Replica la base de datos en SQL Server con [`este script`](/baseDeDatosSQLServer.sql).
- Actualiza la cadena de conexión en `appsettings.json` según tu configuración.

#### Tablas y Relaciones
 1. Tabla datosUsuario (usuario)

    - id (PK): Identificador único del usuario.
    - nombres: Nombres del usuario.
    - apellidos: Apellidos del usuario.
    - tipoDocumento: Tipo de documento del usuario.
    - documento: Número de documento del usuario.
    - fechaNacimiento: Fecha de nacimiento del usuario.
    - email: Correo electrónico del usuario.
    - password: Contraseña del usuario.
    - idCiudad (FK): Identificador de la ciudad del usuario.
    - idPais (FK): Identificador del país del usuario.
    - idRol (FK): Identificador del rol del usuario.

2. Tabla pais (par)

    - idPais (PK): Identificador único del país.
    - nombrePais: Nombre del país.
    - Tabla ciudad (par)

3. idCiudad (PK): Identificador único de la ciudad.

    - nombreCiudad: Nombre de la ciudad.
    - idPais (FK): Identificador del país al que pertenece la ciudad.
    
4. Tabla roles (par)

    - idRol (PK): Identificador único del rol.
    - nombreRol: Nombre del rol.

5. Relaciones

    - datosUsuario.idCiudad está relacionado con ciudad.idCiudad.
    - datosUsuario.idPais está relacionado con pais.idPais.
    - datosUsuario.idRol está relacionado con roles.idRol.
    - ciudad.idPais está relacionado con pais.idPais.

![Logo de empleadosFYMtech](/diagrama.PNG)

### Instalación de Dependencias

- Restaura las dependencias NuGet en Visual Studio o mediante el comando:
    ```bash
    dotnet restore
    ````

 ###  Ejecutar la Aplicación

- Desde Visual Studio:

    - Setea empleadosFYMtech como el proyecto de inicio.
    - Presiona F5 para compilar y ejecutar la aplicación.

- Desde la línea de comandos
    ```bash
    dotnet run --project empleadosFYMtech
    ```

</br></br>

## Uso del API
Acceder a Swagger
Una vez que la aplicación esté en ejecución, puedes acceder a Swagger para explorar y probar los endpoints del API. Visita https://localhost:44380/swagger en tu navegador web.


![Logo de empleadosFYMtech](/servicios.PNG)

### Endpoints Disponibles
- GET /api/users: Obtener todos los usuarios.
- GET /api/users/{id}: Obtener un usuario por ID.
- POST /api/users/register: Registrar un nuevo usuario.
- POST /api/users/login: Iniciar sesión y obtener token JWT.

### Autenticación JWT
- Usa el endpoint /api/users/login para obtener un token JWT.
- Incluye el token en el encabezado Authorization para acceder a endpoints protegidos.

### Parametricas
- GET /api/parametric/pais: Obtener todos los pais.
- GET /api/parametric/ciudades: Obtener todos las ciudades.
- GET /api/parametric/ciudades/{id}: Obtener las ciudades por idPais.

---

## Contribución
Si quieres contribuir a este proyecto, por favor sigue estos pasos:

- Crea un fork del repositorio.
- Crea una nueva rama (git checkout -b feature/nueva-funcionalidad).
- Haz tus cambios y realiza commit (git commit -am 'Agrega nueva funcionalidad').
- Haz push a la rama (git push origin feature/nueva-funcionalidad).
- Crea un pull request en GitHub.
- Problemas y Soporte
- Para cualquier problema o duda, por favor abre un issue en el repositorio.
