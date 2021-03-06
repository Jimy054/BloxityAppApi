USE [EjercicioBloxity]
GO
/****** Object:  Table [dbo].[Productos]    Script Date: 13/07/2022 11:07:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Productos](
	[ProductoID] [bigint] IDENTITY(1,1) NOT NULL,
	[ProveedorID] [bigint] NULL,
	[Codigo] [varchar](20) NOT NULL,
	[Descripcion] [varchar](150) NOT NULL,
	[Unidad] [varchar](3) NOT NULL,
	[Costo] [decimal](18, 0) NOT NULL,
	[Estado] [varchar](50) NULL,
	[FechaDeCreacion] [datetime] NULL,
	[FechaDeModificacion] [datetime] NULL,
	[FechaDeEliminacion] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[ProductoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[Codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Proveedores]    Script Date: 13/07/2022 11:07:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Proveedores](
	[ProveedorID] [bigint] IDENTITY(1,1) NOT NULL,
	[Codigo] [varchar](20) NOT NULL,
	[RazonSocial] [varchar](150) NOT NULL,
	[RFC] [varchar](13) NOT NULL,
	[Estado] [varchar](50) NULL,
	[FechaDeCreacion] [datetime] NULL,
	[FechaDeModificacion] [datetime] NULL,
	[FechaDeEliminacion] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[ProveedorID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[Codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Productos]  WITH CHECK ADD FOREIGN KEY([ProveedorID])
REFERENCES [dbo].[Proveedores] ([ProveedorID])
GO
