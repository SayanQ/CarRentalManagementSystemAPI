﻿using System.ComponentModel.DataAnnotations;

namespace CarRentalManagementSystemAPI.Models
{
    public class UserAuth
    {
        [Key]
        public int Id { get; set; }
        public string EmailId { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }

    }
}
