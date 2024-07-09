using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace master.DAL.Entity;

[Table("designation", Schema = "master")]
public partial class Designation
{
    [Key]
    [Column("id")]
    public long Id { get; set; }

    [Column("name")]
    [StringLength(300)]
    public string Name { get; set; } = null!;
}
