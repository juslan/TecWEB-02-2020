using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace FirstHomework.Interface
{
    static class Extensions
    {
        public static void ShowMemberYears(this SocioInfo socioInfo)
        {
            Console.WriteLine($"El Socio {socioInfo.Name} lleva {socioInfo.AñosSiendoSocio} con el club Wilsterman");
        }
    }
}
