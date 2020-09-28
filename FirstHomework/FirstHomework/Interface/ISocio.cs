using System;
using System.Collections.Generic;
using System.Text;

namespace FirstHomework.Interface
{
    public interface ISocio
    {
        string wilstermanista { get; set; }
        decimal maxConsumption{ get; set; }

        string GetSocioType();
        SocioInfo GetSocioInformation();
        decimal calculateDiscount(decimal consumption);
        void updateMaxConsumption(decimal consumption);
    }
}
