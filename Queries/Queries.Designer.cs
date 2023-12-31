﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ApiNetCore7.Queries {
    using System;
    
    
    /// <summary>
    ///   Clase de recurso fuertemente tipado, para buscar cadenas traducidas, etc.
    /// </summary>
    // StronglyTypedResourceBuilder generó automáticamente esta clase
    // a través de una herramienta como ResGen o Visual Studio.
    // Para agregar o quitar un miembro, edite el archivo .ResX y, a continuación, vuelva a ejecutar ResGen
    // con la opción /str o recompile su proyecto de VS.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "17.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class Queries {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Queries() {
        }
        
        /// <summary>
        ///   Devuelve la instancia de ResourceManager almacenada en caché utilizada por esta clase.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("ApiNetCore7.Queries.Queries", typeof(Queries).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Reemplaza la propiedad CurrentUICulture del subproceso actual para todas las
        ///   búsquedas de recursos mediante esta clase de recurso fuertemente tipado.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a INSERT INTO PEDIDO_DETALLE (PEDIDO_ID, CANTIDAD, PRODUCTO_ID) VALUES (:PEDIDO_ID, :CANTIDAD, :PRODUCTO_ID).
        /// </summary>
        public static string INS_DET_PEDIDO {
            get {
                return ResourceManager.GetString("INS_DET_PEDIDO", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a INSERT INTO PANADERIA.PEDIDO (CANTIDAD_SOLICITADA, FECHA_PEDIDO, USUARIO_ID, RUTA_ID)
        ///VALUES (:CANTIDAD_SOLICITADA, :FECHA_PEDIDO, :USUARIO_ID, :RUTA_ID)
        ///RETURNING PEDIDO_ID INTO :PedidoIdRetornado.
        /// </summary>
        public static string INS_PEDIDO {
            get {
                return ResourceManager.GetString("INS_PEDIDO", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a INSERT INTO &quot;PANADERIA&quot;.&quot;PRODUCTO&quot; 
        ///    (&quot;RECETA_ID&quot;, &quot;NOMBRE&quot;, &quot;DESCRIPCION&quot;, &quot;SUCURSAL_ID&quot;, &quot;PRECIO&quot;, &quot;IMAGEN&quot;, &quot;STOCK_ORIGINAL&quot;, &quot;STOCK_ACTUAL&quot;)
        ///VALUES
        ///    (:RECETA_ID, :NOMBRE, :DESCRIPCION, :SUCURSAL_ID, :PRECIO, :IMAGEN, :STOCK_ORIGINAL, :STOCK_ACTUAL).
        /// </summary>
        public static string INS_PRODUCTO {
            get {
                return ResourceManager.GetString("INS_PRODUCTO", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a INSERT INTO receta (NOMBRE, DESCRIPCION)
        ///VALUES (:NOMBRE, :DESCRIPCION)
        ///RETURNING RECETA_ID INTO :RecetaIdRetornado.
        /// </summary>
        public static string INS_RECETA {
            get {
                return ResourceManager.GetString("INS_RECETA", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a INSERT INTO receta_detalle (RECETA_ID, INGREDIENTE_ID, CANTIDAD_NECESARIA,UNIDAD_MEDIDA_ID)
        ///VALUES (:RECETA_ID, :INGREDIENTE_ID, :CANTIDAD_NECESARIA,:UNIDAD_MEDIDA_ID).
        /// </summary>
        public static string INS_RECETA_DETALLE {
            get {
                return ResourceManager.GetString("INS_RECETA_DETALLE", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a INSERT INTO RUTA (TRANSPORTE_ID, SUCURSAL_ID, DESCRIPCION, DISTANCIA, TIEMPO_ESTIMADO) 
        ///            VALUES (:TRANSPORTE_ID, :SUCURSAL_ID, :DESCRIPCION, :DISTANCIA, :TIEMPO_ESTIMADO).
        /// </summary>
        public static string INS_RUTA {
            get {
                return ResourceManager.GetString("INS_RUTA", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a SELECT
        ///    inicio.nombre nombre_inicio,
        ///    fin.nombre    nombre_fin,
        ///    a.ruta_id,
        ///    a.distancia,
        ///    a.descripcion,
        ///    t.descripcion AS descripcion_transporte,
        ///    t.tipo,
        ///    inicio.sucursal_id sucursal_id_ini
        ///FROM
        ///         ruta a
        ///    INNER JOIN sucursal             fin ON fin.sucursal_id = a.sucursal_id_fin
        ///    INNER JOIN sucursal             inicio ON a.sucursal_id_origen = inicio.sucursal_id
        ///    INNER JOIN panaderia.transporte t ON a.transporte_id = t.transporte_id
        ///WHERE
        ///    a.ruta_ [resto de la cadena truncado]&quot;;.
        /// </summary>
        public static string SEL_INFO_RUTA_BY_ID {
            get {
                return ResourceManager.GetString("SEL_INFO_RUTA_BY_ID", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a SELECT
        ///   *
        ///FROM
        ///    ingrediente.
        /// </summary>
        public static string SEL_INGREDIENTES {
            get {
                return ResourceManager.GetString("SEL_INGREDIENTES", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a SELECT 
        ///        u.USUARIO_ID, u.NOMBRE,u.Usuario, u.FECHA_CREACION, u.ULTIMO_INGRESO, 
        ///        r.ROL_TIPO_ID, r.NOMBRE AS RolNombre, r.DESCRIPCION AS RolDESCRIPCION 
        ///    FROM 
        ///        USUARIO u 
        ///    INNER JOIN 
        ///        ROL_TIPO r ON u.ROL_TIPO_ID = r.ROL_TIPO_ID 
        ///    WHERE 
        ///        u.usuario = :nombreUsuario AND u.CONTRASEnA = :contrasena.
        /// </summary>
        public static string SEL_LOGIN {
            get {
                return ResourceManager.GetString("SEL_LOGIN", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a SELECT
        ///    *
        ///FROM
        ///         panaderia.pedido a
        ///    INNER JOIN panaderia.status     b ON a.status = b.status
        ///                                     AND a.mini_sistem_id = b.mini_sistem_id
        ///    INNER JOIN panaderia.ruta       r ON a.ruta_id = r.ruta_id
        ///    INNER JOIN panaderia.usuario    d ON d.usuario_id = a.usuario_id
        ///    INNER JOIN panaderia.transporte c ON c.transporte_id = r.transporte_id.
        /// </summary>
        public static string SEL_PEDIDOS_Y_DETS {
            get {
                return ResourceManager.GetString("SEL_PEDIDOS_Y_DETS", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a SELECT
        ///   *
        ///FROM
        ///    producto a where SUCURSAL_ID=:sucursal_id.
        /// </summary>
        public static string SEL_PRODUCTOS_BY_TIENDA {
            get {
                return ResourceManager.GetString("SEL_PRODUCTOS_BY_TIENDA", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a SELECT
        ///    a.receta_id,
        ///    a.nombre,
        ///    a.descripcion,
        ///    b.receta_detalle_id,
        ///    b.ingrediente_id,
        ///    b.cantidad_necesaria,
        ///    b.unidad_medida_id,
        ///    c.nombre      AS nombre1,
        ///    c.descripcion AS descripcion1,
        ///    c.stock_actual
        ///FROM
        ///         receta a
        ///    INNER JOIN panaderia.receta_detalle b ON a.receta_id = b.receta_id
        ///    INNER JOIN panaderia.ingrediente    c ON c.ingrediente_id = b.ingrediente_id
        ///WHERE
        ///    b.receta_id = :receta_id.
        /// </summary>
        public static string SEL_RECETA_AND_DET_BY_ID {
            get {
                return ResourceManager.GetString("SEL_RECETA_AND_DET_BY_ID", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a SELECT
        ///    b.receta_id,
        ///    panaderia.unidad_medida.*,
        ///    panaderia.unidad_medida.unidad_medida_id AS unidad_medida_id1,
        ///    panaderia.unidad_medida.nombre           AS nombre1,
        ///    panaderia.unidad_medida.abreviatura      AS abreviatura1,
        ///    b.receta_detalle_id,
        ///    b.ingrediente_id,
        ///    b.cantidad_necesaria,
        ///    b.unidad_medida_id                       AS unidad_medida_id2,
        ///    c.ingrediente_id                         AS ingrediente_id1,
        ///    c.nombre                                 AS nombre2 [resto de la cadena truncado]&quot;;.
        /// </summary>
        public static string SEL_RECETA_DET_BY_ID {
            get {
                return ResourceManager.GetString("SEL_RECETA_DET_BY_ID", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a SELECT
        ///    receta_id,
        ///    nombre,
        ///    descripcion
        ///FROM
        ///    receta.
        /// </summary>
        public static string SEL_RECETAS {
            get {
                return ResourceManager.GetString("SEL_RECETAS", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a SELECT
        ///*
        ///FROM
        ///ruta.
        /// </summary>
        public static string SEL_RUTAS {
            get {
                return ResourceManager.GetString("SEL_RUTAS", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a SELECT
        ///  *
        ///FROM
        ///    sucursal.
        /// </summary>
        public static string SEL_SUCURSALES {
            get {
                return ResourceManager.GetString("SEL_SUCURSALES", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a SELECT
        ///    unidad_medida_id,
        ///    nombre,
        ///    abreviatura
        ///FROM
        ///    unidad_medida.
        /// </summary>
        public static string SEL_UNIDADES_MEDIDA {
            get {
                return ResourceManager.GetString("SEL_UNIDADES_MEDIDA", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a SELECT 
        ///                u.USUARIO_ID, u.NOMBRE, u.CONTRASENA, u.FECHA_CREACION, u.ULTIMO_INGRESO, 
        ///                r.ROL_TIPO_ID, r.NOMBRE AS RolNombre, r.DESCRIPCION AS RolDESCRIPCION 
        ///            FROM 
        ///                USUARIO u 
        ///            INNER JOIN 
        ///                ROL_TIPO r ON u.ROL_TIPO_ID = r.ROL_TIPO_ID.
        /// </summary>
        public static string SEL_USERS_AND_ROL {
            get {
                return ResourceManager.GetString("SEL_USERS_AND_ROL", resourceCulture);
            }
        }
    }
}
