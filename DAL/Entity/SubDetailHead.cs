using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace master.DAL.Entity;

[Table("sub_detail_head", Schema = "master")]
public partial class SubDetailHead
{
    [Key]
    [Column("id")]
    public short Id { get; set; }

    [Column("code")]
    [StringLength(2)]
    public string Code { get; set; } = null!;

    [Column("name")]
    [StringLength(100)]
    public string? Name { get; set; }

    [Column("detail_head_id")]
    public short? DetailHeadId { get; set; }

    [Column("is_active")]
    public bool? IsActive { get; set; }

    [ForeignKey("DetailHeadId")]
    [InverseProperty("SubDetailHeads")]
    public virtual DetailHead? DetailHead { get; set; }
}
