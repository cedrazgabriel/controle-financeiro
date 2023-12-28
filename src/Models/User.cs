using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace controle_financeiro.Models;
using System.ComponentModel.DataAnnotations.Schema;

[Table("users")]
public class User
{
   [Column("id")]
   public int Id { get; set; }
   
   [Column("name")]
   public string Name { get; set; }
   
   [Column("email")]
   public string Email { get; set; }
   
   [Column("password")]
   public string Password { get; set; }
}