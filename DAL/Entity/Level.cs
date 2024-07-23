using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace master.DAL.Entity;

[Table("level", Schema = "master")]
public partial class Level
{
    [Key]
    [Column("id")]
    public short Id { get; set; }

    [Column("name", TypeName = "character varying")]
    public string? Name { get; set; }

    [Column("code")]
    public short? Code { get; set; }

    [Column("is_active")]
    public bool? IsActive { get; set; }
}
