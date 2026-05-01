# Plan de Implementación - Sistema Multibarbero

## 📋 Resumen del Sistema

Sistema de gestión multibarbero con 5 roles: **Admin**, **Barbero**, **Barbería**, **Comercial** y **Cliente**. El sistema gestionará suscripciones, afiliaciones, reservas, estadísticas y notificaciones.

---

## 🎯 OBJETIVO 1: Modelado de Entidades del Dominio

### 1.1 Entidades Principales

#### 1.1.1 Entidades de Suscripción
- **PlanSuscripcion** (Base)
  - Id, Nombre, Descripción, Precio, DuracionDias, Tipo (Barbero/Barbería)
  - FechaCreacion, FechaActualizacion, Activo
  
- **CaracteristicaPlan**
  - Id, PlanSuscripcionId, Nombre, Descripcion
  
- **LimitesPlan**
  - Id, PlanSuscripcionId, MaxBarberosAfiliados, MaxReservasMensuales, MaxProductosVenta, PermiteEstadisticas, PermiteReservas, PermiteProductos

#### 1.1.2 Entidades de Usuario Extendidas
- **PerfilBarbero** (Extiende o se relaciona con Usuario)
  - Id, UsuarioId, Biografia, ExperienciaAnios, Especialidades (JSON)
  - FotoPerfilUrl, CalificacionPromedio, TotalServicios, TotalClientes
  - PlanSuscripcionId, FechaInicioPlan, FechaVencimientoPlan
  - EstadoSolicitudCambioPlan (Pendiente/Aprobado/Rechazado)
  - NuevoPlanSolicitadoId
  
- **PerfilBarberia** (Extiende o se relaciona con Usuario)
  - Id, UsuarioId, NombreComercial, Direccion, Telefono, Coordenadas (Lat/Lng)
  - HorarioApertura, HorarioCierre, DiasLaborables (JSON)
  - FotoPortadaUrl, CalificacionPromedio, CapacidadMaxima
  - PlanSuscripcionId, FechaInicioPlan, FechaVencimientoPlan
  - EstadoSolicitudCambioPlan (Pendiente/Aprobado/Rechazado/NuevoRegistro)
  - NuevoPlanSolicitadoId
  - MaxBarberosPermitidos
  
- **PerfilCliente** (Extiende o se relaciona con Usuario)
  - Id, UsuarioId, FechaNacimiento, Genero
  - HistorialReservasCount, CalificacionPromedioDada

#### 1.1.3 Entidades de Servicios y Productos
- **Servicio**
  - Id, ProveedorId (Guid - puede ser Barbero o Barbería), TipoProveedor (Enum)
  - Nombre, Descripcion, DuracionMinutos, Precio, Activo
  - CategoriaId
  
- **CategoriaServicio**
  - Id, Nombre, Descripcion, IconoUrl
  
- **Producto**
  - Id, BarberoId, Nombre, Descripcion, Precio, Stock, ImagenUrl
  - CategoriaId, Activo, FechaCreacion
  
- **CategoriaProducto**
  - Id, Nombre, Descripcion

#### 1.1.4 Entidades de Reservas
- **Reserva**
  - Id, ClienteId, ProveedorId (Barbero/Barbería), TipoProveedor (Enum)
  - ServicioId, FechaHoraInicio, FechaHoraFin, Estado (Pendiente/Confirmada/Cancelada/Completada/Rechazada)
  - NotasCliente, NotasProveedor, MotivoRechazo
  - FechaSolicitud, FechaConfirmacion, FechaCancelacion
  - CalificacionCliente, ComentarioCliente
  - PrecioTotal, MetodoPago, EstadoPago
  
- **EstadoReserva** (Enum)
  - Pendiente, Confirmada, EnProceso, Completada, CanceladaCliente, CanceladaProveedor, Rechazada

