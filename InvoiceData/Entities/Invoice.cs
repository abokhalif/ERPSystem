using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceData.Entities
{

        public class Invoice
        {
            public int Id { get; set; }
            public Client Client { get; set; }
            public ICollection<InvoiceDetails> InvoiceDetails { get; set; } = new List<InvoiceDetails>().ToList();

            // Total is calculated dynamically whenever it's accessed
            public decimal Total => InvoiceDetails.Sum(detail => detail.Total);
        }
    }

