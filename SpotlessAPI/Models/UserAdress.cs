using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SpotlessAPI.Models;

[Table("UserAdress")]
public partial class UserAdress
{
    [Key]
    public int Id { get; set; }

    public int UserId { get; set; }

    public int AdressId { get; set; }

    [ForeignKey("AdressId")]
    [InverseProperty("UserAdresses")]
    public virtual Address Adress { get; set; } = null!;

    [ForeignKey("UserId")]
    [InverseProperty("UserAdresses")]
    public virtual User User { get; set; } = null!;
}