#### 1.1.5 Entidades de Afiliación
- **SolicitudAfiliacion**
  - Id, BarberoId, BarberiaId, Estado (Pendiente/Aprobada/Rechazada/Retirada)
  - FechaSolicitud, FechaRespuesta, MotivoRechazo, Notas
  - RespondidoPor (UsuarioId)
  
- **AfiliacionBarbero**
  - Id, BarberoId, BarberiaId, FechaAfiliacion, Activo
  - EsPrincipal (bool - indica si las reservas van a la barbería)
  - FechaFinAfiliacion (nullable)
  - MotivoFin (nullable)

#### 1.1.6 Entidades de Notificaciones
- **Notificacion**
  - Id, UsuarioDestinoId, Tipo (Enum), Titulo, Mensaje
  - Leida (bool), FechaLectura, FechaCreacion
  - EntidadRelacionadaId (nullable), TipoEntidad (nullable)
  - AccionRequerida (bool), UrlAccion (nullable)
  
- **TipoNotificacion** (Enum)
  - SolicitudAfiliacionNueva, SolicitudAfiliacionAprobada, SolicitudAfiliacionRechazada
  - CambioSuscripcionSolicitada, CambioSuscripcionAprobada, CambioSuscripcionRechazada
  - ReservaNueva, ReservaConfirmada, ReservaCancelada, ReservaRechazada
  - SuscripcionPorVencer, SuscripcionVencida
  - NuevoRegistroBarberia (para Admin/Comercial)

#### 1.1.7 Entidades de Estadísticas
- **EstadisticaBarbero**
  - Id, BarberoId, Periodo (Mes/Año), TotalReservas, TotalClientesUnicos
  - IngresosTotales, CalificacionPromedio, TasaCancelacion
  - ServiciosMasSolicitados (JSON)
  
- **EstadisticaBarberia**
  - Id, BarberiaId, Periodo (Mes/Año), TotalReservas, TotalClientesUnicos
  - IngresosTotales, CalificacionPromedio, TasaOcupacion
  - BarberosMasActivos (JSON), ServiciosMasSolicitados (JSON)
  
- **EstadisticaProducto**
  - Id, ProductoId, Periodo (Mes/Año), UnidadesVendidas, IngresosTotales
  - CalificacionPromedio

---

## 🎯 OBJETIVO 2: Configuración de Roles y Permisos

### 2.1 Roles del Sistema
Crear los siguientes roles en la tabla `Rol`:
1. **Admin** - Control total del sistema
2. **Barbero** - Prestador de servicios individual
3. **Barberia** - Establecimiento comercial
4. **Comercial** - Gestor de suscripciones y estadísticas
5. **Cliente** - Usuario final que realiza reservas

### 2.2 Permisos por Rol

#### Admin
- Gestionar todos los usuarios (CRUD completo)
- Crear/Editar/Eliminar planes de suscripción
- Aprobar/Rechazar cambios de suscripción (Barberos y Barberías)
- Aprobar/Rechazar nuevos registros de Barberías
- Ver todas las estadísticas del sistema
- Gestionar configuraciones globales
- Ver historial completo de transacciones

#### Barbero
- Editar perfil personal
- Gestionar servicios propios (CRUD)
- Ver reservas propias
- Confirmar/Rechazar reservas propias
- Gestionar productos (solo plan Premium)
- Ver estadísticas básicas (plan Popular) o completas (plan Premium)
- Solicitar cambio de plan
- Solicitar afiliación a barbería
- Ver notificaciones propias

#### Barbería
- Editar perfil de la barbería
- Gestionar servicios de la barbería (CRUD)
- Gestionar barberos afiliados (Ver lista, Aceptar/Rechazar solicitudes)
- Ver reservas de la barbería (propias y de barberos afiliados si aplica)
- Confirmar/Rechazar reservas
- Ver estadísticas según plan
- Solicitar cambio de plan
- Gestionar límite de barberos según plan

#### Comercial
- Ver estadísticas de barberos y barberías
- Aprobar/Rechazar cambios de suscripción
- Aprobar/Rechazar nuevos registros de barberías
- Ver reporte de suscripciones por vencer
- No puede modificar datos de usuarios directamente

