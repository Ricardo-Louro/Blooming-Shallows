public class Building
    {
        public string Name { get; private set; }
        public int WoodCost { get; private set; }
        
        public int AmountBuilt { get; private set; }

        public Building(string name, int woodCost)
        {
            Name = name;
            WoodCost = woodCost;
        }

        public void BuildNew(int amount)
        {
            AmountBuilt += amount;
        }
    }
