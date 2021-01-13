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

        public Minion(string name, int level, int health, int experience, int gold, int strength, int toughness, int healthmax)
        {
            this.name = name;
            this.level = level;
            this.health = health;
            this.experience = experience;
            this.gold = gold;
            this.strength = strength;
            this.toughness = toughness;
            this.healthmax = healthmax;
        }
    }
}
