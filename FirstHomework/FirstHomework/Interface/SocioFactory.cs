using System;
using System.Collections.Generic;
using System.Text;

namespace FirstHomework.Interface
{
    public enum SocioType
    {
        HerculesAviador,
        Aviador
    }
    public static class SocioFactory
    {
        public static SocioType type;
        public static ISocio Create()
        {
            switch (type)
            {
                case SocioType.HerculesAviador:
                    return new HerculesAviadorSocio();
                case SocioType.Aviador:
                    return new AviadorSocio();
                default:
                    return null;
            }
        }
    }
}
