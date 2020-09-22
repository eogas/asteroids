using System;
using System.Collections.Generic;
using System.Linq;

namespace Asteroids
{
    public class Program
    {
        static void Main(string[] args)
        {
            if (args.Count() != 1) {
                Console.Error.WriteLine("Usage: asteroids \"<int array>\"");
                Environment.Exit(1);
            }

            var asteroids = args[0].Split(",").Select(s => int.Parse(s.Trim())).ToArray();
            var remainingAsteroids = Asteroids(asteroids);

            System.Console.WriteLine($"[{string.Join(", ", remainingAsteroids)}]");
        }

        public static int[] Asteroids(int[] asteroids)
        {
            if (asteroids == null || !asteroids.Any()) {
                return Array.Empty<int>();
            }

            if (asteroids.Count() == 1) {
                return asteroids;
            }

            bool explosionsOccurred;

            do {
                explosionsOccurred = false;
                asteroids = asteroids.Where(a => a != 0).ToArray(); // remove exploded asteroids
 
                for (int i = 0; i < asteroids.Count() - 1; i++) {
                    var first = asteroids[i];
                    var second = asteroids[i + 1];

                    // one has already been blown up! skip!
                    if (first == 0 || second == 0) {
                        continue;
                    }

                    // same direction? or away from each other? skip!
                    if (first > 0 && second > 0 ||
                        first < 0 && second < 0 ||
                        first < 0 && second > 0) {
                        continue;
                    }

                    explosionsOccurred = true;
                    
                    var firstSize = Math.Abs(first);
                    var secondSize = Math.Abs(second);

                    if (firstSize > secondSize) {
                        asteroids[i + 1] = 0;
                    }
                    else if (firstSize < secondSize) {
                        asteroids[i] = 0;
                    }
                    else {
                        asteroids[i] = 0;
                        asteroids[i + 1] = 0;
                    }
                }
            } while (explosionsOccurred);

            return asteroids;
        }
    }
}
