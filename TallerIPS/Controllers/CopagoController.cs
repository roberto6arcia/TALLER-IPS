using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entity;
using Logica;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using WebIPS.Models;

namespace WebIPS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class CopagoController: ControllerBase

    {
        private readonly CopagoService _copagoService;
        public IConfiguration Configuration { get; }
        public CopagoController(IConfiguration configuration)
        {
            Configuration = configuration;
            string connectionString = Configuration["ConnectionStrings:DefaultConnection"];
            _copagoService = new CopagoService(connectionString);
        }
        // GET: api/Copago
        [HttpGet]
        public IEnumerable<CopagoViewModel> Gets()
        {
            var copagos = _copagoService.ConsultarTodos().Select(p=> new CopagoViewModel(p));
            return copagos;
        }

     

        // POST: api/Copago
        [HttpPost]
        public ActionResult<CopagoViewModel> Post(CopagoInputModel copagoInput)
        {
            Copago copago = MapearCopago(copagoInput);
            var response = _copagoService.Guardar(copago);
            if (response.Error) 
            {
                return BadRequest(response.Mensaje);
            }
            return Ok(response.Copago);
        }
      

        private Copago MapearCopago(CopagoInputModel copagoInput)
{
            var copago = new Copago
            {
                Identificacion = copagoInput.Identificacion,
                ValorHospitalizacion = copagoInput.ValorHospitalizacion,
                Salario = copagoInput.Salario,
                
            };
            return copago;
}



    }
}