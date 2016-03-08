using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NK4VM2
{

	static class Bus
	{
		public static int dataBus;
		public static int statusBus;
		public static int chipSelectBus;
		public static int direction;	//8 is read, 4 is write, 0xC is bad, 0 is also bad but it may start in that state

		private static System.Object lockThis = new System.Object();


		public static void Setup()
		{
			statusBus = 0;
			chipSelectBus = 15;
			dataBus = 0;
			direction = 0x4;
		}

		/// <summary>
		/// Updates the bus
		/// </summary>
		/// <param name="d"></param>
		/// <param name="s"></param>
		/// <param name="c"></param>
		/// <param name="id">Indicates which peripheral/CPU is accessing</param>
		/// <returns></returns>
		public static int Update_Bus(int d, int s, int c, int id)
		{
			lock (lockThis)	//Only one thread is allowed in here at a time
			{
				if (id > 15)	//CPU is calling
				{
					statusBus = s;
					chipSelectBus = c;
					if (direction == 0x4)
					{
						dataBus = d;
					}
					if ((s & 0xC) != 0)
					{
						direction = s & 0xC;
					}
				}
				else //Peripheral is calling 
				{
					if ((id == chipSelectBus) && (direction == 0x8))
					{
						dataBus = d;
					}
				}

				return dataBus;
			}			
		}

		/// <summary>
		/// Returns an array of all the values on the bus
		/// </summary>
		/// <returns></returns>
		public static int[] Get_Values()
		{
			lock (lockThis)
			{
				return new int[] { dataBus, statusBus, chipSelectBus, direction };
			}
		}


	}
}
