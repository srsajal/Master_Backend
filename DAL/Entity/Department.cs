using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace master.DAL.Entity;

[Table("department", Schema = "master")]
[Index("DemandCode", Name = "UK_demand_code", IsUnique = true)]
public partial class Department
{
    [Key]
    [Column("id")]
    public short Id { get; set; }

    [Column("code")]
    [StringLength(2)]
    public string Code { get; set; } = null!;

    [Column("name")]
    [StringLength(100)]
    public string Name { get; set; } = null!;

    [Column("demand_code")]
    [StringLength(2)]
    public string DemandCode { get; set; } = null!;

    [Column("address", TypeName = "character varying")]
    public string? Address { get; set; }

    [Column("pin_code")]
    [StringLength(6)]
    public string? PinCode { get; set; }

    [Column("phone_number")]
    [StringLength(20)]
    public string? PhoneNumber { get; set; }

    [Column("mobile_number")]
    [StringLength(10)]
    public string? MobileNumber { get; set; }

    [Column("email")]
    [StringLength(100)]
    public string? Email { get; set; }

    [Column("is_active")]
    public bool? IsActive { get; set; }

    public virtual ICollection<DemandMajorMapping> DemandMajorMappings { get; set; } = new List<DemandMajorMapping>();

    public virtual ICollection<SchemeHead> SchemeHeads { get; set; } = new List<SchemeHead>();
}
