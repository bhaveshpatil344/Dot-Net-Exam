using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DotNetExam.Models
{
    public class Product
    {
        [Key]
        public int ProductId { set; get; }


        [DataType(DataType.Text)]
        [Required (ErrorMessage = "Please Enter Product Name")]
        public string ProductName { set; get; }
       
        [Required(ErrorMessage = "Please Enter Product Rate")]
        public decimal Rate { set; get; }


        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Please Enter Product Decription")]
        public string Description { set; get; }


        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Please Enter Category Name")]
        public string CategoryName { set; get; }
    }
}