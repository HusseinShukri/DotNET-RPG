﻿using RPG.Domain.Models;
using System.Collections.Generic;

namespace RPG.Data.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public List<Character> Characters { get; set; }
    }
}
