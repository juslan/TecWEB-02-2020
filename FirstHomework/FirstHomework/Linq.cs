using FirstHomework.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace FirstHomework.Linq
{
    public static class Tester
    {
        public static void Test()
        {
            //IEnumerable

            var testList = new List<ISocio>();
            testList.Add(new HerculesAviadorSocio
            {
                wilstermanista = "Peter",
                maxConsumption = 3000
            });

            testList.Add(new AviadorSocio
            {
                wilstermanista = "Leo",
                maxConsumption = 1500
            });

            foreach (var item in testList)
            {
                Console.WriteLine(item.GetSocioType());
            }

            var testDicionary = new Dictionary<int, ISocio>();

            testDicionary.Add(13, new AviadorSocio() { wilstermanista= "Carlos"});

            testDicionary[22] = new AviadorSocio() { wilstermanista ="Jaime" };
            testDicionary[55] = new AviadorSocio() { wilstermanista ="Jager"};

            var boolExist = testDicionary.ContainsKey(22);

            var boolNotExist = testDicionary.ContainsKey(3);


            //Linq
            var avi = PopulateAviador();
            var socios = PopulateSocio();

            //Filtering 
            var between10and50 = avi.Where(e => e.GetSocioInformation().Edad > 10 && e.GetSocioInformation().Edad < 50); //socios que tengan entre 10 y 50 años
            var old = socios.Where(e => e.Edad >= 60); //Socios de la 3 edad
            var containsA = avi.Where(e => e.wilstermanista.Contains("a"));

            //First
            var firstNameD = avi.FirstOrDefault(e => e.wilstermanista.StartsWith("D")) ?? new AviadorSocio();
            var firstNameW = avi.FirstOrDefault(e => e.wilstermanista.StartsWith("L")) ?? new AviadorSocio();
            var firstNameCons2000 = avi.Single(e => e.maxConsumption == 2000);
            //Ordering
            var orderedlistByIdAsc = avi.OrderBy(e => e.maxConsumption).ThenByDescending(e => e.wilstermanista);

            //Projection Selecting 
            var butacaProjection = avi
                .Where(e => e.wilstermanista.StartsWith("D"))
                .Select(e =>
                    new Butaca()
                    {
                        MemberName= e.wilstermanista,
                        MemberAge = e.GetSocioInformation().Edad,
                        sec = Sector.Preferencia 
                    }
                );


            var carProjectionQuery = from item in avi
                                     where item.wilstermanista.StartsWith("L")
                                     select new Butaca()
                                     {
                                         MemberName = item.wilstermanista,
                                         MemberAge = item.GetSocioInformation().Edad,
                                         sec = Sector.General
                                     };

            // anonymous class 
            // Projection Selecting 
            var playerProjectionAnonymous = avi
                .Where(e => e.wilstermanista.StartsWith("L"))
                .Select(e =>
                    new
                    {
                        Hincha = e.wilstermanista,
                        FavoritePlayer = "Pipo"
                    }
                );
            // read only
            var amount = playerProjectionAnonymous.FirstOrDefault().FavoritePlayer;

            // Grouping
            var groupedByName = avi.GroupBy(e => e.wilstermanista);

            foreach (var nameGroup in groupedByName)
            {
                Console.WriteLine($"The Key: {nameGroup.Key}");

                foreach (var aviador in nameGroup)
                {
                    Console.WriteLine($"EDAD: {aviador.GetSocioInformation().Edad}");
                }
            }

            var groupedByAge = from element in avi
                               group element by element.GetSocioInformation().Edad;


            // Joining 

            var joinedAviadorSocios = from av in avi
                                           join mem in socios on av.wilstermanista equals mem.Name
                                           select new
                                           {
                                               Name = av.wilstermanista,
                                               Age = mem.Edad,
                                               MemberYears = mem.AñosSiendoSocio,
                                               Cash = av.maxConsumption
                                           };

            foreach (var joined in joinedAviadorSocios)
            {
                Console.WriteLine($"{joined.Name} - {joined.Cash} - {joined.Age} - {joined.MemberYears} ");
            }

        }


        public static List<AviadorSocio> PopulateAviador()
        {
            var result = new List<AviadorSocio>();

            result.Add(new AviadorSocio() { maxConsumption = 1230 , wilstermanista = "Juan" });
            result.Add(new AviadorSocio() { maxConsumption = 2000, wilstermanista = "Daniel" });
            result.Add(new AviadorSocio() { maxConsumption = 900, wilstermanista = "Rolando" });
            result.Add(new AviadorSocio() { maxConsumption = 689, wilstermanista = "Jaime" });
            result.Add(new AviadorSocio() { maxConsumption = 986, wilstermanista = "Luis" });
            result.Add(new AviadorSocio() { maxConsumption = 500, wilstermanista = "Lucas" });
            result.Add(new AviadorSocio() { maxConsumption = 120, wilstermanista = "Pedro" });
            return result;
        }

        public static List<SocioInfo> PopulateSocio()
        {
            var result = new List<SocioInfo>();

            result.Add(new SocioInfo() { Name="Kevin", AñosSiendoSocio = 13, Edad = 40});
            result.Add(new SocioInfo() { Name = "Jorge", AñosSiendoSocio = 11, Edad = 40 });
            result.Add(new SocioInfo() { Name = "Veronica", AñosSiendoSocio = 1, Edad = 15 });
            result.Add(new SocioInfo() { Name = "Javier", AñosSiendoSocio = 13, Edad = 41 });
            result.Add(new SocioInfo() { Name = "Tomas", AñosSiendoSocio = 5, Edad = 26 });
            result.Add(new SocioInfo() { Name = "Pedro", AñosSiendoSocio = 14, Edad = 45 });
            result.Add(new SocioInfo() { Name = "Jaime", AñosSiendoSocio = 20, Edad = 55 });
            result.Add(new SocioInfo() { Name = "Marcelo", AñosSiendoSocio = 15, Edad = 31 });
            result.Add(new SocioInfo() { Name = "Juan", AñosSiendoSocio = 40, Edad = 80 });

            return result;
        }



    }
}
