using System;

class Program
{
    static void Main(string[] args)
    {
        int T = int.Parse(Console.ReadLine());

        for (int i = 0; i < T; i++)
        {
            // Read the requirements
            int[] requirements = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
            int R = requirements[0];
            int C = requirements[1];
            int D = requirements[2];

            // Read the maximum capacities
            int[] capacities = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
            int NR = capacities[0];
            int NC = capacities[1];
            int ND = capacities[2];

            // Read the prices and budget
            int[] prices = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
            int PR = prices[0];
            int PC = prices[1];
            int PD = prices[2];
            int budget = int.Parse(Console.ReadLine());

            // Calculate the maximum number of machines
            int maxMachinesR = NR / R;
            int maxMachinesC = NC / C;
            int maxMachinesD = ND / D;

            // Calculate additional machines that can be purchased with the budget
            int extraMachinesR = Math.Min((budget / PR), maxMachinesR - 1);
            int extraMachinesC = Math.Min((budget / PC), maxMachinesC - 1);
            int extraMachinesD = Math.Min((budget / PD), maxMachinesD - 1);

            // Calculate the maximum number of machines considering the additional resources
            int maxMachines = Math.Min(Math.Min(maxMachinesR + extraMachinesR, maxMachinesC + extraMachinesC), maxMachinesD + extraMachinesD);

            Console.WriteLine(maxMachines);
        }
    }
}
