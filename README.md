# perla-metro-api-main
## Proyecto que es está basado en una arquitectura monolítico modular a través del Software As Service (SOA).
## Para levantar el proyecto se deben seguir lo siguientes pasos:

## Requisitos previos:
- .NET 9.0.304
- Visual Studio Code 1.95.3 o superior
- Base de datos Neo4j

## Instalación
1.- Primero debemos abrir la consola de comandos apretando las siguientes teclas y escribir 'cmd':

- "Windows + R" y escribimos 'cmd'

2.- Ahora debemos crear una carpeta en donde guardar el proyecto, esta carpeta puede estar donde desee el usuario:
```bash
mkdir [NombreDeCarpeta]
```
3.- Accedemoss a la carpeta.
```bash
cd NombreDeCarpeta
```
4.- Se debe clonar el repositorio en el lugar deseado por el usuario con el siguiente comando:
```bash
git clone https://github.com/AlbertoLyons/perla-metro-api-main.git
```
5.- Accedemos a la carpeta creada por el repositorio:
```bash
cd perla-metro-api-main
```
6.- Ahora debemos restaurar las dependencias del proyecto con el siguiente comando:
```bash
dotnet restore
```
7.- Con las dependencias restauradas, abrimos el editor:
```bash
code .
```
8.- Establecer las credenciales del archivo .env
```bash
notepad .env
```
9.- Finalmente ya en el editor ejecutamos el siguiente comando para ejecutar el proyecto:
```bash
dotnet run
```

## Estructura del repositorio
- Funciona con una API main que se conecta con los módulos API correspondientes
- Se ofrece un .env de con datos de ejemplo
- Se utiliza el Framework .NET de C#
- Utiliza endpoints para realizar el CRUD de los módulos
- Se utiliza la ruta "http://localhost:5000" para realizar las peticiones HTTP

## Módulo routes-service
El módulo de rutas está definido en el siguiente link:
```bash
https://perla-metro-route-service.onrender.com
```
Se debe especificar la x-api-key como header para poder realizar las peticiones HTTP. Si se quiere realizar las consultas desde la API MAIN se necesita usar la siguiente ruta como base:
```bash
https://perla-metro-api-main.onrender.com/route-service/route
```
Las consultas disponibles en el módulo son las siguientes (Se adjunta una colección de postman en el repositorio para un mayor entendimiento.):
[Colección de postman del módulo routes](route-service.postman_collection.json)
### Crear ruta (Metodo POST)
```bash
https://perla-metro-route-service.onrender.com/api/route
```
Este metodo permite crear una nueva ruta dando los siguientes parametros en el body:
- OriginStation: Estación de origen. Debe de ser un string.
- DestinationStation: Estación de origen. Debe de ser un string.
- DepartureTime: Hora de despacho. Debe de ser en formato TimeSpan (Ejemplo 12:00:00, donde cumple la regla de HH:MM:SS).
- ArrivalTime: Hora de llegada. Debe de ser en formato TimeSpan de igual manera.
- InterludeTimes: Lista de tiempos de paradas intermedias, cada hora debe de ser incluido en el formato TimeSpan.
- IsActive: Verifica si la ruta está activa. Debe ser un valor booleano true o false.

Esta ruta no está protegida por autenticación según el enunciado. El equivalente a realizar esta consulta pero en la API MAIN sería utilizando la siguiente ruta:
```bash
https://perla-metro-api-main.onrender.com/route-service/route
```
### Obtener rutas (Metodo GET)
```bash
https://perla-metro-route-service.onrender.com/api/route
```
Este metodo permite obtener todas las rutas existentes, estén desactivadas o no.

Esta ruta está protegida por autenticación, en la que solo el administrador puede acceder. El equivalente a realizar esta consulta pero en la API MAIN sería utilizando la siguiente ruta:
```bash
https://perla-metro-api-main.onrender.com/route-service/route
```
### Obtener ruta por id (Metodo GET)
```bash
https://perla-metro-route-service.onrender.com/api/route/{id}
```
Este metodo permite obtener una ruta dada su id como parametro. Si la ruta está desactivada, no se podrá mostrar información sobre esta, arrojando un estado 404.

Esta ruta no está protegida por autenticación según el enunciado. El equivalente a realizar esta consulta pero en la API MAIN sería utilizando la siguiente ruta:
```bash
https://perla-metro-api-main.onrender.com/route-service/route/{id}
```
### Actualizar ruta (Metodo PUT)
```bash
https://perla-metro-route-service.onrender.com/api/route/{id}
```
Este metodo permite editar una ruta dando como párametro en la ruta su id. Los párametros que deben de ir en el body son los siguientes:
- OriginStation: Estación de origen. Debe de ser un string.
- DestinationStation: Estación de origen. Debe de ser un string.
- DepartureTime: Hora de despacho. Debe de ser en formato TimeSpan (Ejemplo 12:00:00, donde cumple la regla de HH:MM:SS).
- ArrivalTime: Hora de llegada. Debe de ser en formato TimeSpan de igual manera.
- InterludeTimes: Lista de tiempos de paradas intermedias, cada hora debe de ser incluido en el formato TimeSpan.

