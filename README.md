# Prueba Técnica Controles Empresariales

## Endpoints
### Auth
- Register - POST
	- /api/Auth/register - Registrar un nuevo usuario
	- Requiere Body en formato JSON
- Login - POST
	- /api/Auth/login - Inicio de Sesion de un usuario
	- Requiere Body en formato JSON

### Employee
- Get All Employees - Get
	- /api/Employee - Retorna una lista de todos los empleados.
	- Requiere Autenticación como Bearer Token
- Get Employee By Id - Get
	- /api/Employee/{Id} - Retorna los detalles de un empleado específico por ID.
	- Requiere el Id del empleado a buscar en el URL del endpoint
	- Requiere Autenticación como Bearer Token
- Create Employee - Post
	- /api/Employee - Agrega un nuevo empleado
	- Requiere Body en formato JSON
	- Requiere Autenticación como Bearer Token
- Update Employee
	- /api/Employee/{Id} - Actualiza un empleado existente
	- Requiere el Id del empleado a buscar en el URL del endpoint
	- Requiere Body en formato JSON
	- Requiere Autenticación como Bearer Token
- Delete Employee
	- /api/Employee/{Id} - Elimina un empleado
	- Requiere el Id del empleado a buscar en el URL del endpoint
	- Requiere Autenticación como Bearer Token

## Arquitectura y Patrones de Diseño
### Arquitectura
La API se diseñó siguiendo una arquitectura en capas basada en Clean para separar las responsabilidades.

### Patrones de Diseño
- Repository Pattern: Se implementó el patrón de repositorio para abstraer la lógica de acceso a datos y facilitar el mantenimiento y las pruebas.
- Dependency Injection: Se implementa el patrón Dependency Injection para lograr bajo acoplamiento entre componentes y facilitar la mantenibilidad del sistema.

## Autenticación
La autenticación valida la identidad del usuario mediante JWT. Cuando el usuario inicia sesión, la API genera un token firmado digitalmente que contiene claims como username y rol. Este token es enviado en cada solicitud usando el header Authorization.

## Autorización
La autorización controla qué recursos puede acceder el usuario según su rol. En esta API se implementó autorización basada en roles usando el atributo [Authorize(Roles = "...")].
 - Admin puede acceder a todos los endpoints.
 - User solo puede consultar información de todos los empleados.

## Implementación de Middleware en ASP.NET Core
En este proyecto se muestra cómo implementar un Middleware personalizado en ASP.NET Core para interceptar y modificar las solicitudes HTTP antes de que lleguen a los controladores. 
Este Middleware se encarga de mostrar la petición HTTP en consola aúnque tiene la capacidad de detener el flujo o seguir con el proceso en caso de ser necesario; la información que encontraremos sera la entrante, el metodo que se uso, la ruta y la hora de ejecución.