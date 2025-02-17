﻿namespace SignalR.EntityLayer
{
    public class Category
    {
        public int CategoryID { get; set; }
        public string Name { get; set; }
        public bool Status { get; set; }
        public List<Product> Products { get; set; }
    }
}
