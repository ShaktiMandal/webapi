using System;
using System.ComponentModel.DataAnnotations;

namespace bankingManagementApi.Model
{
    public record CreateItem {

        [Required]
        public string Name{get; init;}
        [Required]
        [MinLength(10)]
        [MaxLength(10)]
        public string PhoneNumber{get; init;}
        public string Address{get; init;}
    }
}
