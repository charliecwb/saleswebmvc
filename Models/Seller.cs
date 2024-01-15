using System.ComponentModel.DataAnnotations;

namespace SalesWebMvc.Models
{
    public class Seller
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "{0} required")]
        [StringLength(60, MinimumLength = 3)]
        public string Name { get; set; }

        [EmailAddress]
        [Required(ErrorMessage = "{0} required")]
        public string Email { get; set; }
        
        [Display(Name = "Bith Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime BirthDate { get; set; }
        
        [DisplayFormat(DataFormatString = "{0:F2}")]
        [Required(ErrorMessage = "{0} required")]
        public double Salary { get; set; }
        public Department Department { get; set; }
        public int DepartmentId { get; set; }
        public ICollection<SalesRecord> Sales { get; set; } = new List<SalesRecord>();

        public Seller(){}

        public Seller(int id, string name, string email, DateTime bday, double salary, Department department) 
        {
            Id = id;
            Name = name;
            Email = email;
            BirthDate = bday;
            Salary = salary;
            Department = department;
        }

        public void AddSales(SalesRecord sr) {
            Sales.Add(sr);
        }

        public void RemoveSales(SalesRecord sr){
            Sales.Remove(sr);
        }
        
        public double TotalSales(DateTime initial, DateTime final) {
            return Sales.Where(sr => sr.Date >= initial && sr.Date <= final).Sum(sr => sr.Amount);
        }
    }
}