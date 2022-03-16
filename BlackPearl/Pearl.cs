using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackPearl
{
    public class Pearl : IPearl
    {
        [Key]
        public int Id { get; set; }
        public int NecklaceID { get; set; } 
        public const int basePrice = 50;
        public int Diameter { get; set; }
        public string Color { get; set; } // kan vara Enum om man vill
        public string Shape { get; set; }
        public string Type { get; set; }
        
        private int price;
        public int Price
        {
            get 
            {
                if (Type == "Saltvatten")
                {
                    return basePrice * Diameter * 2;
                }
                else // om den är Sötvatten
                {
                    return basePrice * Diameter;
                }
            }
            set { price = value; }
        }

        // Måste vara med fast det står 0 references
        public int CompareTo(IPearl other)
        {
            // om diameter inte är sorterad redan så sorteras den nu
            // efter diameter, och sedan Color, och sedan shape
            if (Diameter != other.Diameter)
            {
                return Diameter.CompareTo(other.Diameter);
            }
            if (Color != other.Color)
            {
                return Color.CompareTo(other.Color);
            }
            else
            {
                return Shape.CompareTo(other.Shape);
            }
        }
        
        // Funkar inte utan denna
        public bool Equals(IPearl other)
        {
            return (Color) == (other.Color);
        }

        // public bool Equals(IPearl other) => (this.Size, this.Color, this.Shape, this.Type) == (other.Size, other.Color, other.Shape, other.Type);
        //public override bool Equals(object obj) => Equals(obj as IPearl);
        //public override int GetHashCode() => (Size, Color, Shape, Type).GetHashCode();

        // Legacy .NET compliance ska va med om man använder Equals
        public override bool Equals(object obj) => Equals(obj as IPearl);
        public override int GetHashCode() => (Color, Shape).GetHashCode();

        // Skriver ut Pearl, måste vara med
        public override string ToString()
        {
            return $"Färg: {Color}, Formen: {Shape}, VattenTyp: {Type}, Diameter: {Diameter}mm och priset för pärlan är: { Price} SKR";
        }
        
        // Här skapas slumpmässiga pärlor
        public void RandomInit()
        {
                var rnd = new Random();
                while (true)
                {
                    try
                    {
                    string[] _color = "Svart Vit Rosa".Split(' ');
                    this.Color = _color[rnd.Next(0, _color.Length)];

                    string[] _shape = "Rund Droppformad".Split(' ');
                    this.Shape = _shape[rnd.Next(0, _shape.Length)];

                    string[] _type = "Sötvatten Saltvatten".Split(' ');
                    this.Type = _type[rnd.Next(0, _type.Length)];

                    int _size = rnd.Next(5, 26);
                    this.Diameter = _size;

                    return;
                }
                    catch { }
                }
        }

        // Måste vara med
        public Pearl()
        {
            RandomInit();
        }

        // Factory
        public static class Factory
        {
            public static Pearl CreateRandomPearl(int NecklaceID)
            {
                
                var p = new Pearl();
                p.RandomInit();
                p.NecklaceID = NecklaceID;
                return p;
            }
        }
    }
}
