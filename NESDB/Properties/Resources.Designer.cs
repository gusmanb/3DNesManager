﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace NESDB.Properties {
    using System;
    
    
    /// <summary>
    ///   Clase de recurso fuertemente tipado, para buscar cadenas traducidas, etc.
    /// </summary>
    // StronglyTypedResourceBuilder generó automáticamente esta clase
    // a través de una herramienta como ResGen o Visual Studio.
    // Para agregar o quitar un miembro, edite el archivo .ResX y, a continuación, vuelva a ejecutar ResGen
    // con la opción /str o recompile su proyecto de VS.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "15.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   Devuelve la instancia de ResourceManager almacenada en caché utilizada por esta clase.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("NESDB.Properties.Resources", typeof(Resources).Assembly);
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
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a &lt;?xml version=&quot;1.0&quot; encoding=&quot;utf-16&quot;?&gt;
        ///&lt;database version=&quot;1.0&quot; conformance=&quot;strict&quot; agent=&quot;NesCartDB&quot; author=&quot;BootGod&quot; timestamp=&quot;Mon Aug 21 23:55:50 2017
        ///&quot;&gt;
        ///	&lt;game name=&quot;&amp;apos;89 Dennou Kyuusei Uranai&quot; altname=&quot;神宮館’８９電脳九星占い&quot; class=&quot;Licensed&quot; catalog=&quot;IPC-J1-01&quot; publisher=&quot;Jingukan&quot; developer=&quot;Micronics / Khaos&quot; region=&quot;Japan&quot; players=&quot;1&quot; date=&quot;1988-12-10&quot;&gt;
        ///		&lt;cartridge system=&quot;Famicom&quot; crc=&quot;BA58ED29&quot; sha1=&quot;56FE858D1035DCE4B68520F457A0858BAE7BB16D&quot; dump=&quot;ok&quot; dumper=&quot;bootgod&quot; datedumped=&quot;2007-11-11&quot;&gt;
        ///			&lt;bo [resto de la cadena truncado]&quot;;.
        /// </summary>
        internal static string roms {
            get {
                return ResourceManager.GetString("roms", resourceCulture);
            }
        }
    }
}
