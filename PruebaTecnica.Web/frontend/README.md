# Prueba Técnica - Frontend


Frontend en React + TypeScript para consumir la API existente.

Requisitos:
- Node.js 16+

Instalación y ejecución (desarrollo):

```bash
cd PruebaTecnica.Web/frontend
npm install
npm run dev
```

Build de producción:

```bash
npm run build
npm run preview
```

URL de la API configurable
- Desarrollo por defecto usa el proxy de Vite y `baseURL` relativo `/api`.
- Para apuntar al backend directamente (o en producción), configura la variable de entorno `VITE_API_URL`. Ejemplo:

```bash
# Windows (PowerShell)
$env:VITE_API_URL = 'https://localhost:7037'; npm run dev
```

Notas importantes:
- Token JWT se guarda en `localStorage` con la llave `token`.
- Servicios HTTP están en `src/services` (`api.ts`, `employeeService.ts`, `authService.ts`).
- En desarrollo se usa el proxy en `vite.config.ts` que redirige `/api` a `https://localhost:7037` y evita problemas CORS/SSL.

Estructura básica del frontend: ver `FRONTEND_STRUCTURE.md`.