#### Cliente
- Registrarse en el sistema
- Editar perfil personal
- Buscar barberos y barberías
- Realizar reservas
- Cancelar reservas propias
- Calificar servicios recibidos
- Ver historial de reservas
- Ver notificaciones propias

---

## 🎯 OBJETIVO 3: Implementación de Planes de Suscripción

### 3.1 Planes para Barberos

#### Plan Free (Gratuito - Default al registrarse)
- ✅ Modificar datos personales
- ✅ Mostrar servicios
- ✅ Aparecer en búsquedas
- ❌ NO puede recibir reservas
- ❌ NO tiene estadísticas
- ❌ NO puede vender productos
- ❌ NO puede afiliarse a barberías (o sí, pero sin recibir reservas)

#### Plan Popular (De pago)
- ✅ Todo lo del plan Free
- ✅ Recibir reservas
- ✅ Estadísticas básicas:
  - Total servicios realizados
  - Total clientes atendidos
  - Ingresos mensuales
  - Calificación promedio
- ❌ NO puede vender productos
- ❌ Estadísticas avanzadas no disponibles

#### Plan Premium (De pago - Máximo)
- ✅ Todo lo del plan Popular
- ✅ Postear productos en venta
- ✅ Estadísticas completas:
  - Todas las del plan Popular
  - Estadísticas de productos vendidos
  - Tendencias temporales
  - Comparativas periódicas
- ✅ Límite máximo de características

### 3.2 Planes para Barberías (Todos de pago, sin plan Free)

#### Plan Básico
- ✅ Límite de barberos afiliados: 3
- ✅ Gestión de reservas propias
- ✅ Estadísticas básicas
- ⏰ Duración: 30 días

#### Plan Estándar
- ✅ Límite de barberos afiliados: 10
- ✅ Gestión de reservas propias y de afiliados
- ✅ Estadísticas intermedias
- ⏰ Duración: 30 días

#### Plan Enterprise
- ✅ Límite de barberos afiliados: Ilimitado (o 50+)
- ✅ Todas las funcionalidades
- ✅ Estadísticas completas
- ⏰ Duración: 30 días

### 3.3 Flujo de Cambio de Suscripción

#### Para Barberos:
1. Barbero selecciona nuevo plan disponible
2. Sistema crea solicitud con estado "Pendiente"
3. Se envía notificación a Admin y Comercial
4. Admin o Comercial revisa y decide:
   - **Aceptar**: Se actualiza el plan inmediatamente, se registra fecha vencimiento
   - **Rechazar**: Se notifica al barbero con motivo
   - **Dejar en espera**: Permanece pendiente
5. Barbero recibe notificación de la decisión

#### Para Barberías:
**Registro inicial:**
1. Barbería se registra seleccionando plan
2. Completa requisitos (datos, documentación si aplica)
3. Se crea perfil con estado "Inactivo" hasta aprobación
4. Se envía notificación a Admin y Comercial
5. Admin o Comercial aprueba/rechaza
6. Si aprueba: perfil activado, puede afiliar barberos
7. Si rechaza: se notifica con motivo

**Cambio de plan posterior:**
1. Similar al flujo de barberos
2. Requiere aprobación de Admin/Comercial

---

## 🎯 OBJETIVO 4: Sistema de Afiliación Barbero-Barbería

### 4.1 Flujo de Solicitud de Afiliación

```
┌─────────────┐    Solicitud    ┌─────────────┐
│   BARBERO   │ ───────────────>│  BARBERÍA   │
│             │                 │             │
│             │ <───────────────│             │
│             │   Notificación  │             │
│             │   Decisión      │             │
└─────────────┘                 └─────────────┘
```

### 4.2 Estados de la Solicitud
1. **Pendiente**: Enviada, esperando respuesta
2. **Aprobada**: Barbería aceptó, afiliación activa
3. **Rechazada**: Barbería rechazó con motivo opcional
4. **Retirada**: Barbero canceló solicitud antes de respuesta

