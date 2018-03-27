using System;
namespace CB4_CS_WEx02
{
    public enum Color
    {
        Red,
        Blue,
        Magenta,
        Orange,
        Black,
        White
    }

    //
    // Shape 
    //
    public /*abstract*/ class Shape  // This is not 'abstract' no more. See method GetInfo.
    {
        // Fields
        private Color _color;

        //Properties
        public Color GetColor
        {
            get
            {
                return _color;
            }
        }

        // Methods
        public void SetColor(Color color)
        {
            this._color = color;
        }

        public virtual string GetInfo() // I made this vistual so it can be used to get the enclosing text.
		{    
		    return $"Shape of color {this._color}.";
		}

		public override string ToString()
		{
            return GetInfo();
		}
	}


    //
    // Rectangle
    //
    public class Rectangle : Shape, IComparable, IEquatable<Rectangle>
    {
        // Fields
        private string _name = "Rectangle";
        private double _height;
        private double _width;

        // Properties
        public double Height
        {
            get{
                return _height;
            }
        }
        public double Width
        {
            get {
                return _width;
            }
        }

        // Methods
        public virtual double GetArea()  // I made this double instead of void for eficiency. I don't want to use anoter variable and two statements in the main program.
        {
            return this._width * this._height;
        }

        public override string GetInfo()
        {
            return $"{this._name} of color {this.GetColor}, height {this._height} and width {this._width}.";
        }

        public override string ToString()
        {
            return this.GetInfo();
        }

        public int CompareTo(object obj)
        {
            Rectangle other = obj as Rectangle;
            if (this.GetArea() > other.GetArea())
            {
                return 1;
            }
            else if (this.GetArea() == other.GetArea())
            {
                return 0;
            }
            else
            {
                return -1;
            }
        }

        public bool Equals(Rectangle other)
        {
            return this.GetArea() == other.GetArea();
        }

        // Constructor
        public Rectangle(double height, double width)
        {
            this._width = width;
            this._height = height;
        }
    }


    //
    // Square
    //
    public sealed class Square : Rectangle, IComparable
    {
        private string _name = "Square";
        private double _side;

		public override string GetInfo()
		{
            return $"{this._name} of color {this.GetColor} and side {this._side}.";
		}

        public override string ToString()
        {
            return this.GetInfo();
        }

		// Constructor
        public Square(double side) : base(side, side)
        {
            this._side = side;

        }
    }

}
