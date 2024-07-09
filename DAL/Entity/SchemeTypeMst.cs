using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace master.DAL.Entity;

[Table("scheme_type_mst", Schema = "master")]
public partial class SchemeTypeMst
{
    [Key]
    [Column("id")]
    public long Id { get; set; }

    [Column("type")]
    [StringLength(2)]
    public string Type { get; set; } = null!;

    [Column("description", TypeName = "character varying")]
    public string? Description { get; set; }
}
