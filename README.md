# Gestión de Estudiantes, Cursos y Profesores

## Descripción
Esta aplicación .NET implementa un CRUD (Crear, Leer, Actualizar, Eliminar) para gestionar estudiantes, cursos y profesores. Permite registrar, actualizar y eliminar información, asegurando un manejo eficiente de los datos académicos.

## Tecnologías Utilizadas
- **.NET Core / .NET 6+**
- **Entity Framework Core** para la gestión de bases de datos
- **SQL Server** como base de datos
- **ASP.NET Core Web API** para la exposición de servicios
- **Swagger** para la documentación de la API
- **Frontend opcional**: Angular en https://github.com/neydarisJaylinne/StudentsFrontEnd
## Características
- Gestión de Estudiantes: alta, baja, modificación y consulta
- Gestión de Cursos: creación, asignación y actualización de cursos
- Gestión de Profesores: asignación de cursos y actualización de datos
- Integración con Swagger para pruebas de API

## Instalación y Configuración
### Prerrequisitos
- [.NET SDK](https://dotnet.microsoft.com/download)
- [SQL Server](https://www.microsoft.com/es-es/sql-server)
- [Visual Studio Code / Visual Studio](https://visualstudio.microsoft.com/)

### Pasos de Instalación
1. Clonar el repositorio:
   ```sh
   git clone https://github.com/neydarisJaylinne/StudentsBackEnd.git
   cd <nombre_del_directorio_del_proyecto>
   ```
2. Restaurar paquetes NuGet:
   ```sh
   dotnet restore
   ```
3. Configurar la base de datos en `appsettings.json`:
   ```json
   "ConnectionStrings": {
     "DefaultConnection": "Server=TU_SERVIDOR;Database=TU_BD;User Id=TU_USUARIO;Password=TU_CONTRASEÑA;"
   }
   ```
4. Aplicar migraciones de Entity Framework:
   ```sh
   dotnet ef database update
   ```
5. Ejecutar la aplicación:
   ```sh
   dotnet run
   ```
6. Acceder a la API en `http://localhost:5000/swagger`

## Uso de la API
### Endpoints principales
- **Estudiantes**
  - `GET /api/Student` → Listar estudiantes
  - `POST /api/Student` → Crear estudiante
  - `PUT /api/Student/{id}` → Actualizar estudiante
  - `DELETE /api/Student/{id}` → Eliminar estudiante

- **Cursos**
  - `GET /api/Grade` → Listar cursos
  - `GET: api/Grade/{id}` -> Traer curso por ID
  - `POST /api/Grade` → Crear curso
  - `PUT /api/Grade/{id}` → Actualizar curso
  - `DELETE /api/Grade/{id}` → Eliminar curso

- **Profesores**
  - `GET /api/Teacher` → Listar profesores
  - `GET /api/Teacher/{id}`-> Listar profesor por id
  - `POST /api/Teacher` → Crear profesor
  - `PUT /api/Teacher/{id}` → Actualizar profesor
  - `DELETE /api/Teacher/{id}` → Eliminar profesor

## Contribución
1. Haz un **fork** del repositorio.
2. Crea una **rama** con tu nueva característica (`git checkout -b feature-nueva`).
3. **Confirma** tus cambios (`git commit -m 'Agrega nueva funcionalidad'`).
4. **Envía** los cambios (`git push origin feature-nueva`).
5. Abre un **Pull Request**.

