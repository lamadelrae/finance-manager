﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FinanceManager.Domain.Database.Months.Bills
{
    public class Bills
    {
        [Key]
        public int Id { get; set; }

        public int User_Id { get; set; }

        public string Description { get; set; }

        public decimal Value { get; set; }

        public string Status { get; set; }
    }
}