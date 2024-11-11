using System;
using System.Collections.Generic;

namespace JFApi2.Data.Models;

public partial class Promo
{
    public int PromoId { get; set; }

    public string? Description { get; set; }

    public DateTime? FechaPromo { get; set; }

    public int BurguerId { get; set; }

    public virtual Burguer Burguer { get; set; } = null!;
}
