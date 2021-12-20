using Microsoft.AspNetCore.Mvc;
using MyNeighborhood.Models;
using System;
using System.Collections.Generic;
using System.Linq;

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
        public NeighborhoodResponse Get(NeighborhoodRequest neighborhoodRequest)
        {
            int dias;
            List<int> lstCasasInicial = neighborhoodRequest.lstCasas;

            for (dias = 0; dias < neighborhoodRequest.dias; dias++)
            {
                lstCasasInicial = CompareHouses(lstCasasInicial);
            }

            return new NeighborhoodResponse {
                dias = neighborhoodRequest.dias,
                entrada = neighborhoodRequest.lstCasas,
                salida = lstCasasInicial
            };
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
