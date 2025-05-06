# 🦖 DinoBank API

DinoBank es una API sencilla desarrollada con C# y .NET 8 como ejercicio de práctica para aprender los conceptos básicos del desarrollo de APIs REST. La API permite realizar 
operaciones CRUD sobre un modelo de usuarios, y persiste los datos en un archivo JSON en lugar de usar una base de datos.

## 📁 **Estructura del Proyecto**
La solución está dividida en varios proyectos para mantener una arquitectura organizada:
- `DinoBank.Domain`: Contiene el modelo de dominio, como `UserEntity`, que representa a un usuario (Id, UserName, Password, Type).
- `DinoBank.Persistence`: 
  - Carpeta `Database`: Contiene la interfaz `IDatabaseService` que define las operaciones CRUD y su implementación `DatabaseService`.
  - Carpeta `Files`: Contiene el archivo JSON donde se almacena la información de los usuarios.
- `DinoBank.API`: Contiene el controlador que expone los endpoints para gestionar los usuarios.

## 🧪 **Características**
- API RESTful con operaciones:
  - `GET /users` – Listar todos los usuarios
  - `GET /users/{id}` – Obtener un usuario por ID
  - `POST /users` – Crear un nuevo usuario
  - `PUT /users/{id}` – Actualizar un usuario
  - `DELETE /users/{id}` – Eliminar un usuario
- Persistencia local usando un archivo JSON
- Separación en capas: dominio, persistencia y presentación (API)

## ⚙️ **Tecnologías Usadas**
- .NET 8
- C#
- ASP.NET Core
- JSON para almacenamiento local
- Visual Studio 2022

## ▶️ **Cómo ejecutar el proyecto**

1. Clona el repositorio:
   [https://github.com/AndresDurango1/DinoBankAPI.git](https://github.com/AndresDurango1/DinoBankAPI.git)
2. Abre la solución DinoBank.sln en Visual Studio.

3. .Ejecuta el proyecto de la API (por ejemplo, DinoBank.API) como proyecto de inicio.

4. Accede a los endpoints usando herramientas como Postman.