### 4.3 Reglas de Afiliación

#### Cuando un barbero está afiliado:
- Las búsquedas del cliente encuentran al barbero
- Al intentar reservar:
  - **Si tiene afiliación activa**: Redirigido automáticamente a la barbería
  - La reserva se crea asociada a la barbería
  - El barbero aparece como proveedor asignado
  
#### Múltiples afiliaciones:
- Un barbero puede tener solicitudes a múltiples barberías
- Solo puede tener UNA afiliación activa principal a la vez
- Puede cambiar de afiliación (solicitar nueva, cerrar anterior)

#### Límites:
- La barbería solo puede aceptar barberos hasta su límite del plan
- Si alcanza el límite, no puede aceptar nuevas solicitudes hasta liberar cupo

### 4.4 Validaciones
- ✅ Verificar que la barbería tenga cupo disponible
- ✅ Verificar que el barbero no tenga otra afiliación activa
- ✅ Notificar a ambas partes en cada cambio de estado
- ✅ Registrar fecha de inicio y fin de afiliación
- ✅ Permitir historial de afiliaciones

---

## 🎯 OBJETIVO 5: Sistema de Reservas

### 5.1 Flujo de Reserva

```
┌─────────────┐    Reserva      ┌─────────────────┐
│   CLIENTE   │ ───────────────>│ BARBERO/BARBERÍA│
│             │                 │                 │
│             │ <───────────────│                 │
│             │  Confirmación/  │                 │
│             │   Rechazo       │                 │
└─────────────┘                 └─────────────────┘
```

### 5.2 Estados de Reserva
1. **Pendiente**: Creada, esperando confirmación
2. **Confirmada**: Proveedor confirmó
3. **En Proceso**: Día/hora del servicio llegó
4. **Completada**: Servicio finalizado
5. **Cancelada Cliente**: Cliente canceló
6. **Cancelada Proveedor**: Barbero/Barbería canceló
7. **Rechazada**: Proveedor rechazó la solicitud inicial

### 5.3 Reglas de Negocio

#### Validación de Solapamiento (CRÍTICO):
```csharp
// NO debe existir solapamiento en fechas
bool HaySolapamiento(DateTime nuevoInicio, DateTime nuevoFin, 
                     DateTime existenteInicio, DateTime existenteFin)
{
    return !(nuevoFin <= existenteInicio || nuevoInicio >= existenteFin);
}
```

- ✅ Verificar solapamiento para el mismo proveedor
- ✅ Verificar solapamiento considerando duración del servicio
- ✅ Bloquear horarios no disponibles
- ✅ Considerar tiempo de preparación entre servicios (configurable)

#### Para Reservas de Barbero Afiliado:
- Si el barbero tiene afiliación activa:
  - La reserva se crea bajo la barbería
  - El barbero es el ejecutor del servicio
  - La barbería gestiona la confirmación
  
#### Cancelaciones:
- Cliente puede cancelar hasta X horas antes (configurable)
- Proveedor puede cancelar con justificación
- Cancelaciones afectan estadísticas y calificaciones

### 5.4 Búsqueda y Filtrado
- Buscar por ubicación (geolocalización para barberías)
- Buscar por especialidad/servicio
- Filtrar por disponibilidad de horario
- Filtrar por calificación
- Filtrar por precio
- Ver barberos afiliados a una barbería específica

---

## 🎯 OBJETIVO 6: Sistema de Notificaciones

### 6.1 Tipos de Notificaciones

