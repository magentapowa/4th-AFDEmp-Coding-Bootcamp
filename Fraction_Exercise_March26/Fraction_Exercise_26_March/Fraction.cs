using System;
namespace Fraction_Exercise_26_March
{
    public class Fraction : IComparable
    {
        // Properties
        public int x { get; set; }
        public int y { get; set; }
        public double Calculate
        {
            get{
                return ((double)this.x) / (this.y);
            }
        }
        // -----------------------


        // Methods
        static public Fraction Parse(string input)
        {
            int i;
            int j;
            string[] rawNums = input.Split('/');
            if (rawNums.Length != 2)
            {
                throw new Exception("    Input has the wrong format. Example: 1/6");
            }

            try
            {
                i = int.Parse(rawNums[0]);
                j = int.Parse(rawNums[1]);
            }
            catch (Exception)
            {
                throw new Exception("    Input has the wrong format. Example: 1/6");
            }

            return new Fraction(i, j);
        }
       
        public void Cancel()  // Simplify fraction
        {
            int i = 2;
            while ( i <= Math.Min(this.x, this.y))
            {
                if (x % i == 0 && y % i == 0)
                {
                    x = x / i;
                    y = y / i;
                }
                i++;
            }
        }
        // -----------------------


        // Overide ToString()
        public override string ToString()
        {
            if (this.x*this.y >= 0)
            {
                return $"{Math.Abs(this.x)}/{Math.Abs(this.y)}";
            }
            else{
                return $"-{Math.Abs(this.x)}/{Math.Abs(this.y)}";
            }

        }
        // -----------------------

        // Operator overload
        public static Fraction operator *(Fraction A, Fraction B)
        {
            return new Fraction(A.x * B.x , (A.y * B.y));
        }
        public static Fraction operator *(Fraction f, int b)
        {
            return f * new Fraction(b); // Uses the above. fruction*fruction (and the 3rd constructor that takes as input only the nominator.
        }
        public static Fraction operator *(int a, Fraction f) 
        {
            return f * a; //Uses the above. fraction*int
            //return f * new Fraction(b); //Uses the above-above. fraction*fraction  (and the 3rd ctor...)
        }
        // -----------------------


        // IComperable
        public int CompareTo(object obj)
        {
            Fraction c = obj as Fraction;
            if (this.Calculate > c.Calculate)
            {
                return 1;
            }
            else if (this.Calculate == c.Calculate)
            {
                return 0;
            }
            else{
                return -1;
            }
        }
        // -----------------------

        // Constructor
        public Fraction(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        public Fraction(int x)
        {
            this.x = x;
            this.y = 1;
        }
        public Fraction()
        {
            this.x = 0;
            this.y = 1;
        }
        // -----------------------
    }
}