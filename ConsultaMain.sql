CREATE DATABASE BellezaTotal;
GO
USE BellezaTotal;
GO
CREATE SCHEMA Seguridad;
GO
CREATE SCHEMA Negocio;
GO


CREATE TABLE Seguridad.Idioma (
    Codigo NVARCHAR(10) NOT NULL PRIMARY KEY,
    Nombre NVARCHAR(50) NOT NULL UNIQUE
);

CREATE TABLE Seguridad.Leyenda (
    IdiomaCodigo NVARCHAR(10)  NOT NULL REFERENCES Seguridad.Idioma(Codigo),
    Clave        NVARCHAR(100) NOT NULL,
    Texto        NVARCHAR(300) NOT NULL,
    PRIMARY KEY (IdiomaCodigo, Clave)
);
GO

INSERT INTO Seguridad.Idioma (Codigo, Nombre) VALUES ('es', N'Español'), ('en', N'English');

GO

INSERT INTO Seguridad.Leyenda (IdiomaCodigo, Clave, Texto) VALUES
('es', 'FormBitacora.Text', N'Bitácora'),
('es', 'FormBitacora.lblFechaDesde', N'Desde'),
('es', 'FormBitacora.lblFechaHasta', N'Hasta'),
('es', 'FormBitacora.lblUsuario', N'Usuario'),
('es', 'FormBitacora.lblSeveridad', N'Severidad'),
('es', 'FormBitacora.datagvBitacora.colFechaHora', N'Fecha y hora'),
('es', 'FormBitacora.datagvBitacora.colUsuario', N'Usuario'),
('es', 'FormBitacora.datagvBitacora.colSeveridad', N'Severidad'),
('es', 'FormBitacora.datagvBitacora.colAccion', N'Acción'),
('es', 'FormBitacora.datagvBitacora.colDescripcion', N'Descripción'),
('es', 'FormBitacora.sinResultados', N'No se encontraron eventos para los filtros ingresados'),
('es', 'FormBitacora.fechasInvalidas', N'La fecha desde no puede ser posterior a la fecha hasta'),
('es', 'Comun.Cualquiera', N'<<Cualquiera>>'),
('es', 'Severidad.Info', N'Info'),
('es', 'Severidad.Warning', N'Advertencia'),
('es', 'Severidad.Error', N'Error'),
('es', 'Mensajes.ConfirmarCerrarSesion', N'¿Desea cerrar la sesión?'),

('en', 'FormBitacora.Text', N'Audit log'),
('en', 'FormBitacora.lblFechaDesde', N'From'),
('en', 'FormBitacora.lblFechaHasta', N'To'),
('en', 'FormBitacora.lblUsuario', N'User'),
('en', 'FormBitacora.lblSeveridad', N'Severity'),
('en', 'FormBitacora.datagvBitacora.colFechaHora', N'Date and time'),
('en', 'FormBitacora.datagvBitacora.colUsuario', N'User'),
('en', 'FormBitacora.datagvBitacora.colSeveridad', N'Severity'),
('en', 'FormBitacora.datagvBitacora.colAccion', N'Action'),
('en', 'FormBitacora.datagvBitacora.colDescripcion', N'Description'),
('en', 'FormBitacora.sinResultados', N'No events found for the selected filters'),
('en', 'FormBitacora.fechasInvalidas', N'The start date cannot be later than the end date'),
('en', 'Comun.Cualquiera', N'<<Any>>'),
('en', 'Severidad.Info', N'Info'),
('en', 'Severidad.Warning', N'Warning'),
('en', 'Severidad.Error', N'Error'),
('en', 'Mensajes.ConfirmarCerrarSesion', N'Do you want to log out?');
GO

CREATE TABLE Seguridad.Usuarios(
	UsuarioId INT IDENTITY(1,1) PRIMARY KEY,
	NombreUsuario NVARCHAR(50) NOT NULL,
	ContrasenaHash NVARCHAR(256) NOT NULL,
	Email NVARCHAR(50) NOT NULL,
	IdiomaPreferido NVARCHAR(20) NOT NULL DEFAULT 'es' REFERENCES Seguridad.Idioma(Codigo),
	IntentosFallidos INT NOT NULL DEFAULT 0,
	Activo BIT NOT NULL DEFAULT 1
);

-- Consulta para insertar un usuario administrador. el valor "8C6976E5B5410415BDE908BD4DEE15DFB167A9C873FC4BB8A81F6F2AB448A918" es la palabra "admin" hasheada
-- INSERT INTO Seguridad.Usuarios (NombreUsuario, ContrasenaHash, Email) VALUES ('admin', '8C6976E5B5410415BDE908BD4DEE15DFB167A9C873FC4BB8A81F6F2AB448A918', 'admin@bellezatotal.com')

GO





GO

