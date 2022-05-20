using System;
using System.Collections.Generic;

#nullable disable

namespace ECommerce.Models
{
    public partial class TblCategory
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public int? ParentId { get; set; }
        public int? IsDeleted { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
