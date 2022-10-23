using System;
using System.ComponentModel.DataAnnotations;

namespace TestForMac.Models;

public class Category
{
	[Key]
	public int Id { get; set; }
	[Required]
	public string Name { get; set; }
	public int DisplayDateTime { get; set; }
	public DateTime CreatedDateTime { get; set; } = DateTime.Now;
}

