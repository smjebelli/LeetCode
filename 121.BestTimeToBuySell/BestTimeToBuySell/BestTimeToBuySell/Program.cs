namespace BestTimeToBuySell
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            Console.WriteLine(MaxProfit([7, 1, 5, 3, 6, 4]));
            Console.WriteLine(MaxProfit([7, 6, 4, 3, 1]));
            Console.WriteLine(MaxProfit([2, 4, 1]));
            Console.WriteLine(MaxProfit([2, 1, 2, 1, 0, 1, 2]));

        }

        static int MaxProfit(int[] prices)
        {
            int tempProfit = 0;
            int maxProfit = 0;
            for (int i = 1; i < prices.Length; i++)
            {
                if ((tempProfit += prices[i] - prices[i - 1]) < 0)
                { 
                    tempProfit = 0;
                    continue;
                }
                

                if (tempProfit > maxProfit)
                    maxProfit = tempProfit;

            }
            return maxProfit;
        }
    }
}
