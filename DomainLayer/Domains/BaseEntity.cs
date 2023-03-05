using LinqToDB.Mapping;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Domains
{
    public class BaseEntity
    {
        [PrimaryKey,Identity]
        public int Id { get; set; }
    }
}
