using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RemoteCarDiagz.Shared.Domain
{
    [Table("Measurements")]
    public class Measurement
    {
        [Key]
        public PidIdsEnum Value { get; set; }
        public bool IsActive { get; set; }
        public bool IsAvailable  { get; set; }
    }
}