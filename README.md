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