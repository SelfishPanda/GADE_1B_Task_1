using System;
namespace GADE_1B_Task_1
{
    class RangedUnit : unit
    {
        //PROPERTIES
        public int xPos { get {return base.xPos; } set { base.xPos = value; } }
        public int yPos { get { return base.yPos; } set { base.yPos = value; } }
        public int HP { get { return base.HP; } set { base.HP = value; } }
        public int maxHP { get { return base.maxHP; } }
        public int speed { get { return base.speed; } }
        public int attack { get { return base.attack; } }
        public int attackRange { get { return base.attackRange; } }
        public string team { get { return base.team; } }
        public char symbol { get { return base.symbol; } }
        public bool isAttacking { get { return base.isAttacking; } set { base.isAttacking = value; } }


        //CLASS CONSTRUCTORS
        public RangedUnit(int _xPos, int _yPos, int _HP, int _speed, int _attack, int _attackRange, string _team, char _symbol, bool _isAttacking) : base(_xPos,_yPos,_HP,_speed,_attack,_attackRange,_team,_symbol,_isAttacking)
        {
           
        }

        

        //CLASS METHODS
        public override void Move(string direction)
        {

            if (direction == "up")
            {
                if (this.yPos >= 0)
                {
                    this.yPos = this.yPos - 1;
                }

            }
            if (direction == "down")
            {
                if (this.yPos <= 19)
                {
                    this.yPos = this.yPos + 1;
                }

            }
            if (direction == "left")
            {
                if (this.xPos >= 0)
                {
                    this.xPos = this.xPos - 1;
                }

            }
            if (direction == "right")
            {
                if (this.xPos <= 19)
                {
                    this.xPos = this.xPos + 1;
                }

            }
        }


        //
        public override void Combat(unit Enemy)
        {
            if (isAttacking== true) 
            {
                string unitType = Enemy.GetType().ToString();
                string[] Type = unitType.Split('.');
                unitType = Type[Type.Length - 1];

                if (unitType == "meleeUnit")
                {
                    MeleeUnit un = (MeleeUnit)Enemy;

                    un.HP = un.HP - this.attack;
                }
                else
                {
                    RangedUnit un = (RangedUnit)Enemy;

                    un.HP = un.HP - this.attack;
                }
            }
        }


        //
        public override void AttackRange(unit Enemy)
        {
            int totalDist;

            string unitType = Enemy.GetType().ToString();
            string[] Type = unitType.Split('.');
            unitType = Type[Type.Length - 1];



            if (unitType == "MeleeUnit")
            {
                MeleeUnit un = (MeleeUnit)Enemy;
                totalDist = Math.Abs(this.xPos - un.xPos) + Math.Abs(this.yPos - un.yPos);
                if (totalDist < this.attackRange)
                {
                    this.isAttacking = true;
                }
                else
                {
                    this.isAttacking = false;
                }

            }
            else
            {
                RangedUnit un = (RangedUnit)Enemy;
                totalDist = Math.Abs(this.xPos - un.xPos) + Math.Abs(this.yPos - un.yPos);
                if (totalDist < this.attackRange)
                {
                    this.isAttacking = true;
                }
                else
                {
                    this.isAttacking = false;
                }

            }
        }


        //
        public override unit ClosestUnit(unit[] units)
        {
            int xDist, yDist, totalDist, closestDist, checkValue;
            unit closestUnit, thisUnit;
            closestDist = 19;
            closestUnit = units[1];
            checkValue = 69;
            thisUnit = units[1];

            for (int i = 0; i < units.Length; i++)
            {
                string unitType = units[i].GetType().ToString();
                string[] Type = unitType.Split('.');
                unitType = Type[Type.Length - 1];

                if (unitType == "MeleeUnit")
                {
                    MeleeUnit un = (MeleeUnit)units[i];

                    if (this.xPos == un.xPos && this.yPos == un.yPos || un.Death() || this.team == un.team)
                    {
                        if (this.xPos == un.xPos && this.yPos == un.yPos)
                        {
                            thisUnit = un;
                        }
                    }
                    else
                    {
                        xDist = Math.Abs(this.xPos - un.xPos);
                        yDist = Math.Abs(this.yPos - un.yPos);
                        totalDist = xDist + yDist;

                        if (totalDist < closestDist)
                        {
                            closestDist = totalDist;
                            closestUnit = units[i];
                            checkValue = 42;
                        }
                    }
                }
                else
                {
                    RangedUnit un = (RangedUnit)units[i];

                    if (this.xPos == un.xPos && this.yPos == un.yPos || un.Death() || this.team == un.team)
                    {
                        if (this.xPos == un.xPos && this.yPos == un.yPos)
                        {
                            thisUnit = un;
                        }
                    }
                    else
                    {
                        xDist = Math.Abs(this.xPos - un.xPos);
                        yDist = Math.Abs(this.yPos - un.yPos);
                        totalDist = xDist + yDist;

                        if (totalDist < closestDist)
                        {
                            closestDist = totalDist;
                            closestUnit = units[i];
                            checkValue = 42;
                        }
                    }
                }
                if (checkValue == 69)
                {
                    return thisUnit;
                }
                else
                {
                    return closestUnit;
                }
            }
            if (checkValue == 69)
            {
                return thisUnit;
            }
            else
            {
                return closestUnit;
            }
        }


        //
        public override bool Death()
        {
            bool dead;

            if (this.HP<=0)
            {
                dead = true;
            }
            else
            {
                dead = false;
            }

            return dead;
        }
        //
        public override string ToString()
        {
            string output = "";
            output = "Ranged Unit" + "\n" + "Health Points : " + this.HP + "\n" + "X-Position : " + this.xPos + "\n" + "Y-Position" + this.yPos;
            return output;
        }
    }
}