Esta ruta no está protegida por autenticación según el enunciado. El equivalente a realizar esta consulta pero en la API MAIN sería utilizando la siguiente ruta:
```bash
https://perla-metro-api-main.onrender.com/route-service/route/{id}
```
### Eliminar ruta (Metodo DELETE)
```bash
https://perla-metro-route-service.onrender.com/api/route/{id}
```
Este metodo permite la elminiación de una ruta mediante el uso de soft delete. Se debe de dar la id de la ruta como párametro en la ruta

Esta ruta está protegida por autenticación, en la que solo el administrador puede acceder. El equivalente a realizar esta consulta pero en la API MAIN sería utilizando la siguiente ruta:
```bash
https://perla-metro-api-main.onrender.com/route-service/route
```
## Módulo stations-service

El módulo de estaciones está desplegado en el siguiente endpoint:

```bash
https://perla-metro-stations-service-api.onrender.com
```

Para realizar consultas desde la API MAIN, se debe usar la siguiente ruta base según el nivel de acceso requerido:

## Rutas de acceso

### Rutas Públicas (Sin autenticación)

```bash
https://perla-metro-api-main.onrender.com/station-service/public/stations
```

### Rutas Protegidas (Solo Administradores)

```bash
https://perla-metro-api-main.onrender.com/station-service/stations
```

Se debe especificar la x-api-key como header para poder realizar las peticiones HTTP.

## Consultas POSTMAN

Las consultas disponibles en el módulo son las siguientes (Se adjunta una colección de postman en el repositorio para un mayor entendimiento.):
[Colección de postman del módulo stations](Station-service.postman_collection.json)

## Endpoints disponibles

### 1.- Obtener todas las estaciones (Método GET)

### Ruta desde API MAIN:

```bash
https://perla-metro-api-main.onrender.com/station-service/stations
```

### Ruta directa:

```bash
https://perla-metro-stations-service-api.onrender.com/api/Stations
```

Esta ruta está protegida por autenticación JWT. Solo usuarios con el rol de Administrador
pueden acceder.


### 2.- Crear nueva estación (Método POST)

### Ruta desde API MAIN:

```bash
https://perla-metro-api-main.onrender.com/station-service/public/stations
```

### Ruta directa:

```bash
https://perla-metro-stations-service-api.onrender.com/api/Stations
```
Esta ruta no está protegida por autenticación.

### Parámetros en el body:

- name: Nombre de la estación.
- location: Ubicación de la estación
- type: Tipo de estación. Debe ser un entero (1=Origen, 2=Destino, 3=Intermedia)

### Ejemplo de body:

```json
{
  "name": "CEDUC",
  "location": "Ramón Freire 01416, Antofagasta",
  "type": 2
}
```

### Obtener estación por ID (Método GET)

### Ruta desde API MAIN:

```bash
https://perla-metro-api-main.onrender.com/station-service/public/stations/{id}
```

### Ruta directa:

```bash
https://perla-metro-stations-service-api.onrender.com/api/Stations/{id}
```
Esta ruta no está protegida por autenticación.

### Parámetros de ruta:

- id: ID numérico de la estación (entero positivo)

### Actualizar estación (Método PUT)

### Ruta desde API MAIN:

```bash
https://perla-metro-api-main.onrender.com/station-service/public/stations/{id}
```

### Ruta directa:

```bash
https://perla-metro-stations-service-api.onrender.com/api/Stations/{id}
```
Esta ruta no está protegida por autenticación.

### Parámetros de ruta:

- id: ID numérico de la estación a actualizar (entero positivo)

### Parámetros en el body:

- name: Nuevo nombre de la estación.
- location: Nueva ubicación de la estación
- type: Tipo de estación. Debe ser un entero (1=Origen, 2=Destino, 3=Intermedia)
- isActive: Estado de la estación (true/false)

### Ejemplo de body:

```json
{
  "name": "Casino Enjoy",
  "location": "Av. Angamos 01455, Antofagasta",
  "type": 1,
  "isActive": true
}
```

### Eliminar estación (Método DELETE)

### Ruta desde API MAIN:

```bash
https://perla-metro-api-main.onrender.com/station-service/public/stations/{id}
```

### Ruta directa:

```bash
https://perla-metro-stations-service-api.onrender.com/api/Stations/{id}
```
Esta ruta no está protegida por autenticación.

### Parámetros de ruta:

- id: ID numérico de la estación a eliminar (entero positivo)

