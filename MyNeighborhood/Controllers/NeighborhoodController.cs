using MyNeighborhood.Models;

using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace MyNeighborhood.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NeighborhoodController : ControllerBase
    {
        public NeighborhoodController()
        {
        }

        [HttpGet]
        public IActionResult Get(NeighborhoodRequest neighborhoodRequest)
        {
            int dias;

            if (neighborhoodRequest.dias <= 0 || neighborhoodRequest.lstCasas == null)
            {
                return BadRequest("El día y la lista de casas son requeridos.");
            }

            List<int> lstCasasInicial = neighborhoodRequest.lstCasas;

            for (dias = 0; dias < neighborhoodRequest.dias; dias++)
            {
                lstCasasInicial = CompareHouses(lstCasasInicial);
            }

            NeighborhoodResponse neighborhoodResponse = new NeighborhoodResponse
            {
                dias = neighborhoodRequest.dias,
                entrada = neighborhoodRequest.lstCasas,
                salida = lstCasasInicial
            };

            return Ok(neighborhoodResponse);
        }

        private List<int> CompareHouses(List<int> lstCasasInicial)
        {
            List<int> lstCasasFinal = new List<int>();
            int inicio;
            int fin;
            int nuevoValor;

            for (int i = 0; i <= (lstCasasInicial.Count - 1); i++)
            {
                if (i == 0)
                {
                    inicio = 0;
                }
                else
                {
                    inicio = lstCasasInicial[i - 1];
                }

                if (i == (lstCasasInicial.Count - 1))
                {
                    fin = 0;
                }
                else
                {
                    fin = lstCasasInicial[i + 1];
                }

                if ((inicio == 0 && fin == 0) || (inicio == 1 && fin == 1))
                {
                    nuevoValor = 0;
                }
                else
                {
                    nuevoValor = 1;
                }

                lstCasasFinal.Add(nuevoValor);
            }

            return lstCasasFinal;
        }
    }
}
