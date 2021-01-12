using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.OxiServi.AggregatesModel.CategoryAggregate
{
    public class Category
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }

        public void Create( string CategoryName, string Description)
        {
            this.CategoryName = CategoryName;
            this.Description = Description;
        }

        public void Update(int CategoryID, string CategoryName, string Description)
        {
            this.CategoryID = CategoryID;
            this.CategoryName = CategoryName;
            this.Description = Description;
        }

        public void Delete( int CategoryID)
        {
            this.CategoryID = CategoryID;
        }
    }
}
