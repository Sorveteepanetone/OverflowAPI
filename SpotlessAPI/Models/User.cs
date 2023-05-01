using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SpotlessAPI.Models;

public partial class User
{
    [Key]
    public int Id { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public string UserName { get; set; } = null!;

    [StringLength(255)]
    [Unicode(false)]
    public string Email { get; set; } = null!;

    public int Password { get; set; }

    [InverseProperty("User")]
    public virtual ICollection<UserAdress> UserAdresses { get; set; } = new List<UserAdress>();
}
