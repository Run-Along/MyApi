using System;

namespace MyActivity_04
{
    interface IHuman        // interface
    {
        string Gender               // interface property for gender
        { 
            get; 
            set; 
        }
        string PreferredGender      // interface property for PrefferedGender
        {
            get;
            set;
        }
        string Race      // interface property for Race
        {
            get;
            set;
        }
        string Name      // interface property for Name
        {
            get;
            set;
        }

        int Age      // interface property for Name
        {
            get;
            set;
        }
        bool Alive// interface property for Name
        {
            get;
            set;
        }

        void DeadorAlive();         // interface method

        int this [int index]             // indexer
        {
            get;
            set;
        }

    }

    class Person : IHuman
    {
        private string _gender = " ";                  // gender variable
        public string Gender                         // property implementation
        { get { return _gender; }
            set { _gender = value; }
        }
        private string _preferredGender = "My Choice";   // preferredGender variable
        public string PreferredGender                   // property implementation
        {
            get { return _preferredGender; }
            set { _preferredGender = value; }
        }

        private string _race = "Skin Suit";                //race variable;
        public string Race                              // race property implementation
        {
            get { return _race; }
            set { _race = value; }
        }

        private string _name = " ";                     // name variable
        public string Name                              // property implementation
        {
            get { return _name; }
            set { _name = value; }
        }

        private int _age = 0;                     // name variable
        public int Age                              // property implementation
        {
            get { return _age; }
            set { _age = value; }
        }

        private bool _alive = true;
        public bool Alive
        { 
            get { return _alive;}
            set { _alive = value; }
        }

        public void DeadorAlive()
        {
            if (_alive)
            {
                Console.WriteLine(_name + " is alive. But they've been dead inside for a long long time.") ;
            }
            else
            {
                Console.WriteLine(_name + " is now consuming exactly 0.01% of the world's resources");
                Console.WriteLine("The 0.01% is for the fancy non biodegradeable coffin they got placed in.");
            }
        }

        private int[] bestYears = new int[100];
        public int this [int index]
        {
            get { return bestYears[index]; }
            set { bestYears[index] = value; }
        }

    }

    class Program
    {
        static void Main (string[] args)
        {
            Person firstPerson = new Person();
            firstPerson.Name = "Wanda";
            firstPerson.Age = 32;
            firstPerson.Gender = "Female";
            firstPerson.PreferredGender = "Male";
            firstPerson.Alive = false;
            firstPerson.DeadorAlive();
            
        }
    }
}