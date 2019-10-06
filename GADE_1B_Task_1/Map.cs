using System;

namespace GADE_1B_Task_1
{
    class Map
    {
        //CLASS VARIABLES
        char[,] arrMap = new char[20, 20];
        public unit[] arrUnits;
        
        int sumUnits;

        //CLASS CONSTRUCTORS
        public Map(int _sumUnits)
        {
            sumUnits = _sumUnits;
        }

        //CLASS METHODS
        public void RandomBattlefield()
        {
            int randomX, randomY;

           
            arrUnits = new unit[sumUnits];
            Random rnd = new Random();

            for (int i = 0; i < 20; i++)
            {
                for (int k = 0; k < 20; k++)
                {
                    arrMap[i, k] = ',';

                }

            }

            for (int i = 0; i < sumUnits; i++)
            {
                
                
                randomX= rnd.Next(0,20);
                randomY = rnd.Next(0,20);

                int random;
                random = rnd.Next(1, 5);

                if (random == 1)
                {
                      

                    MeleeUnit unit = new MeleeUnit(randomX, randomY, 100, 1, 5, 1, "Team1", 'X',false);                
                    arrMap[unit.xPos, unit.yPos] = unit.symbol;
                    arrUnits[i] = unit;
                    
                }
                else if (random == 2)
                {
                    MeleeUnit unit = new MeleeUnit(randomX, randomY, 100, 1, 5, 1, "Team2", 'x', false);
                    arrMap[unit.xPos, unit.yPos] = unit.symbol;
                    arrUnits[i] = unit;
                }
                else if (random == 3)
                {
                    RangedUnit unit = new RangedUnit(randomX, randomY, 80, 1, 3, 1, "Team1", 'O', false);
                    arrMap[unit.xPos, unit.yPos] = unit.symbol;
                    arrUnits[i] = unit;
                }
                 else
                {                  
                    RangedUnit unit = new RangedUnit(randomX, randomY, 80, 1, 3, 1, "Team2", 'o', false);
                    arrMap[unit.xPos, unit.yPos] = unit.symbol;
                    arrUnits[i] = unit;
                }

                

               
            }

           

        }
       

        public string MapDisplay()
        {
           string mapString ;
            mapString = " ";

            for (int i = 0; i < 20; i++)
            {
                for (int k = 0; k < 20; k++)
                {
                    mapString = mapString + arrMap[i, k];
                }
                mapString += "\n";
                
            }
            
            
            
            return mapString;

        }

        public void MapUpdate(unit unitMove, int xOld, int yOld)
        {
            string unitType = unitMove.GetType().ToString();
            string[] Type = unitType.Split('.');
            unitType = Type[Type.Length - 1];

            if (unitType == "MeleeUnit")
            {
                
                MeleeUnit un = (MeleeUnit)unitMove;
                arrMap[xOld, yOld] = ',';
                
                arrMap[un.xPos, un.yPos] = un.symbol;
                
            }
            if (unitType == "RangedUnit")
            {
                
                RangedUnit un = (RangedUnit)unitMove;
                arrMap[xOld, yOld] = ',';
                
                arrMap[un.xPos, un.yPos] = un.symbol;
            }
            

            
           
            

        }

       

        
    }
}
