using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text;

namespace TextRPG
{
    class Player : Unit
    {
        public Player()
        {

        }

        public Player(string name, int level, int health, int experience, int gold, int strength, int toughness, int luck, int healthmax, int experiencecap)
        {
            this.name = name;
            this.level = level;
            this.health = health;
            this.experience = experience;
            this.gold = gold;
            this.strength = strength;
            this.toughness = toughness;
            this.luck = luck;
            this.healthmax = healthmax;
            this.experiencecap = experiencecap;
        }
    }
}
