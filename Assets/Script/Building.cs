public class Building
    {
        public string Name { get; private set; }
        public int WoodCost { get; private set; }
        
        public int AmountBuilt { get; private set; }
        
        public float FoodUpkeep { get; private set; }
        public float WoodUpkeep { get; private set; }

        private float woodCostIncrease = 1.25f;

        public Building(string name, int woodCost, float woodUpkeep, float foodUpkeep)
        {
            Name = name;
            WoodCost = woodCost;
            WoodUpkeep = woodUpkeep;
            FoodUpkeep = foodUpkeep;
        }

        public void BuildNew(int amount)
        {
            AmountBuilt += amount;
            WoodCost = (int)(WoodCost * woodCostIncrease + 2 * AmountBuilt);
        }
    }
