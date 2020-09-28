using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net.Http.Headers;
using System.Reflection;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace FirstHomework.Interface
{
    public class AviadorSocio : ISocio
    {
        public string wilstermanista { get; set; }
        public decimal maxConsumption { get; set; }
        private const string type = "Aviador";

        public string GetSocioType()
        {
            return $"Eres un: {type}";
        }
        public decimal calculateDiscount(decimal consumption)
        {
            return consumption * 0.07m;
        }
        public void updateMaxConsumption(decimal consumption)
        {
            maxConsumption = maxConsumption - (calculateDiscount(consumption));
        }
        public SocioInfo GetSocioInformation()
        {
            return new SocioInfo()
            {
                Name = wilstermanista,
                Edad = 20
            };
        }
    }
}