La estación se marca como inactiva pero no se elimina físicamete de la base de datos para mantener trazabilidad.

## Consideraciones importantes

1. Soft Delete: Las estaciones eliminadas se marcan como inactivas, no se borran.
2. El tipo solo puede ser un valor entero con valores: (1=Origen, 2=Destino, 3=Intermedia)


## Módulo user-service

El módulo de usuarios está desplegado en el siguiente endpoint:

```bash
https://perla-metro-users-service-k4mp.onrender.com
```

Para realizar consultas desde la API MAIN, se debe usar la siguiente ruta base según el nivel de acceso requerido:

## Rutas de acceso

### Rutas Protegidas (Solo Administradores)

```bash
https://perla-metro-api-main.onrender.com/user-service/UserManagement
```

Se debe especificar la x-api-key como header para poder realizar las peticiones HTTP.

## Consultas POSTMAN

Las consultas disponibles en el módulo son las siguientes (Se adjunta una colección de postman en el repositorio para un mayor entendimiento.):
[Colección de postman del módulo users](User.postman_collection.json)

## Endpoints disponibles

### 1.- Iniciar Sesion (Método POST)

### Ruta desde API MAIN:

```bash
https://perla-metro-api-main.onrender.com/user-service/Auth/login
```

### Ruta directa:

```bash
https://perla-metro-users-service-k4mp.onrender.com/api/Auth/login
```
Esta ruta no está protegida por autenticación.

### 2.- Registrarse (Método POST)

### Ruta desde API MAIN:

```bash
https://perla-metro-api-main.onrender.com/user-service/Register/register
```

### Ruta directa:

```bash
https://perla-metro-users-service-k4mp.onrender.com/api/Register/register
```
Esta ruta no está protegida por autenticación.

### Parámetros en el body:

- name: Nombre de la persona.
- lastname: Apellido de la persona
- email: Correo de la persona
- password: Contraseña de la persona

### Ejemplo de body:

```json
{
  "firstName": "Pedro",
  "lastName": "Arauco",
  "email": "pedro@perlametro.cl",
  "password": "Pedro01$"
}
```

### Editar Perfil (Método PUT)

### Ruta desde API MAIN:

```bash
https://perla-metro-api-main.onrender.com/user-service/Edit/update-profile
```

### Ruta directa:

```bash
https://perla-metro-users-service-k4mp.onrender.com/api/Edit/update-profile
```
Esta ruta está protegida por autenticación JWT. Solo usuarios con el rol de Administrador y Usuario
pueden acceder.

### Parámetros de ruta:

- name: Nombre de la persona.
- lastname: Apellido de la persona
- email: Correo de la persona

### Cambiar Contraseña (Método PUT)

### Ruta desde API MAIN:

```bash
https://perla-metro-api-main.onrender.com/user-service/Edit/change-password
```

### Ruta directa:

```bash
https://perla-metro-users-service-k4mp.onrender.com/api/Edit/change-password
```
Esta ruta está protegida por autenticación JWT. Solo usuarios con el rol de Administrador y Usuario
pueden acceder.

### Parámetros en el body:

- currentPassword: Contraseña actual
- newPassword: Contraseña nueva


### Obtener a todos los usuarios (Método GET)

### Ruta desde API MAIN:

```bash
https://perla-metro-api-main.onrender.com/user-service/UserManagement/users
```

### Ruta directa:

```bash
https://perla-metro-users-service-k4mp.onrender.com/api/UserManagement/users
```
Esta ruta está protegida por autenticación JWT. Solo usuarios con el rol de Administrador
pueden acceder.

### Obtener usuario por ID (Método GET)

### Ruta desde API MAIN:

```bash
https://perla-metro-api-main.onrender.com/user-service/UserManagement/user/{id}
```

### Ruta directa:

```bash
https://perla-metro-users-service-k4mp.onrender.com/api/UserManagement/user/{id}
```
Esta ruta está protegida por autenticación JWT. Solo usuarios con el rol de Administrador
pueden acceder.

### Parámetros de ruta:

- id: ID UUID v4

### Eliminar Usuario (Método DELETE)

### Ruta desde API MAIN:

```bash
https://perla-metro-api-main.onrender.com/user-service/UserManagement/user/{id}
```

### Ruta directa:

```bash
https://perla-metro-users-service-k4mp.onrender.com/api/UserManagement/user/{id}
```
Esta ruta está protegida por autenticación JWT. Solo usuarios con el rol de Administrador
pueden acceder.

### Parámetros de ruta:

- id: ID UUID v4

El usuario se marca como inactivo pero no se elimina físicamete de la base de datos para mantener trazabilidad.


## Consideraciones importantes

1. Soft Delete: Los usuarios eliminados se marcan como inactivos, no se borran.
   