| Tipo | Destinatario | Trigger | Acción Requerida |
|------|-------------|---------|------------------|
| SolicitudAfiliacionNueva | Barbería | Barbero solicita afiliación | Sí (Aceptar/Rechazar) |
| SolicitudAfiliacionAprobada | Barbero | Barbería acepta | No |
| SolicitudAfiliacionRechazada | Barbero | Barbería rechaza | No |
| CambioSuscripcionSolicitada | Admin, Comercial | Barbero/Barbería solicita cambio | Sí (Aprobar/Rechazar) |
| CambioSuscripcionAprobada | Barbero/Barbería | Admin/Comercial aprueba | No |
| CambioSuscripcionRechazada | Barbero/Barbería | Admin/Comercial rechaza | No |
| ReservaNueva | Barbero/Barbería | Cliente crea reserva | Sí (Confirmar/Rechazar) |
| ReservaConfirmada | Cliente | Proveedor confirma | No |
| ReservaRechazada | Cliente | Proveedor rechaza | No |
| ReservaCancelada | Proveedor | Cliente cancela | No |
| SuscripcionPorVencer | Barbero/Barbería | 7 días antes de vencimiento | Sí (Renovar) |
| SuscripcionVencida | Barbero/Barbería | Al vencer | Sí (Renovar) |
| NuevoRegistroBarberia | Admin, Comercial | Barbería se registra | Sí (Aprobar/Rechazar) |

### 6.2 Implementación
- Tabla `Notificacion` en BD
- Sistema de cola para envío asíncrono
- Marcador de leído/no leído
- Agrupación de notificaciones similares
- Limpieza automática de notificaciones antiguas (>30 días)

---

## 🎯 OBJETIVO 7: Sistema de Estadísticas

### 7.1 Estadísticas para Barberos

#### Plan Popular (Básicas):
- Total servicios realizados (mes actual, histórico)
- Total clientes únicos atendidos
- Ingresos totales del período
- Calificación promedio
- Tasa de cancelación

#### Plan Premium (Completas):
- Todas las anteriores
- Servicios más solicitados (ranking)
- Horas pico de trabajo
- Ingresos por tipo de servicio
- Estadísticas de productos (ventas, ingresos)
- Comparativa mes actual vs mes anterior
- Gráficos de tendencia

### 7.2 Estadísticas para Barberías
- Total reservas (propias + afiliados)
- Total clientes únicos
- Ingresos totales
- Calificación promedio general
- Tasa de ocupación (%)
- Barberos más activos (ranking)
- Servicios más solicitados
- Productos más vendidos (si aplica)
- Proyección de ingresos

### 7.3 Estadísticas para Comercial
- Dashboard general con:
  - Total barberos por plan
  - Total barberías por plan
  - Suscripciones por vencer (próximos 7 días)
  - Suscripciones vencidas
  - Nuevos registros (semanal/mensual)
  - Tasa de aprobación de cambios de plan
  - Ingresos proyectidos del sistema

### 7.4 Estadísticas para Admin
- Todas las anteriores
- Estadísticas globales del sistema
- Crecimiento de usuarios
- Retención de clientes
- Análisis financiero completo

---

## 🎯 OBJETIVO 8: Validaciones de Flujos Críticos

### 8.1 Flujo de Registro de Barbero
```
1. Cliente selecciona "Registrarse como Barbero"
2. Completa datos básicos (Usuario)
3. Sistema crea:
   - Usuario con rol "Barbero"
   - PerfilBarbero con plan "Free"
4. Email de verificación (opcional)
5. Login disponible
6. Limitaciones: No puede recibir reservas con plan Free
```

### 8.2 Flujo de Registro de Barbería
```
1. Usuario selecciona "Registrar Barbería"
2. Completa datos de la barbería
3. Selecciona plan de suscripción inicial
4. Sistema crea:
   - Usuario con rol "Barberia"
   - PerfilBarberia con estado "PendienteAprobacion"
   - Solicitud de suscripción
5. Notificación a Admin y Comercial
6. Barbería NO puede:
   - Afiliar barberos
   - Recibir reservas
   Hasta que sea aprobada
7. Admin/Comercial aprueba → Estado cambia a "Activo"
```

