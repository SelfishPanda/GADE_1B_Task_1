using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GADE_1B_Task_1
{
    class GameEngine
    {
        public int gameRounds;
        unit[] arrUnits;
        public Map map ;
        public string OutputString;

        public GameEngine()
        {
            map = new Map(2);
            map.RandomBattlefield();
            this.arrUnits = map.arrUnits;
            gameRounds = 0;
        }


        //Direction in wich to move
        public string Direction(unit Main, unit Enemy)
        {
            string ReturnVal;
            ReturnVal = " ";

            string MainType = Main.GetType().ToString();
            string[] mType = MainType.Split('.');
            MainType = mType[mType.Length - 1];

            string unitType = Enemy.GetType().ToString();
            string[] Type = unitType.Split('.');
            unitType = Type[Type.Length - 1];

            int xTotal, yTotal;
            string xDirection, yDirection;
            xTotal = 0;
            yTotal = 0;
            xDirection = "";
            yDirection = "";

            if (MainType == "MeleeUnit")
            {
                MeleeUnit m = (MeleeUnit)Main;
                if (unitType == "MeleeUnit")
                {
                    MeleeUnit e = (MeleeUnit)Enemy;

                    xTotal = m.xPos - e.xPos;
                    yTotal = m.yPos - e.yPos;

                    if (xTotal > 0)
                    {
                        xDirection = "left";
                    }
                    else if (xTotal < 0)
                    {
                        xDirection = "right";
                    }

                    if (yTotal > 0)
                    {
                        yDirection = "down";
                    }
                    else if (yTotal < 0)
                    {
                        yDirection = "up";
                    }

                    xTotal = Math.Abs(m.xPos - e.xPos);
                    yTotal = Math.Abs(m.yPos - e.yPos);
                }
                else
                {
                    RangedUnit e = (RangedUnit)Enemy;
                    xTotal = m.xPos - e.xPos;
                    yTotal = m.yPos - e.yPos;

                    if (xTotal > 0)
                    {
                        xDirection = "left";
                    }
                    else if (xTotal < 0)
                    {
                        xDirection = "right";
                    }

                    if (yTotal > 0)
                    {
                        yDirection = "down";
                    }
                    else if (yTotal < 0)
                    {
                        yDirection = "up";
                    }

                    xTotal = Math.Abs(m.xPos - e.xPos);
                    yTotal = Math.Abs(m.yPos - e.yPos);
                }
            }
            else
            {
                RangedUnit m = (RangedUnit)Main;
                if (unitType == "MeleeUnit")
                {
                    MeleeUnit e = (MeleeUnit)Enemy;
                    xTotal = m.xPos - e.xPos;
                    yTotal = m.yPos - e.yPos;

                    if (xTotal > 0)
                    {
                        xDirection = "left";
                    }
                    else if (xTotal < 0)
                    {
                        xDirection = "right";
                    }

                    if (yTotal > 0)
                    {
                        yDirection = "down";
                    }
                    else if (yTotal < 0)
                    {
                        yDirection = "up";
                    }

                    xTotal = Math.Abs(m.xPos - e.xPos);
                    yTotal = Math.Abs(m.yPos - e.yPos);
                }
                else
                {
                    RangedUnit e = (RangedUnit)Enemy;
                    xTotal = m.xPos - e.xPos;
                    yTotal = m.yPos - e.yPos;

                    if (xTotal > 0)
                    {
                        xDirection = "left";
                    }
                    else if (xTotal < 0)
                    {
                        xDirection = "right";
                    }

                    if (yTotal > 0)
                    {
                        yDirection = "down";
                    }
                    else if (yTotal < 0)
                    {
                        yDirection = "up";
                    }

                    xTotal = Math.Abs(m.xPos - e.xPos);
                    yTotal = Math.Abs(m.yPos - e.yPos);
                }
            }

            if (xTotal <= yTotal || xTotal>0)
            {
                ReturnVal = xDirection;
                return xDirection;
                
            }
            else
            {
                ReturnVal = yDirection;
                return yDirection;
                
            }              	
        }


        //
        public void GameLogic(unit[] ArrUnits)
        {
            gameRounds++;
            Random rnd = new Random();
            bool death;
            string direction;
            direction = " ";
            
            death = false;
            
            OutputString = "";
            for (int i = 0; i < ArrUnits.Length; i++)
            {
                string unitType = ArrUnits[i].GetType().ToString();
                string[] Type = unitType.Split('.');
                unitType = Type[Type.Length - 1];

                if (unitType == "MeleeUnit")
                {
                    MeleeUnit un = (MeleeUnit)ArrUnits[i];

                    death = un.Death();
                    if (death == true)
                    { }
                    else
                    {

                        unit closestunit;
                        closestunit = un.ClosestUnit(ArrUnits);
                        if (un == closestunit)
                        { }
                        else
                        {

                           un.AttackRange(closestunit);
                            if (un.HP<= (un.maxHP*0.25))
                            {
                                string randomDirection;
                                int random;

                                random = rnd.Next(1, 5);

                                if (random == 1)
                                {
                                    randomDirection = "left";
                                }
                                else if (random == 2)
                                {
                                    randomDirection = "right";
                                }
                                else if (random == 3)
                                {
                                    randomDirection = "up";
                                }
                                else
                                {
                                    randomDirection = "down";
                                }

                                un.Move(randomDirection);
                                

                            }
                            else
                            {


                                if (un.isAttacking == true)
                                {
                                    un.Combat(closestunit);
                                }
                                else
                                {
                                    int oldX, oldY;
                                    oldX = un.xPos;
                                    oldY = un.yPos;
                                    direction = Direction(un, closestunit);
                                    un.Move(direction);
                                    map.MapUpdate(un,oldX,oldY);
                                    
                                }
                            }

                        }
                    }
                    OutputString += "\n" + un.ToString();
                }
                else
                {
                    RangedUnit un = (RangedUnit)ArrUnits[i];

                    death = un.Death();
                    if (death == true)
                    { }
                    else
                    {

                        unit closestunit;
                        closestunit = un.ClosestUnit(ArrUnits);
                        if (un == closestunit)
                        { }
                        else
                        {

                            un.AttackRange(closestunit);
                            if (un.HP <= (un.maxHP * 0.25))
                            {
                                string randomDirection;
                                int random;

                                random = rnd.Next(1, 5);

                                if (random == 1)
                                {
                                    randomDirection = "left";
                                }
                                else if (random == 2)
                                {
                                    randomDirection = "right";
                                }
                                else if (random == 3)
                                {
                                    randomDirection = "up";
                                }
                                else
                                {
                                    randomDirection = "down";
                                }

                                un.Move(randomDirection);


                            }
                            else
                            {


                                if (un.isAttacking == true)
                                {
                                    un.Combat(closestunit);
                                }
                                else
                                {
                                    int oldX, oldY;
                                    oldX = un.xPos;
                                    oldY = un.yPos;
                                    direction = Direction(un, closestunit);
                                    un.Move(direction);
                                    map.MapUpdate(un, oldX, oldY);

                                }
                            }

                        }
                    }
                    OutputString += "\n" + un.ToString();
                }

                OutputString += "\n";

            }
            

            
        }

    }
}
