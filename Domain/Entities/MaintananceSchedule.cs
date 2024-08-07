﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class MaintananceSchedule
    {
        public MaintananceSchedule()
        {
            Bookings = new HashSet<Booking>();
            ServiceCares = new HashSet<ServiceCares>();
        }

        [Key]
        public Guid MaintananceScheduleId { get; set; }
        public int MaintananceScheduleName { get; set; }
        public string Description { get; set; }
        public DateTime CreateDate { get; set; }
        public Guid VehicleModelId { get; set; }
        public VehicleModel VehicleModel { get; set; }
        public ICollection<Booking> Bookings { get; set; }
        public ICollection<ServiceCares> ServiceCares { get; set; }
    }
}