CREATE TABLE Seguridad.Familia (
    FamiliaId INT IDENTITY PRIMARY KEY,
    Nombre NVARCHAR(50) NOT NULL UNIQUE
);
CREATE TABLE Seguridad.Patente (
    PatenteId INT IDENTITY PRIMARY KEY,
    Nombre NVARCHAR(50) NOT NULL UNIQUE,      
    Descripcion NVARCHAR(200) NULL
);
CREATE TABLE Seguridad.Familia_Patente (
    FamiliaId INT NOT NULL REFERENCES Seguridad.Familia(FamiliaId),
    PatenteId INT NOT NULL REFERENCES Seguridad.Patente(PatenteId),
    PRIMARY KEY (FamiliaId, PatenteId)
);
CREATE TABLE Seguridad.Familia_Familia (
    FamiliaPadreId INT NOT NULL REFERENCES Seguridad.Familia(FamiliaId),
    FamiliaHijaId  INT NOT NULL REFERENCES Seguridad.Familia(FamiliaId),
    PRIMARY KEY (FamiliaPadreId, FamiliaHijaId)
);
CREATE TABLE Seguridad.Usuario_Familia (
    UsuarioId INT NOT NULL REFERENCES Seguridad.Usuarios(UsuarioId),
    FamiliaId INT NOT NULL REFERENCES Seguridad.Familia(FamiliaId),
    PRIMARY KEY (UsuarioId, FamiliaId)
);
CREATE TABLE Seguridad.Usuario_Patente (
    UsuarioId INT NOT NULL REFERENCES Seguridad.Usuarios(UsuarioId),
    PatenteId INT NOT NULL REFERENCES Seguridad.Patente(PatenteId),
    PRIMARY KEY (UsuarioId, PatenteId)
);

DELETE FROM Seguridad.Usuario_Patente;
DELETE FROM Seguridad.Usuario_Familia;
DELETE FROM Seguridad.Familia_Familia;
DELETE FROM Seguridad.Familia_Patente;
DELETE FROM Seguridad.Familia;
DELETE FROM Seguridad.Patente;

INSERT INTO Seguridad.Patente (Nombre, Descripcion) VALUES
    ('pat_IniciarSesion',         'Iniciar sesión'),
    ('pat_CerrarSesion',          'Cerrar sesión'),
    ('pat_RecuperarClave',        'Recuperar contraseña'),
    ('pat_Registrarse',           'Registrarse'),
    ('pat_CambiarIdioma',         'Cambiar idioma'),
    ('pat_GestionarTurnos',       'Alta, baja, modificación y consulta de turnos'),
    ('pat_VerTurnosPropios',      'Ver los turnos asignados al profesional'),
    ('pat_GestionarClientes',     'Alta, baja, modificación y consulta de clientes'),
    ('pat_VerClientes',           'Ver clientes y sus fichas técnicas'),
    ('pat_VerServicios',          'Ver servicios'),
    ('pat_GestionarServicios',    'Gestionar catálogo de servicios'),
    ('pat_VerPlanes',             'Ver planes'),
    ('pat_GestionarPlanes',       'Gestionar planes estéticos'),
    ('pat_VerInsumos',            'Ver insumos'),
    ('pat_DescontarInsumos',      'Descontar insumos consumidos'),
    ('pat_GestionarInsumos',      'Gestionar insumos'),
    ('pat_NotificarLlegada',      'Registrar llegada de clientes'),
    ('pat_VerSalaEspera',         'Ver sala de espera'),
    ('pat_GestionarProfesionales','Gestionar profesionales'),
    ('pat_GestionarCabinas',      'Gestionar cabinas'),
    ('pat_VerConsumoHardware',    'Ver consumo de recursos de hardware'),
    ('pat_VerBitacora',           'Consultar bitácora'),
    ('pat_GenerarBackup',         'Generar copias de respaldo'),
    ('pat_RestaurarBackup',       'Restaurar la base de datos'),
    ('pat_VerAnaliticas',         'Ver analíticas'),
    ('pat_GestionarUsuarios',     'Gestionar usuarios'),
    ('pat_GestionarFamilias',     'Gestionar familias'),
    ('pat_AsignarPatentes',       'Asignar patentes a familias y usuarios');

INSERT INTO Seguridad.Familia (Nombre) VALUES
    ('FAM_AUTENTIFICACION'), ('FAM_CONFIGURACION'), ('FAM_INVITADO'),
    ('FAM_PROFESIONAL'), ('FAM_RECEPCIONISTA'), ('FAM_GERENTE'), ('FAM_ADMINISTRADOR');