### 8.3 Flujo de Reserva (Validación de Solapamiento)
```
1. Cliente selecciona servicio y horario
2. Sistema verifica:
   □ Proveedor existe y está activo
   □ Proveedor tiene plan que permite reservas
   □ Horario no está bloqueado
   □ NO hay solapamiento con reservas existentes
   □ Horario está dentro del horario laboral
   □ Día es laborable para el proveedor
3. Si todo OK → Crear reserva con estado "Pendiente"
4. Notificar al proveedor
5. Proveedor confirma/rechaza
6. Notificar al cliente
```

### 8.4 Flujo de Cambio de Suscripción
```
1. Usuario (Barbero/Barbería) selecciona nuevo plan
2. Sistema valida:
   □ Plan existe y está activo
   □ Usuario puede solicitar este plan
   □ No hay solicitud pendiente previa
3. Crear solicitud con estado "Pendiente"
4. Notificar a Admin y Comercial
5. Admin O Comercial revisa:
   - Opción A: Aprobar → Actualizar plan, fecha vencimiento
   - Opción B: Rechazar → Notificar con motivo
   - Opción C: Mantener pendiente
6. Notificar decisión al solicitante
```

### 8.5 Flujo de Afiliación
```
1. Barbero busca barbería
2. Solicita afiliación
3. Sistema valida:
   □ Barbero no tiene afiliación activa
   □ Barbería tiene cupo disponible (según plan)
   □ No hay solicitud previa pendiente con esta barbería
4. Crear solicitud con estado "Pendiente"
5. Notificar a barbería
6. Barbería revisa:
   - Opción A: Aprobar → Crear afiliación activa
   - Opción B: Rechazar → Notificar con motivo
7. Notificar a barbero
8. Si aprobada:
   - Próximas reservas del barbero → redirigir a barbería
   - Barbería puede gestionar reservas del barbero
```

### 8.6 Flujo de Vencimiento de Suscripción
```
1. Job programado (diario) verifica suscripciones
2. Para cada suscripción:
   □ Si vence en 7 días → Notificar "Por vencer"
   □ Si venció hoy → 
      - Cambiar estado a "Vencido"
      - Barbero: Downgrade a Free (pierde reservas)
      - Barbería: Desactivar hasta renovación
      - Notificar a usuario
   □ Si vencida y pasó X días → 
      - Eliminar privilegios
      - Notificar nuevamente
```

---

## 🎯 OBJETIVO 9: Estructura de Archivos a Crear

### API.Data/Entidades/Multibarbero/
```
├── PlanSuscripcion.cs
├── CaracteristicaPlan.cs
├── LimitesPlan.cs
├── PerfilBarbero.cs
├── PerfilBarberia.cs
├── PerfilCliente.cs
├── Servicio.cs
├── CategoriaServicio.cs
├── Producto.cs
├── CategoriaProducto.cs
├── Reserva.cs
├── SolicitudAfiliacion.cs
├── AfiliacionBarbero.cs
├── Notificacion.cs
├── EstadisticaBarbero.cs
├── EstadisticaBarberia.cs
└── EstadisticaProducto.cs
```

### API.Data/Enum/Multibarbero/
```
├── TipoPlan.cs
├── TipoProveedor.cs
├── EstadoReserva.cs
├── EstadoSolicitudAfiliacion.cs
├── EstadoSuscripcion.cs
├── TipoNotificacion.cs
└── DiaSemana.cs
```

### API.Data/ConfiguracionEntidades/Multibarbero/
```
├── PlanSuscripcionConfiguracionBD.cs
├── PerfilBarberoConfiguracionBD.cs
├── PerfilBarberiaConfiguracionBD.cs
├── ReservaConfiguracionBD.cs
├── SolicitudAfiliacionConfiguracionBD.cs
├── AfiliacionBarberoConfiguracionBD.cs
├── NotificacionConfiguracionBD.cs
└── ... (una por entidad)
```

