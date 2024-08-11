using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IngresoGastos.Models
{

    public class IngresoGastostatis
    {
        //Este porgrama va grabar datos de una descripcion del ingreso y gastos un tipo si es ingreso o gastos, por tanto se necesitatres variables 
        //y un id con su tipo requerido y si es una llave primaria


        [Key] //este indica que es la llave primaria
        public int Id { get; set; }
        [Required]
        [StringLength(60, MinimumLength = 3)]

        public string   Descripcion { get; set; }

        [Required]
        [Display(Name="Tipo")]
        public  bool EsIngreso { get; set; }
        [Required]

        public double Valor { get; set; }

        

    }
}