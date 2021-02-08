using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CotacaoMoeda.Domain.DTO.Request;
using CotacaoMoeda.Domain.DTO.Response;
using CotacaoMoeda.Domain.Interfaces.Service;
using Microsoft.AspNetCore.Mvc;

namespace CotacaoMoeda.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CotacaoMoedaController : Controller
    {
        private readonly IMoedaService _moedaService;

        public CotacaoMoedaController(IMoedaService moedaService)
        {
            _moedaService = moedaService;
        }

        [HttpPost]
        public async Task<JsonResult> AddItemFila(List<MoedaRequest> request)
        {
            try
            {
                request.Reverse();
                var response = await _moedaService.AddMoedaAsync(request);
                return Json(response);
            }
            catch (Exception ex)
            {

                return Json(ex.Message);
            }
        }

        [HttpGet]
        public async Task<JsonResult> GetItemFila()
        {
            try
            {
                var Response = await _moedaService.GetMoedaAsync();

                if (Response.Count > 0)
                {
                    return Json(Response);
                }
                return Json("Nao ha Objetos na Fila");
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
