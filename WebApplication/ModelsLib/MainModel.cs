using System.ComponentModel.DataAnnotations;

namespace ModelsLib
{
    public class MainModel : InterfacesLib.IMainModel
    {
        [Required]
        public int Code { get; set; }
        [Required]
        public string Value { get; set; }
    }
}
