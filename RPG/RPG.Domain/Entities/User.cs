using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RPG.Domain.Entities
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }

        public List<Character> Character { get; set; }
    }
}
