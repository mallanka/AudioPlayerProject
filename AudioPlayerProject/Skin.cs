using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudioPlayerProject
{
    public abstract class Skin
    {
        public abstract void Clear();

        public abstract void Render();
    }

    public class ClassicSkin : Skin
    {
        public override void Clear()
        {
            Console.Clear();
        }

        public override void Render()
        {
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
    public class ColorSkin : Skin
    {
        public override void Clear()
        {
            Console.Clear();
        }

        public override void Render()
        {
            Console.WriteLine();
            Console.WriteLine("write a skin color");
            string text = Console.ReadLine();
            text = text.First().ToString().ToUpper() + text.Substring(1);
            Console.ForegroundColor = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), text);
        }
    }
    public class EyesSkin : Skin
    {
        public override void Clear()
        {
            Console.Clear();
            Console.WriteLine(" /  \\  /  \\" +
                                 "\n|    ||    |" +
                                "\n \\_*_/ \\_*_/" +
                              "\nbig bro is watching you (or is it not eyes?)");
        }

        public override void Render()
        {
            
        }
    }
}