using InterfacesLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ModelsLib
{
    public class DatabaseMainModel : MainModel, InterfacesLib.IDatabaseMainModel
    {
        public long Id { get; }
        //public Int32 Code { get; set; }
        //public string Value { get; set; }

        public DatabaseMainModel(long id, int code, string value)
        {
            Id = id;
            Code = code;
            Value = value;
        }
    }
}
