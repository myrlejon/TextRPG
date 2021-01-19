using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace TextRPG
{
    class Unit
    {
        public string name;
        public int level;
        public int health;
        public int experience;
        public int gold;
        public int strength;
        public int toughness;
        public int healthmax;
        public int experiencecap;
        public int luck;
   
    public Unit()
        {

        }

        public Unit(string name, int level, int health, int experience, int gold, int strength, int toughness, int healthmax, int experiencecap)
        {
            this.name = name;
            this.level = level;
            this.health = health;
            this.experience = experience;
            this.gold = gold;
            this.strength = strength;
            this.toughness = toughness;
            this.healthmax = healthmax;
            this.experiencecap = experiencecap;
        }
    public string Name
        {
            get { return name; }
            set { name = value; }
        }

    public int Level
        {
            get { return level; }
            set { level = value; }
        }

    public int Health
        {
            get { return health; }
            set { health = value; }
        }

    public int Experience
        {
            get { return experience; }
            set { experience = value; }
        }

    public int Gold
        {
            get { return gold; }
            set { gold = value; }
        }
    public int Strength
        {
            get { return strength; }
            set { strength = value; }
        }

    public int Toughness
        {
            get { return toughness; }
            set { toughness = value; }
        }

    public int Healthmax
        {
            get { return healthmax; }
            set { healthmax = value; }
        }

    public int Experiencecap
       {
            get { return experiencecap; }
            set { experiencecap = value; }
       }
    public int Luck
        {
            get { return luck; }
            set { luck = value; }
        }
    }

   
}