### API.Domain/Interfaces/Multibarbero/
```
├── IPlanSuscripcionService.cs
├── IPerfilBarberoService.cs
├── IPerfilBarberiaService.cs
├── IReservaService.cs
├── ISolicitudAfiliacionService.cs
├── INotificacionService.cs
├── IEstadisticaService.cs
└── ... (uno por entidad)
```

### API.Domain/Services/Multibarbero/
```
├── PlanSuscripcionService.cs
├── PerfilBarberoService.cs
├── PerfilBarberiaService.cs
├── ReservaService.cs
├── SolicitudAfiliacionService.cs
├── NotificacionService.cs
├── EstadisticaService.cs
└── ... (uno por entidad)
```

### API.Domain/Validators/Multibarbero/
```
├── PlanSuscripcionValidator.cs
├── PerfilBarberoValidator.cs
├── PerfilBarberiaValidator.cs
├── ReservaValidator.cs
├── SolicitudAfiliacionValidator.cs
└── ... (uno por entidad)
```

### API.Application/Dtos/Multibarbero/
```
├── PlanSuscripcion/
│   ├── PlanSuscripcionDto.cs
│   ├── CrearPlanSuscripcionInputDto.cs
│   ├── ActualizarPlanSuscripcionInputDto.cs
│   ├── DetallesPlanSuscripcionDto.cs
│   ├── ListadoPaginadoPlanSuscripcionDto.cs
│   └── FiltrarConfigurarListadoPaginadoPlanSuscripcionInputDto.cs
├── PerfilBarbero/
│   ├── ... (mismo patrón)
├── PerfilBarberia/
│   ├── ... (mismo patrón)
├── Reserva/
│   ├── ... (mismo patrón)
└── ... (para cada entidad)
```

### API.Application/Mapper/Multibarbero/
```
├── PlanSuscripcionDtoProfile.cs
├── PerfilBarberoDtoProfile.cs
├── PerfilBarberiaDtoProfile.cs
├── ReservaDtoProfile.cs
└── ... (uno por entidad)
```

### API.Application/Controllers/Multibarbero/
```
├── PlanSuscripcionController.cs
├── PerfilBarberoController.cs
├── PerfilBarberiaController.cs
├── ReservaController.cs
├── SolicitudAfiliacionController.cs
├── NotificacionController.cs
├── EstadisticaController.cs
└── ... (uno por entidad)
```

### API.Application/Validadotors/Multibarbero/
```
├── CrearPlanSuscripcionDtoValidator.cs
├── CrearPerfilBarberoDtoValidator.cs
├── CrearReservaDtoValidator.cs
└── ... (uno por DTO de creación/actualización)
```

### API.Data/IUnitOfWorks/Interfaces/Multibarbero/
```
├── IPlanSuscripcionRepository.cs
├── IPerfilBarberoRepository.cs
├── IReservaRepository.cs
└── ... (uno por entidad)
```

### API.Data/IUnitOfWorks/Repositorios/Multibarbero/
```
├── PlanSuscripcionRepository.cs
├── PerfilBarberoRepository.cs
├── ReservaRepository.cs
└── ... (uno por entidad)
```

---

## 🎯 OBJETIVO 10: Jobs Programados (Hangfire)

### 10.1 Jobs a Implementar

1. **VerificarSuscripcionesPorVencer** (Diario, 8:00 AM)
   - Busca suscripciones que vencen en 7 días
   - Envía notificaciones

2. **VerificarSuscripcionesVencidas** (Cada hora)
   - Busca suscripciones vencidas
   - Aplica downgrade/desactivación
   - Envía notificaciones

3. **LimpiarNotificacionesAntiguas** (Semanal)
   - Elimina notificaciones > 30 días
   - Limpia la tabla

4. **CalcularEstadisticasMensuales** (Primero de cada mes)
   - Genera estadísticas del mes anterior
   - Actualiza tablas de estadísticas

5. **RecordatorioReservasPendientes** (Cada 30 min)
   - Notifica proveedores sobre reservas pendientes > 1 hora

