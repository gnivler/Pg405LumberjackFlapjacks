using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pg405LumberjackFlapjacks
{
    class Lumberjack
    {
        private string name;
        public string Name { get { return name; } }
        private Stack<Flapjack> meal;
        public Lumberjack(string name)
        {
            this.name = name;
            meal = new Stack<Flapjack>();
               
        }
        public int FlapjackCount {  get { return meal.Count; } }
        public void TakeFlapjacks(Flapjack food, int howMany)
        {
            // add some # of flapjacks to the meal stack
            for (int i = 0; i < howMany; i++)
            {
                meal.Push(food);
            }
        }
        public void EatFlapjacks()
        {
            // console write all the flapjacks
            Console.WriteLine($"{Name}'s eating flapjacks{Environment.NewLine}");
            while (meal.Count > 0)
            {
                Console.WriteLine($"{Name} ate a {meal.Pop().ToString().ToLower()} flapjack{Environment.NewLine}");
            }
        }
    }
}
