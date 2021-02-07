using CotacaoMoeda.Domain.Interfaces.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace CotacaoMoeda.Domain.DTO.Response
{
    public class MoedaResponse : IResponse
    {
        public string moeda { get; set; }
        public string data_inicio { get; set; }
        public string data_fim { get; set; }
    }

}
