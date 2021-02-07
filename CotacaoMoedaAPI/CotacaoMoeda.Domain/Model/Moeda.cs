using CotacaoMoeda.Domain.Interfaces.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CotacaoMoeda.Domain.Model
{
    public class Moeda : IMoeda
    {
        public string moeda { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}")]
        public DateTime data_inicio { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}")]
        public DateTime data_fim { get; set; }

        public List<Moeda> GetMoedas()
        {
            return null;
        }
        public string AddMoedas()
        {
            return "";
        }
    }
}
