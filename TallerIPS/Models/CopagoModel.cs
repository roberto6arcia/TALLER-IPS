using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebIPS.Models
{
    
    public class CopagoInputModel
    {
        public string Identificacion { get; set; }
        public decimal ValorHospitalizacion { get; set; }
        public decimal Salario { get; set; }
        
    }
    
    public class CopagoViewModel : CopagoInputModel
    {
        public CopagoViewModel()
        {

        }
        public CopagoViewModel(Copago copago)
        {
            Identificacion = copago.Identificacion;
            ValorHospitalizacion = copago.ValorHospitalizacion;
            Salario = copago.Salario;
            ValorCopago = copago.ValorCopago;
            
        }
        public decimal ValorCopago { get; set; }
    }

}