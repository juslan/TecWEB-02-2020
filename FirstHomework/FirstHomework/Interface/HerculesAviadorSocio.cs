using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace FirstHomework.Interface
{
    public class HerculesAviadorSocio : ISocio
    {
        public string wilstermanista { get; set; }
        public decimal maxConsumption { get; set; }
        private const string type = "Hercules Aviador";
        public string GetSocioType()
        {
            return $"Eres un: {type}";
        }
        public decimal calculateDiscount(decimal consumption)
        {
            decimal discount;
            if (consumption > 800)
            {
                discount = 0.20m;
            }
            else
            {
                discount = 0.13m;
            }

            return discount * consumption;   
        }
        public void updateMaxConsumption(decimal consumption)
        {
            maxConsumption = maxConsumption - (calculateDiscount(consumption));
        }
        public SocioInfo GetSocioInformation()
        {
            var soc = new SocioInfo()
            {
                Name = wilstermanista,
                Edad = 30,
                AñosSiendoSocio = 10
            };
            soc.ShowMemberYears();
            return soc;
        }
    }
}
