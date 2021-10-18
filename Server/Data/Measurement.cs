using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using RemoteCarDiagz.Shared.Domain;

namespace RemoteCarDiagz.Server.Data
{
    [Table("Measurements")]
    public class Measurement
    {
        [Key]
        public PidIdsEnum Value {get; set;}
        public bool IsActive { get; set; } 
    }
}