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
    [Route("[controller]")]
    public class CotacaoMoedaController : Controller
    {
        private readonly IMoedaService _moedaService;

        public CotacaoMoedaController(IMoedaService moedaService)
        {
            _moedaService = moedaService;
        }

        [HttpPost]
        public JsonResult AddItemFila(List<MoedaRequest> request)
        {
            string Response = _moedaService.AddMoeda(request);
            return Json(Response);
        }

        [HttpGet]
        public JsonResult GetItemFila()
        {
            List<MoedaResponse> Response = _moedaService.GetMoeda();

            return Json(Response);
        }
    }
}
