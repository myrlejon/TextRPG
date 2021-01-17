using System;
using System.Collections.Generic;
using System.Text;

namespace TextRPG
{
    class Shop
    {
        public string name;
        public string description;
        public int total;
        public int price;

        public Shop()
        {

        }

        public Shop(string name, string description, int total, int price)
        {
            this.name = name;
            this.total = total;
            this.price = price;
            this.description = description;
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        public int Total
        {
            get { return total; }
            set { total = value; }
        }

        public int Price
        {
            get { return price; }
            set { price = value; }
        }
    }
}
