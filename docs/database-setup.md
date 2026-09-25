# PostgreSQL database-first

## DDL y base PostgreSQL

La base activa se llama `firmeza` (no `firmeza_db`) y está en `localhost:5432`. `database/schema.sql` define manualmente productos, categorías, clientes, ventas, detalles y las tablas de ASP.NET Identity, con PK, FK, `NOT NULL` e índices. El script se ejecutó en `firmeza` con `psql`; como esas tablas e índices ya existían, `IF NOT EXISTS` los conservó sin alterar datos. En una base vacía, el mismo script los crea.

Para crear una base vacía con el mismo esquema, créala y ejecuta el script:

```bash
createdb -h localhost -U postgres firmeza
psql -h localhost -U postgres -d firmeza -v ON_ERROR_STOP=1 -f database/schema.sql
```

La base existente conserva el registro de una migración EF anterior (`20260917202711_InitialIdentityAndBusinessModel`); ejecutar ahora el DDL manual deja un script reproducible, aunque no cambia la procedencia histórica de esa instancia.

## Scaffolding ya generado

Las entidades y `ApplicationDbContext` fueron generados desde PostgreSQL con EF Core/Npgsql. El contexto está en `src/Firmeza.Infrastructure/Persistence` y las entidades en `src/Firmeza.Infrastructure/Persistence/Entities`.

El comando para volver a generarlos es:

```bash
dotnet ef dbcontext scaffold "Host=localhost;Database=firmeza;Username=postgres;Password=TU_CLAVE" Npgsql.EntityFrameworkCore.PostgreSQL --project src/Firmeza.Infrastructure --startup-project src/Firmeza.Presentation --output-dir Persistence/Entities --context-dir Persistence --context ApplicationDbContext --schema public --no-onconfiguring --force
```

`--no-onconfiguring` evita que la contraseña quede escrita en el contexto generado. Para ejecutar la API, configura `ConnectionStrings:DefaultConnection` mediante User Secrets o la variable `ConnectionStrings__DefaultConnection`; no hace falta modificar `.gitignore` ni guardar credenciales en el repositorio.

```bash
dotnet user-secrets init --project src/Firmeza.Presentation
dotnet user-secrets set "ConnectionStrings:DefaultConnection" "Host=localhost;Database=firmeza;Username=postgres;Password=TU_CLAVE" --project src/Firmeza.Presentation
```

## Mantenimiento

El DDL de PostgreSQL es la fuente física para el scaffolding. No apliques migraciones code-first nuevas sin acordar cómo se hará el baseline de la base existente.
