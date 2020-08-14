using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BreakfastTest
{
    public static class Program
    {
        public static async Task Main(string[] args)
        {
            var cup = PourCoffee();
            Console.WriteLine("coffee is ready");

            var eggsTask = FryEggsAsync(2);
            var baconTask = FryBaconAsync(3);
            var toastTask = MakeToastWithButterAndJamAsync(2);

            var breakfastTasks = new List<Task> {eggsTask, baconTask, toastTask};
            while (breakfastTasks.Count > 0)
            {
                var finishedTask = await Task.WhenAny(breakfastTasks);
                if (finishedTask == eggsTask)
                    Console.WriteLine("eggs are ready");
                else if (finishedTask == baconTask)
                    Console.WriteLine("bacon is ready");
                else if (finishedTask == toastTask) Console.WriteLine("toast is ready");
                breakfastTasks.Remove(finishedTask);
            }

            var oj = PourOj();
            Console.WriteLine("oj is ready");
            Console.WriteLine("Breakfast is ready!");
        }

        private static async Task<Toast> MakeToastWithButterAndJamAsync(int number)
        {
            var toast = await ToastBreadAsync(number);
            ApplyButter(toast);
            ApplyJam(toast);

            return toast;
        }

        private static Juice PourOj()
        {
            Console.WriteLine("Pouring orange juice");
            return new Juice();
        }

        private static void ApplyJam(Toast toast)
        {
            Console.WriteLine("Putting jam on the toast");
        }

        private static void ApplyButter(Toast toast)
        {
            Console.WriteLine("Putting butter on the toast");
        }

        private static async Task<Toast> ToastBreadAsync(int slices)
        {
            for (var slice = 0; slice < slices; slice++) Console.WriteLine("Putting a slice of bread in the toaster");
            Console.WriteLine("Start toasting...");
            await Task.Delay(6000);
            Console.WriteLine("Remove toast from toaster");

            return new Toast();
        }

        private static async Task<Bacon> FryBaconAsync(int slices)
        {
            Console.WriteLine($"putting {slices} slices of bacon in the pan");
            Console.WriteLine("cooking first side of bacon...");
            await Task.Delay(7000);
            for (var slice = 0; slice < slices; slice++) Console.WriteLine("flipping a slice of bacon");
            Console.WriteLine("cooking the second side of bacon...");
            await Task.Delay(7000);
            Console.WriteLine("Put bacon on plate");

            return new Bacon();
        }

        private static async Task<Egg> FryEggsAsync(int howMany)
        {
            Console.WriteLine("Warming the egg pan...");
            await Task.Delay(15000);
            Console.WriteLine($"cracking {howMany} eggs");
            Console.WriteLine("cooking the eggs ...");
            await Task.Delay(10000);
            Console.WriteLine("Put eggs on plate");

            return new Egg();
        }

        private static Coffee PourCoffee()
        {
            Console.WriteLine("Pouring coffee");
            return new Coffee();
        }
    }

    internal class Juice
    {
    }

    internal class Toast
    {
    }

    internal class Bacon
    {
    }

    internal class Egg
    {
    }

    internal class Coffee
    {
    }
}