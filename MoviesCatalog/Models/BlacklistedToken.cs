using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace MoviesCatalog.Models
{
    public class BlacklistedToken
    {
        public int Id { get; set; }
        public string Value { get; set; }
    }
}
