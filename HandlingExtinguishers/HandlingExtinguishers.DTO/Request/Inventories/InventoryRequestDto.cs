﻿using System;

namespace HandlingExtinguishers.DTO.Request.Inventories
{
    public class InventoryRequestDto 
    {
        public Guid? ProductId { get; set; }
        public Guid? ExtinguisherTypeId { get; set; }
        public Guid? ExtinguisherWeightId { get; set; }
        public DateTime? Date { get; set; }
        public string? Description { get; set; }
        public int? Amount { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public bool? Active { get; set; }
    }
}
