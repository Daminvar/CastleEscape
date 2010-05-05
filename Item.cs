using System;
using System.Collections.Generic;
using System.Text;

namespace CastleEscape
{
    [Serializable]
    class Item
    {
        private string name;
        private string description;
        private int healthBonus;
        private int manaBonus;
        private int cost;

        public string Name
        {
            get { return name; }
        }

        public string Description
        {
            get { return description; }
        }

        public int HealthBonus
        {
            get { return healthBonus; }
        }

        public int ManaBonus
        {
            get { return manaBonus; }
        }

        public int Cost
        {
            get { return cost; }
            set { cost = value; }
        }

        public Item(string name, string description, int healthBonus, int manaBonus, int cost)
        {
            this.name = name;
            this.description = description;
            this.healthBonus = healthBonus;
            this.manaBonus = manaBonus;
            this.cost = cost;
        }

        public override string ToString()
        {
            return string.Format("{0} - {1}", name, description);
        }
    }
}
