using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BigCalculation.Models
{
    public class Entity
    {
        public string Id { get; set; }
        public DateTime? CreateTime { get; set; }
        public DateTime? LastModifiedTime { get; set; }
        public Boolean IsDeleted { get; set; }
        public string CreatedBy { get; set; }
        public string LastModifiedBy { get; set; }
        protected Entity()
        {
            Id = Guid.NewGuid().ToString("N");
            IsDeleted = false;
        }
    }
}