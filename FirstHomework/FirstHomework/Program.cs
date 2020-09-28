using System;
using System.Net;
using FirstHomework.Interface;

namespace FirstHomework
{
    class Program
    {
        static void Main(string[] args)
        {
            //INTERFACE
            
            decimal consumption = 500;
            SocioFactory.type = SocioType.Aviador;
            ISocio AvSocio = SocioFactory.Create();
            AvSocio.wilstermanista = "Juan";
            AvSocio.maxConsumption = 1500;
            PayBeingSocio(AvSocio, consumption);
            Console.WriteLine($"-------------");
            Action<ISocio, decimal> payAction = PayBeingSocio; //delegate
            consumption = 1500;
            SocioFactory.type = SocioType.HerculesAviador;
            ISocio HercAvSocio = SocioFactory.Create();
            HercAvSocio.wilstermanista = "Juslan";
            HercAvSocio.maxConsumption = 3000;
            payAction(HercAvSocio, consumption);


            //LINQ
            //Console.WriteLine($"LINQ");
            //FirstHomework.Linq.Tester.Test(); 

            //GENERICS (QUEUE)
            //Console.WriteLine($"QUEUE");
            //FirstHomework.Generics.Tester.Test();

        }
        public static void PayBeingSocio(ISocio socio, decimal consum)
        {
            Console.WriteLine($"{socio.GetSocioType()}");
            var wilstermanistaInfo = socio.GetSocioInformation();
            var gho = socio.maxConsumption;
            Console.WriteLine($"Datos del Socio: {wilstermanistaInfo.Name} \n Edad:{wilstermanistaInfo.Edad} \n Años de Socio:{wilstermanistaInfo.AñosSiendoSocio}");
            var discount = socio.calculateDiscount(consum);
            Func<decimal, decimal, decimal> totalPay = (cons, dis) => cons-dis;//LAMBDA
            var totalToPay = totalPay(consum, discount);
            if(totalToPay > socio.maxConsumption)
            {
                Console.WriteLine("No cuenta con abono suficiento");
            }
            else
            {
                Console.WriteLine($"Su comsumo es de: {consum}, su descuento es {discount}. Se le descontara {totalToPay} de su cuenta de socio");
                socio.updateMaxConsumption(consum);
            }
        }
    }
}
