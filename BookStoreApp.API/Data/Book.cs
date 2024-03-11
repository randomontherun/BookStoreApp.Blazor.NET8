using BookStoreApp.API.Models;
using System;
using System.Collections.Generic;

namespace BookStoreApp.API.Data;

public partial class Book : BaseDto
{
    public string Title { get; set; } = null!;

    public int? Year { get; set; }

    public string Isbn { get; set; } = null!;

    public string Summary { get; set; } = null!;

    public string Image { get; set; } = null!;

    public decimal? Price { get; set; }

    public int? AuthorId { get; set; }

    public virtual Author? Author { get; set; }
}