-- Patentes de cada familia
INSERT INTO Seguridad.Familia_Patente (FamiliaId, PatenteId)
SELECT familia.FamiliaId, patente.PatenteId
FROM (VALUES
    ('FAM_AUTENTIFICACION', 'pat_IniciarSesion'),
    ('FAM_AUTENTIFICACION', 'pat_CerrarSesion'),
    ('FAM_AUTENTIFICACION', 'pat_RecuperarClave'),
    ('FAM_AUTENTIFICACION', 'pat_Registrarse'),
    ('FAM_CONFIGURACION',   'pat_CambiarIdioma'),

    ('FAM_PROFESIONAL', 'pat_VerTurnosPropios'),
    ('FAM_PROFESIONAL', 'pat_VerClientes'),
    ('FAM_PROFESIONAL', 'pat_VerInsumos'),
    ('FAM_PROFESIONAL', 'pat_DescontarInsumos'),
    ('FAM_PROFESIONAL', 'pat_VerServicios'),
    ('FAM_PROFESIONAL', 'pat_VerPlanes'),
    ('FAM_PROFESIONAL', 'pat_VerSalaEspera'),

    ('FAM_RECEPCIONISTA', 'pat_GestionarTurnos'),
    ('FAM_RECEPCIONISTA', 'pat_GestionarClientes'),
    ('FAM_RECEPCIONISTA', 'pat_VerServicios'),
    ('FAM_RECEPCIONISTA', 'pat_VerInsumos'),
    ('FAM_RECEPCIONISTA', 'pat_VerPlanes'),
    ('FAM_RECEPCIONISTA', 'pat_NotificarLlegada'),
    ('FAM_RECEPCIONISTA', 'pat_VerSalaEspera'),

    ('FAM_GERENTE', 'pat_GestionarServicios'),
    ('FAM_GERENTE', 'pat_GestionarInsumos'),
    ('FAM_GERENTE', 'pat_GestionarPlanes'),
    ('FAM_GERENTE', 'pat_GestionarProfesionales'),
    ('FAM_GERENTE', 'pat_GestionarCabinas'),
    ('FAM_GERENTE', 'pat_VerConsumoHardware'),
    ('FAM_GERENTE', 'pat_VerBitacora'),
    ('FAM_GERENTE', 'pat_GenerarBackup'),

    ('FAM_ADMINISTRADOR', 'pat_VerAnaliticas'),
    ('FAM_ADMINISTRADOR', 'pat_GestionarUsuarios'),
    ('FAM_ADMINISTRADOR', 'pat_GestionarFamilias'),
    ('FAM_ADMINISTRADOR', 'pat_AsignarPatentes'),
    ('FAM_ADMINISTRADOR', 'pat_RestaurarBackup')
) AS relacion (NombreFamilia, NombrePatente)
JOIN Seguridad.Familia AS familia ON familia.Nombre = relacion.NombreFamilia
JOIN Seguridad.Patente AS patente ON patente.Nombre = relacion.NombrePatente;

-- Familias dentro de familias
INSERT INTO Seguridad.Familia_Familia (FamiliaPadreId, FamiliaHijaId)
SELECT padre.FamiliaId, hija.FamiliaId
FROM (VALUES
    ('FAM_INVITADO',      'FAM_AUTENTIFICACION'),
    ('FAM_INVITADO',      'FAM_CONFIGURACION'),
    ('FAM_PROFESIONAL',   'FAM_AUTENTIFICACION'),
    ('FAM_PROFESIONAL',   'FAM_CONFIGURACION'),
    ('FAM_RECEPCIONISTA', 'FAM_AUTENTIFICACION'),
    ('FAM_RECEPCIONISTA', 'FAM_CONFIGURACION'),
    ('FAM_GERENTE',       'FAM_RECEPCIONISTA'),
    ('FAM_ADMINISTRADOR', 'FAM_GERENTE')
) AS relacion (NombrePadre, NombreHija)
JOIN Seguridad.Familia AS padre ON padre.Nombre = relacion.NombrePadre
JOIN Seguridad.Familia AS hija  ON hija.Nombre  = relacion.NombreHija;



CREATE TABLE Seguridad.Bitacora (
    BitacoraId    INT IDENTITY PRIMARY KEY,
    FechaHora     DATETIME2     NOT NULL DEFAULT SYSDATETIME(),
    UsuarioId     INT           NULL REFERENCES Seguridad.Usuarios(UsuarioId),
    NombreUsuario NVARCHAR(50)  NULL,
    Severidad     NVARCHAR(10)  NOT NULL CHECK (Severidad IN ('INFO', 'WARNING', 'ERROR')),
    Accion        NVARCHAR(100) NOT NULL,
    Descripcion   NVARCHAR(500) NULL
);

GO

CREATE TRIGGER Seguridad.trg_Bitacora_SoloLectura
ON Seguridad.Bitacora INSTEAD OF UPDATE, DELETE 
AS
BEGIN
    THROW 50000, 'La bitácora es de solo lectura', 1;
END;

GO