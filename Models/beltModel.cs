using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;

namespace belt.Models
{
    public class User
    {
        [Key]
        public int UserId {get; set;}


        [Display(Name="First Name:")]
        [MinLength(4,ErrorMessage="Dude your FirstName is longer than 4 characters....commmon!")]
        [Required(ErrorMessage="FirstName is a must Yo!!!")]
        public string FirstName{get;set;}


        [Display(Name="Last Name:")]
        [MinLength(4,ErrorMessage="Dude your LastName is longer than 4 characters....commmon!")]
        [Required(ErrorMessage="LastName is a must Yo!!!")]
        public string LastName{get;set;}


        [Display(Name="Email:")]
        [EmailAddress(ErrorMessage="Use the proper email format yo! It is 2019 for godsake!!!")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail is not valid")]
        [Required(ErrorMessage="Email is a must sorry :(")]
        public string Email{get;set;}


        [Display(Name="Password:")]
        [MinLength(8,ErrorMessage="Password needs to be more than 8 characters please")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage="Of course password is required?")]
        public string Password{get;set;}


        [NotMapped]
        [Display(Name="Confirm Password:")]
        [Compare(nameof(Password), ErrorMessage="Password don't match.")]
        [Required(ErrorMessage="Password Confirmation is required please!")]
        public string RePassword{get;set;}

        public DateTime CreatedAt{get;set;}=DateTime.Now;
        public DateTime UpdatedAt{get;set;}=DateTime.Now;

    }

    public class Login
    {
        [Display(Name="Email:")]
        [EmailAddress(ErrorMessage="Use the proper email format yo! It is 2019 for godsake!!!")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail is not valid")]
        [Required(ErrorMessage="Email is a must sorry :(")]
        public string Email{get;set;}

        [Display(Name="Password:")]
        [Required(ErrorMessage="Of course password is required?")]
        public string Password{get;set;}
    }   
    
     public class IndexViewModel
    {
        public Login NewLogin {get;set;}
        public User NewUser {get;set;}
    }

    public class Customer
    {
        [Key]
        public int CustomerId{get;set;}
        [Required]
        public string Name{get;set;}
        public DateTime CreatedAt{get;set;}=DateTime.Now;
        public DateTime UpdatedAt{get;set;}=DateTime.Now;
        public List<Order> PurchasedProd {get;set;}

    }


    public class Product
    {
        [Key]
        public int ProductId{get;set;}
        [Required]
        public string Name{get;set;}
        public string ImgUrl{get;set;}
        public string Description{get;set;}
        [Required(ErrorMessage="Initial Quantiny value is Required!!")]
        [Range(0,100)]
        public int? Inventory{get;set;}
        public DateTime CreatedAt{get;set;}=DateTime.Now;
        public DateTime UpdatedAt{get;set;}=DateTime.Now;
        public List<Order> PurchasedBy {get;set;}
    }

    public class Order
    {
        [Key]
        public int OrderId {get;set;}
        [Required]
        public int CustomerId{get;set;}
        public Customer Customer{get;set;}
        [Required]
        public int ProductId{get;set;}
        public Product Product{get;set;}
        [Required]
        public int Quantity{get;set;}
        public DateTime CreatedAt{get;set;}=DateTime.Now;
        public DateTime UpdatedAt{get;set;}=DateTime.Now;

    }

}