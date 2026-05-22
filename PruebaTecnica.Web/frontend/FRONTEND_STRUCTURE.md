# Estructura del frontend

Carpeta: `PruebaTecnica.Web/frontend`

- `package.json` - dependencias y scripts (`dev`, `build`, `preview`).
- `vite.config.ts` - configuración de Vite (proxy para `/api` en desarrollo).
- `tsconfig.json` - configuraciones TypeScript.
- `index.html` - punto de entrada HTML.
- `src/` - código fuente
  - `main.tsx` - arranque de React; importa `bootstrap` y `styles.css`.
  - `App.tsx` - componente raíz; maneja estado de autenticación y layout principal.
  - `styles.css` - ajustes visuales menores además del CSS de Bootstrap.
  - `types.ts` - definiciones TypeScript (Employee, DTOs).
  - `services/`
    - `api.ts` - instancia axios con `baseURL` configurable mediante `VITE_API_URL` y manejo automático del token JWT.
    - `employeeService.ts` - funciones CRUD para `/Employee`.
    - `authService.ts` - `login` y `register` para `/Auth`.
  - `components/`
    - `Login.tsx` - formulario de autenticación.
    - `EmployeeList.tsx` - listado de empleados, botones para crear/editar/eliminar.
    - `EmployeeForm.tsx` - formulario modal para crear/editar empleados.

### Cómo configurar la URL de la API

- En desarrollo se recomienda usar el proxy de Vite (`/api`) definido en `vite.config.ts`.
- Para apuntar directamente al backend configure `VITE_API_URL`. Ejemplos en el `README.md`.

### Notas de despliegue

- Para producción, establezca `VITE_API_URL` al endpoint público de su API y ejecute `npm run build`.
- Asegúrese de que el backend soporte CORS cuando el frontend y backend estén en dominios distintos.
