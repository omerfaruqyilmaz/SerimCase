﻿namespace SerimCase.Entities.Concrete
{

    public class BaseEntity
    {
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool IsStatus { get; set; }
    }
}
