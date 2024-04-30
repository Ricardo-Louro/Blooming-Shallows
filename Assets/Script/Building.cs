public class Building
    {
        public string Name { get; private set; }
        public int WoodCost { get; private set; }
        public int StoneCost { get; private set; }
        
        public int AmountBuilt { get; private set; }

        public Building(string name, int woodCost, int stoneCost)
        {
            Name = name;
            WoodCost = woodCost;
            StoneCost = stoneCost;
        }

        public void BuildNew(int amount)
        {
            AmountBuilt += amount;
        }
    }