---

## 🎯 OBJETIVO 11: Actualización de DbContext y UnitOfWork

### 11.1 ApiDbContext.cs
Agregar DbSets para todas las nuevas entidades:
```csharp
public DbSet<PlanSuscripcion> PlanesSuscripcion { get; set; }
public DbSet<PerfilBarbero> PerfilesBarbero { get; set; }
public DbSet<PerfilBarberia> PerfilesBarberia { get; set; }
public DbSet<Reserva> Reservas { get; set; }
public DbSet<SolicitudAfiliacion> SolicitudesAfiliacion { get; set; }
public DbSet<AfiliacionBarbero> AfiliacionesBarbero { get; set; }
public DbSet<Notificacion> Notificaciones { get; set; }
// ... etc
```

### 11.2 IApiDbContext.cs
Agregar las mismas propiedades

### 11.3 UnitOfWork.cs
Agregar los nuevos repositories

### 11.4 IoCRegister.cs
Registrar todos los nuevos servicios y repositories

---

## 🎯 OBJETIVO 12: Seeders de Datos Iniciales

### 12.1 Roles
Crear los 5 roles si no existen

### 12.2 Permisos
Crear permisos base para cada rol

### 12.3 Planes de Suscripción
Crear planes iniciales:
- Barbero: Free, Popular, Premium
- Barbería: Básico, Estándar, Enterprise

### 12.4 Categorías
- Categorías de servicios (Corte, Barba, Color, etc.)
- Categorías de productos (Cera, Aceite, Peine, etc.)

---

## 📅 Cronograma Estimado de Implementación

| Fase | Objetivos | Duración Estimada |
|------|-----------|-------------------|
| 1 | Objetivo 1-2 (Entidades + Roles) | 3 días |
| 2 | Objetivo 3-4 (Suscripciones + Afiliaciones) | 4 días |
| 3 | Objetivo 5 (Reservas) | 3 días |
| 4 | Objetivo 6-7 (Notificaciones + Estadísticas) | 3 días |
| 5 | Objetivo 8-9 (Validaciones + Controllers) | 4 días |
| 6 | Objetivo 10-12 (Jobs + Config + Tests) | 3 días |
| **Total** | | **20 días** |

---

## ✅ Checklist de Validación Final

- [ ] Todos los roles creados y configurados
- [ ] Todos los permisos asignados correctamente
- [ ] Planes de suscripción creados
- [ ] Flujo de registro de barbero funciona (plan Free default)
- [ ] Flujo de registro de barbería requiere aprobación
- [ ] Cambio de suscripción requiere aprobación Admin/Comercial
- [ ] Afiliación barbero-barbería funciona con notificaciones
- [ ] Reservas no permiten solapamiento de fechas
- [ ] Reservas requieren confirmación del proveedor
- [ ] Notificaciones se envían en todos los triggers
- [ ] Estadísticas se calculan correctamente según plan
- [ ] Vencimiento de suscripciones maneja downgrade automático
- [ ] Comercial puede ver estadísticas y aprobar cambios
- [ ] Admin tiene control total
- [ ] Cliente puede buscar y reservar sin problemas
- [ ] Jobs programados ejecutan correctamente
- [ ] Tests unitarios cubren flujos críticos

---

## 🔑 Puntos Críticos de Atención

1. **NO solapamiento de fechas en reservas** - Validación crítica
2. **Aprobación requerida para cambios de suscripción** - Flujo obligatorio
3. **Barberías no tienen plan Free** - Validación en registro
4. **Barberos comienzan con plan Free** - Default automático
5. **Redirección de reservas cuando hay afiliación** - Lógica compleja
6. **Límite de barberos por plan de barbería** - Validar antes de aceptar afiliación
7. **Notificaciones bidireccionales** - Ambas partes deben ser notificadas
8. **Estados de solicitudes** - Manejar correctamente transiciones

---

*Documento creado para guiar la implementación del Sistema Multibarbero*
