﻿using System;

namespace JobApplication.Model
{
    public class Industry
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public DateTime? CreatedDate { get; set; }

    }
}