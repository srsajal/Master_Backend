using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace master.DAL.Entity;

[Table("sub_scheme_type", Schema = "master")]
public partial class SubSchemeType
{
    [Key]
    [Column("id")]
    public long Id { get; set; }

    [Column("type", TypeName = "char")]
    public char Type { get; set; }

    [Column("description", TypeName = "character varying")]
    public string? Description { get; set; }

    [Column("is_active")]
    public bool? IsActive { get; set; }
}
