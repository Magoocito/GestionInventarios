# Template de Arquitectura Limpia en .NET Core: Fundamentos y Ventajas

<div align="center">
  <img src="01. Presentacion/InventarioMVC/wwwroot/Images/Picture1.png" alt="Arquitectura Limpia Diagrama" width="600" />
</div>

Este template representa un ejemplar de cómo implementar una arquitectura limpia en aplicaciones desarrolladas en .NET Core. Su principal propósito radica en proporcionar una base sólida para la comprensión y aplicación de una arquitectura limpia en proyectos .NET Core.

## Descripción del Proyecto

Este proyecto es un sistema CRUD para la gestión de movimientos de inventario, desarrollado siguiendo los principios de arquitectura limpia en .NET 8. Incluye funcionalidades para crear, consultar, actualizar y eliminar movimientos, utilizando patrones como CQRS, inyección de dependencias y separación de capas (Presentación, Aplicación, Dominio e Infraestructura). El objetivo es ofrecer una base robusta y escalable para aplicaciones empresariales, facilitando el mantenimiento y la evolución del software. Eventualmente se puede implementar pruebas en el folder de Test y los filtros de búsqueda un componente mas como Filtros de búsqueda en la vista de Inventario.

## 🏗️ Arquitectura del Proyecto

### Estructura de Capas

```
📁 GestionInventarios/
├── 📄 GestionInventarios.sln
├── 📁 00. Tests/
│   └── 🧪 Pruebas unitarias e integración
├── 📁 01. Presentacion/
│   └── 🌐 GestionInventarios.Web (MVC/API)
├── 📁 02. Aplicacion/
│   ├── 🔧 GestionInventarios.Aplicacion (Use Cases, CQRS)
│   └── 🏛️ GestionInventarios.Dominio (Entities, Business Logic)
└── 📁 03. Infraestructura/
    └── 🗄️ GestionInventarios.Infraestructura (Data Access, External Services)
```

### Principios de Arquitectura Limpia Implementados

- **🎯 Separación de Responsabilidades**: Cada capa tiene una responsabilidad específica
- **🔄 Inversión de Dependencias**: Las capas internas no dependen de las externas
- **🧩 Inyección de Dependencias**: Configuración centralizada de servicios
- **📋 CQRS Pattern**: Separación entre comandos y consultas
- **🏢 Domain-Driven Design**: Enfoque en la lógica de negocio

## 🚀 Características Principales

- ✅ **CRUD Completo** para gestión de inventarios
- ✅ **Arquitectura Limpia** con separación clara de capas
- ✅ **Patrones CQRS** para operaciones de lectura/escritura
- ✅ **Inyección de Dependencias** nativa de .NET
- ✅ **Entity Framework Core** para acceso a datos
- ✅ **Validaciones** robustas en capa de aplicación
- ✅ **Logging** integrado
- ✅ **Configuración** flexible por ambiente

## 🛠️ Tecnologías Utilizadas

- **Framework**: .NET 8
- **ORM**: Entity Framework Core
- **Base de Datos**: SQL Server / SQLite
- **Patrones**: CQRS, Repository, Unit of Work
- **Frontend**: ASP.NET Core MVC
- **Testing**: xUnit, Moq (próximamente)

## 📦 Instalación y Configuración

### Prerrequisitos
- .NET 8 SDK
- Visual Studio 2022 o VS Code
- SQL Server (opcional: SQLite para desarrollo)

### Pasos de Instalación

1. **Clonar el repositorio**
   ```bash
   git clone [url-del-repositorio]
   cd GestionInventarios
   ```

2. **Restaurar paquetes NuGet**
   ```bash
   dotnet restore
   ```

3. **Configurar cadena de conexión**
   ```json
   // En appsettings.json
   {
     "ConnectionStrings": {
       "DefaultConnection": "tu-cadena-de-conexion"
     }
   }
   ```

4. **Aplicar migraciones**
   ```bash
   dotnet ef database update
   ```

5. **Ejecutar la aplicación**
   ```bash
   dotnet run --project "01. Presentacion/GestionInventarios.Web"
   ```

## 📊 Funcionalidades

### Gestión de Inventarios
- 📝 Crear nuevos movimientos de inventario
- 👀 Consultar movimientos existentes
- ✏️ Actualizar información de movimientos
- 🗑️ Eliminar movimientos
- 🔍 Filtros de búsqueda avanzada (próximamente)

## 🧪 Testing (En Desarrollo)

El proyecto incluirá:
- **Pruebas Unitarias**: Validación de lógica de negocio
- **Pruebas de Integración**: Verificación de flujos completos
- **Pruebas de API**: Validación de endpoints

## 🤝 Contribución

1. Fork del proyecto
2. Crear una rama feature (`git checkout -b feature/nueva-funcionalidad`)
3. Commit de cambios (`git commit -m 'Agregar nueva funcionalidad'`)
4. Push a la rama (`git push origin feature/nueva-funcionalidad`)
5. Crear Pull Request

## 📄 Licencia

Este proyecto está bajo la Licencia MIT. Ver el archivo `LICENSE` para más detalles.

## 📞 Contacto

Para preguntas o sugerencias sobre este template de arquitectura limpia, no dudes en contactar.

---

> **Nota**: Este proyecto sirve como base educativa y de referencia para implementar arquitectura limpia en .NET Core. Puede ser adaptado y extendido según las necesidades específicas de cada proyecto.
