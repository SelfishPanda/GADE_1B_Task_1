﻿using System;
namespace GADE_1B_Task_1
{
    class RangedUnit : unit
    {
        public RangedUnit(int _xPos, int _yPos, int _HP, int _speed, int _attack, int _attackRange, string _team, char _symbol, bool _isAttacking) : base(_xPos, _yPos, _HP, _speed, _attack, _attackRange, _team, _symbol, _isAttacking)
        {

        }



        public override string ToString()
        {
            string output = "";
            output = "Ranged Unit (" + team + ")" + "\n" + "Health Points : " + this.HP + "\n" + "X-Position : " + this.xPos + "\n" + "Y-Position :" + this.yPos;
            return output;
        }
    }
}
