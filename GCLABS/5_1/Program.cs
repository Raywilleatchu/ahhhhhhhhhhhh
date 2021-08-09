using System;
using System.Collections.Generic;

namespace _5_1
{
    class GameCharacter
    {
        private string name;
        private int strength;
        private int intelligence;


        public GameCharacter(string _name, int _strength, int _intelligence)
        {
            SetName(_name);
            SetStrength(_strength);
            SetIntelligence(_intelligence);
        }

        public GameCharacter()
        {

        }

        public string GetName()
        {
            return name;
        }

        public void SetName(string _name)
        {
            name = _name;
        }

        public int GetStrength()
        {
            return strength;
        }

        public void SetStrength(int _strength)
        {
            strength = _strength;
        }

        public int GetIntelligence()
        {
            return intelligence;
        }

        public void SetIntelligence(int _intelligence)
        {
            intelligence = _intelligence;
        }



        public virtual void Play()
        {
            Console.WriteLine($"This Hero's name is {GetName()} with a strength of {GetStrength()} and intelligence of {GetIntelligence()}");
        }

    }

    class MagicUsingCharacter : GameCharacter
    {
        private int magicalEnergy;

        public MagicUsingCharacter(string _name, int _strength, int _intelligence, int _magicalEnergy): base(_name, _strength, _intelligence)
        {
             SetMagicalEnergy(_magicalEnergy);
        }

        public int GetMagicalEnergy()
        {
            return magicalEnergy;
        }

        public void SetMagicalEnergy(int _magicalEnergy)
        {
            magicalEnergy = _magicalEnergy;
        }

        public override void Play()
        {
            Console.WriteLine($"This Hero's name is {GetName()} with a strength of {GetStrength()} and intelligence of {GetIntelligence()} (Mana: {GetMagicalEnergy()})");
        }

    }
    class Warrior : GameCharacter
    {
        private string weaponType;

        public Warrior(string _name, int _strength, int _intelligence, string _weaponType) : base(_name, _strength, _intelligence)
        {
            SetWeaponType(_weaponType);
        }

        public string GetWeaponType()
        {
            return weaponType;
        }

        public void SetWeaponType(string _weaponType)
        {
            weaponType = _weaponType;
        }


        public override void Play()
        {
            Console.WriteLine($"This Hero's name is {GetName()} with a strength of {GetStrength()} and intelligence of {GetIntelligence()} (Weapon Type: {GetWeaponType()})");
        }
    }
    class Wizard : MagicUsingCharacter
    {
        private int spellNumber;

        public Wizard(string _name, int _strength, int _intelligence, int _spellNumber, int _magicalEnergy) : base(_name, _strength, _intelligence, _magicalEnergy)
        {
            SetSpellNumber(_spellNumber);
        }

        public int GetSpellNumber()
        {
            return spellNumber;
        }

        public void SetSpellNumber(int _spellNumber)
        {
            spellNumber = _spellNumber;
        }


        public override void Play()
        {
            Console.WriteLine($"This Hero's name is {GetName()} with a strength of {GetStrength()} and intelligence of {GetIntelligence()} (Mana: {GetMagicalEnergy()}, Spell Slots: {GetSpellNumber()})");
        }

    }


    class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome Adventurer!");
            List<GameCharacter> characters = new List<GameCharacter>();
            Warrior c1 = new Warrior("Warrior 1", 16, 4, "2-Handed GreatAxe");
            Warrior c2 = new Warrior("Warrior 2", 18, 2, "Longsword");
            Warrior c3 = new Warrior("Warrior 3", 15, 4, "Dual-HandAxes");
            Wizard c4 = new Wizard("Wizard 1", 6, 14, 10, 100);
            characters.Add(c1);
            characters.Add(c2);
            characters.Add(c3);
            characters.Add(c4);

            foreach (var character in characters)
            {
                character.Play();
            }


        }
    }
}
