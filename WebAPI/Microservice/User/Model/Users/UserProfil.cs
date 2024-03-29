﻿using System;
using System.Text.Json.Serialization;
using User.Model.ViewModel;

namespace User.Model.Users
{
    public enum UserRole
    {
        ADMIN, USER
    }

    public class UserProfil
    {
        [JsonPropertyName("firstName")]
        public string FirstName { get; set; }
        [JsonPropertyName("lastName")]
        public string LastName { get; set; }
        [JsonPropertyName("birthdayDate")]
        public DateTime BirthdayDate { get; set; }
        [JsonPropertyName("role")]
        public UserRole Role { get; set; }

        public ProfilView ToProfilView()
        {
            return new ProfilView
            {
                FirstName = this.FirstName,
                LastName = this.LastName,
                BirthdayDate = this.BirthdayDate,
                Role = this.Role
            };
        }
    }

}
