﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ETickets.Domain
{
    public class BaseEntity
    {
        [Key]
        public Guid Id { get; set; }
    }
}

