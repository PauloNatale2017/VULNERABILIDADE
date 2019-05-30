using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEKRA.VULNERABILIDADE.DOMAIN.ENTIITES.BASEENTITY
{
    public class BaseEntity
    {

        private DateTime timeNow = DateTime.Now;

        public BaseEntity()
        {
        }

        [Key]
        public int Id { get; set; }
        public DateTime DataCreate {
            get { return timeNow; }
            set { timeNow = value; }
        }
        public DateTime DataUpdate {
            get { return timeNow; }
            set { timeNow = value; }
        }   
    }
}
