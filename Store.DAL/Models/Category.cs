using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Store.DAL.Models;

public partial class Category : BaseModel
{
    public string? CategoryName { get; set; }
}
