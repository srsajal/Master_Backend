using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace master.DAL.Entity;

[Table("major_head", Schema = "master")]
[Index("Code", Name = "UK_major_head", IsUnique = true)]
public partial class MajorHead
{
    [Key]
    [Column("id")]
    public short Id { get; set; }

    [Column("code")]
    [StringLength(4)]
    public string Code { get; set; } = null!;

    [Column("name")]
    [StringLength(150)]
    public string Name { get; set; } = null!;

    public virtual ICollection<DemandMajorMapping> DemandMajorMappings { get; set; } = new List<DemandMajorMapping>();

    [InverseProperty("MajorHead")]
    public virtual ICollection<SubMajorHead> SubMajorHeads { get; set; } = new List<SubMajorHead>();
}
