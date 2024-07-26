using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace master.DAL.Entity;

[Table("treasury", Schema = "master")]
public partial class Treasury
{
    [Key]
    [Column("id")]
    public short Id { get; set; }

    [Column("district_name")]
    [StringLength(30)]
    public string DistrictName { get; set; } = null!;

    [Column("district_code")]
    public short? DistrictCode { get; set; }

    [Column("code")]
    [StringLength(3)]
    public string Code { get; set; } = null!;

    [Column("name")]
    [StringLength(100)]
    public string Name { get; set; } = null!;

    [Column("is_active")]
    public bool? IsActive { get; set; }
}
