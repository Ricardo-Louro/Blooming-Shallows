public class Building
    {
        public string Name { get; private set; }
        public int WoodCost { get; private set; }
        
        public int AmountBuilt { get; private set; }
        
        public int FoodUpkeep { get; private set; }
        public int WoodUpkeep { get; private set; }

        private int woodCostIncrease = 2;

        public Building(string name, int woodCost, int woodUpkeep, int foodUpkeep)
        {
            Name = name;
            WoodCost = woodCost;
            WoodUpkeep = woodUpkeep;
            FoodUpkeep = foodUpkeep;
        }

        public void BuildNew(int amount)
        {
            AmountBuilt += amount;
            WoodCost *= woodCostIncrease;
        }
    }
