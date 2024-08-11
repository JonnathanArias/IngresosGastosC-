using IngresoGastos.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace IngresoGastos.Data
{
    public class AppDBContext : DbContext //aqui nos va generar error si nos sale solo le damso sobre el error y importar el entity
    {
        public AppDBContext() : base("DefaultConnection") //agregamos el constructor ctor doble TAB y luego traemos la conexion desde Web.config que agregamos alli 
        {
                
        }

        //llamamos nuestro primer modelo  realizada en IngresogastosTatis

        public DbSet<IngresoGastostatis> ingresosGastos { get; set; }
    }
}