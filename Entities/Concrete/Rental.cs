using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Rental:IEntity
    {
        public int Id { get; set; }
        public int CarId { get; set; }
        public int CustomerId { get; set; }
        public DateTime RentDate { 
            get { return RentDate = RentDate; } 
            set {
                RentDate = RentDate.Date;
            }
        }
        public DateTime? ReturnDate { get; set; }

    }
}
