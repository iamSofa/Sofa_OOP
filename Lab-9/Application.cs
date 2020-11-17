using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Lab_9
{
    public class Application
    {
        public static Random rand;
        static void Main(string[] args)
        {
            rand = new Random(DateTime.Now.Millisecond);
            Game g = new Game();

            Entity hero = new Entity()
            {
                heatlh = rand.Next(60, 110),
                wisdom = rand.Next(10, 30),
                strength = rand.Next(80, 120),
                doAttack = (obj) =>
                {
                    var strength = rand.Next(-obj.strength, obj.strength);
                    obj.heatlh -= strength;
                    BeautifulOutput(ConsoleColor.Green, $" - [Герой] Наносит урон врагу! {strength} [{obj}]");
                },
                doHeal = (obj) =>
                {
                    var heal = rand.Next(obj.wisdom);
                    obj.heatlh += heal;
                    BeautifulOutput(ConsoleColor.Green, $" + [Герой] Лечит союзника! {heal}  [{obj}]");
                }
            };

            Entity enemy = new Entity()
            {
                heatlh = rand.Next(10, 30),
                wisdom = rand.Next(90, 130),
                strength = rand.Next(10),
                doAttack = (obj) =>
                {
                    var strength = rand.Next(-obj.strength, obj.strength);
                    obj.heatlh -= strength;
                    BeautifulOutput(ConsoleColor.Red, $" - [Враг] Наносит урон! {strength}  [{obj}]");
                },
                doHeal = (obj) =>
                {
                    var heal = rand.Next(obj.wisdom);
                    obj.heatlh += heal;
                    BeautifulOutput(ConsoleColor.Red, $" + [Враг] Лечит себя! {heal}  [{obj}]");
                }
            };

            g.attack += enemy.doAttack;
            g.attack += enemy.doAttack;
            g.DoAttack(hero);
            g.heal += enemy.doHeal;
            g.heal += hero.doHeal;
            g.DoHeal(enemy);

            Func<string, string> strOp = (s) => s.ToUpper();
            string str = strOp("My:     name., is?   Sofa!");
            strOp = RemovePunctuationsMarks;
            str = strOp(str);
            strOp = RemoveUselessSpaces;
            str = strOp(str);
            Console.WriteLine(str);

            string str2 = strOp("My nome is Sofo!");
            strOp = AddPoint;
            str2 = strOp(str2);
            strOp = ReplaceO;
            str2 = strOp(str2);
            Console.WriteLine(str2);

            Console.ReadKey();
        }

        private static void BeautifulOutput(ConsoleColor color, string msg)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(msg);
            Console.ResetColor();
        }

        public static string RemovePunctuationsMarks(string str)
        {
            string dict = ",.:;!?";
            for (var i = 0; i < str.Length;)
            {
                if (dict.Contains(str[i]))
                {
                    str = str.Remove(i, 1);
                }
                else i++;
            }
            return str;
        }

        public static string RemoveUselessSpaces(string str)
        {
            for (int i = 0; i < str.Length - 1;)
            {
                if (str[i] == ' ' && str[i + 1] == ' ')
                {
                    str = str.Remove(i, 1);
                }
                else i++;
            }
            return str;
        }
        public static string AddPoint(string str)
        {
            if (str[str.Length - 1] == '!' || str[str.Length - 1] == '?')
            {
                str = str.Replace(str[str.Length - 1], '.'); 
            }
            return str;
        }
        public static string ReplaceO(string str)
        {
            str = str.Replace('o', 'a');
            return str;
        }
    }
}
