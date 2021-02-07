using CotacaoMoeda.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace CotacaoMoeda.Domain.Interfaces.Model
{
    public interface IMoeda
    {
        public List<Moeda> GetMoedas();

        public string AddMoedas();
    }
}
