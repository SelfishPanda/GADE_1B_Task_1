namespace GADE_1B_Task_1
{
    abstract class unit
    {
        //CLASS VARIABLES
        protected int xPos, yPos, HP, maxHP, speed, attack, attackRange;
        protected string team;
        protected char symbol;
        protected bool isAttacking;

        //CLASS CONSTRUCTORS
        public  unit(int _xPos, int _yPos, int _HP, int _speed, int _attack, int _attackRange, string _team, char _symbol, bool _isAttacking)
        {           
            xPos = _xPos;
            yPos = _yPos;
            HP = _HP;
            maxHP = HP;
            speed = _speed;
            attack = _attack;
            attackRange = _attackRange;
            team = _team;
            symbol = _symbol;
            isAttacking = _isAttacking;

        }

        //CLASS METHODS
        public abstract void Move(string direction);
        public abstract void Combat(unit Enemy);
        public abstract void AttackRange(unit Enemy);
        public abstract unit ClosestUnit(unit[] units);
        public abstract bool Death();
        public abstract string ToString();
       


    }
}
