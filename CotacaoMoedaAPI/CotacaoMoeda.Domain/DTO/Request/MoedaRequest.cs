using CotacaoMoeda.Domain.Interfaces.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace CotacaoMoeda.Domain.DTO.Request
{
    public class MoedaRequest : IRequest
    {
        public string moeda { get; set; }
        public string data_inicio { get; set; }
        public string data_fim { get; set; }
    }
}
