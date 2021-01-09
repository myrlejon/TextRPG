using System;
using System.Collections.Generic;
using System.Text;

namespace TextRPG
{
    class Minion : Unit
    {
        public Minion()
        {
            
        }

        public Minion(string name, int level, int health, int strength, int toughness)
        {
            this.name = name;
            this.level = level;
            this.health = health;
            this.strength = strength;
            this.toughness = toughness;
        }
    }
}
