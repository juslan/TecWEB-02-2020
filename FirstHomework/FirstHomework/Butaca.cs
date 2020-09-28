using System;
using System.Collections.Generic;
using System.Text;

namespace FirstHomework
{
    public enum Sector
    {
        Preferencia,
        General,
        Norte,
        Sur
    }
    public class Butaca
    {
        public string MemberName { get; set; }
        public int MemberAge { get; set; }
        public Sector sec { get; set; }
    }
}
