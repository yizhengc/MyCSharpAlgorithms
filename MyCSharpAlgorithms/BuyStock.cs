using System;

namespace MyCSharpAlgorithms
{
	public class BuyStock
	{
		public BuyStock ()
		{
		}

		public int MaxProfit(int[] prices) {

			if (prices == null || prices.Length <= 1)
			{
				return 0;
			}

			int maxProfit = 0;
			int buy = -1;
			int sell = -1;
			for(int i = 0; i < prices.Length - 1; i++)
			{
				if (prices[i + 1] > prices[i])
				{
					buy = prices[i];
				}
				else
				{
					if (buy >= 0)
					{
						maxProfit += prices[i] - buy;
						buy = -1;
					}
				}
			}

			if (buy >= 0)
			{
				maxProfit += prices[prices.Length - 1] - buy;
			}

			return maxProfit;
		}
	}
}

