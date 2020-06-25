using System.ComponentModel.DataAnnotations.Schema;

namespace SimpleWarehouse.Model
{
    [Table("expenses")]
    public class Expense : RevenueStream
    {
    }
}