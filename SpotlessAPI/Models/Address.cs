using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SpotlessAPI.Models;

[Table("Address")]
public partial class Address
{
    [Key]
    public int Id { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public string State { get; set; } = null!;

    [StringLength(255)]
    [Unicode(false)]
    public string Country { get; set; } = null!;

    [StringLength(255)]
    [Unicode(false)]
    public string City { get; set; } = null!;

    [StringLength(255)]
    [Unicode(false)]
    public string PostalCode { get; set; } = null!;

    [StringLength(255)]
    [Unicode(false)]
    public string Street { get; set; } = null!;

    public int HouseNumber { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public string AdditionalObservation { get; set; } = null!;

    [InverseProperty("Adress")]
    public virtual ICollection<UserAdress> UserAdresses { get; set; } = new List<UserAdress>();
}
