using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ModelsLib
{
    public class MainModel : InterfacesLib.IMainModel
    {
        public int Code { get; set; }
        public string Value { get; set; }
    }
}
