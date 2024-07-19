using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace master.DAL.Entity;

[Table("ddo", Schema = "master")]
public partial class Ddo
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("treasury_code")]
    [StringLength(3)]
    public string TreasuryCode { get; set; } = null!;

    [Column("treasury_mst_id")]
    public short? TreasuryMstId { get; set; }

    [Column("code")]
    [StringLength(9)]
    public string Code { get; set; } = null!;

    [Column("designation")]
    [StringLength(100)]
    public string Designation { get; set; } = null!;

    [Column("designation_mst_id")]
    public int? DesignationMstId { get; set; }

    [Column("address")]
    [StringLength(500)]
    public string? Address { get; set; }

    [Column("phone")]
    [StringLength(20)]
    public string? Phone { get; set; }

    [Column("is_active")]
    public bool? IsActive { get; set; }
}
