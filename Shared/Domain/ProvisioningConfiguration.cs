using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RemoteCarDiagz.Shared.Domain
{
    [Table("Configuration")]
    public class ProvisioningConfiguration
    {
        [Key]
        public Guid Id { get; set; }
        public string PublicDashboardUid { get; set; }
    }
}
