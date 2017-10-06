using System;
using System.Diagnostics;
using System.Threading;

namespace CowansGame
{
    class CowansLife
    {
        static int total = 225; 
        static int rows = 15;
        static Random rnd= new Random();
        //static int[] trial = {1,1,1,0,1,  0,1,0,1,1,  1,0,1,1,0,  1,0,1,1,0, 1,1,0,1,1};
        static int[,] grid = new int[rows,rows];
        static int val = 0;
        static Point p;
        
        static CowansLife()		
        {
            for(int i = 0; i < total; i++)
            {
                val = rnd.Next(0, 2);
                grid[i%rows, (int)i/rows] = val; // trial[i];
                //Console.WriteLine($"x = {i%rows} and y = {(int)i/rows} and val = {val}");
            }
        }
        
        public static void RefreshScreen()
        {
            //if (Console.IsOutputRedirected) Console.Clear();
            string c = " ";
            for(int i = 0; i < total; i++)
            {
                c = grid[i%rows,(int)i/rows] == 1 ? " * " : "   "; 
                Console.Write(c); if ((i+1)%rows == 0) Console.Write("\n");
            }
        }
        public static void Main()
        {
            Console.Write("Press any key to start");
            Console.Read();
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            for (int j=0; j < 50; j++)
            {
                RefreshScreen();
                Thread.Sleep(250);
                RecalculateLives();
            }
            stopWatch.Stop();
            Console.WriteLine($"Time taken: {stopWatch.Elapsed}");
        }

        public static void RecalculateLives()
        {
            Console.Clear();
            int liveNeighs;
            
            for(int i = 0; i < total; i++)
            {
                p.y = (int)i/rows; p.x = i%rows;  
                liveNeighs = countLiveNeighbours(p);
                switch (grid[p.x,p.y])
                { 
                    case 1: 
                        if (liveNeighs < 2 || liveNeighs > 3 ) grid[p.x,p.y] = 0; //kill
                    break;
                    case 0:
                        if (liveNeighs == 3) grid[p.x,p.y] = 1;
                        break;
                }
                //Console.WriteLine($"x = {p.x} and y = {p.y}, val is {grid[p.x,p.y]} and Live Neighbours = {liveNeighs}");	
            }
        }        
        public static int countLiveNeighbours(Point p)
        {
            int count = 0;
            if (p.x != 0) // not leftmost column
            {
                if (grid[p.x-1, p.y] == 1) count++; // check cell to left
                if (p.y != 0) // not leftmost column and not top row
                {
                    if (grid[p.x-1, p.y-1] == 1) count++; //check top left neighbor
                }
                if (p.y != rows-1) // not leftmost column and not bottom row
                {
                    if (grid[p.x-1, p.y+1] == 1) count++; //check bottom left neighbor
                }
            }	
            if (p.x != rows-1) // not rightmost column
            {
                if (grid[p.x+1, p.y] == 1)  count++; // check cell to right
                if (p.y != 0) // not rightmost column and not top row
                {
                    if (grid[p.x+1, p.y-1] == 1) count++; //check top right neighbor
                }
                if (p.y != rows-1) // not rightmost column and not bottom row
                {
                    if (grid[p.x+1, p.y+1] == 1)  count++; //check bottom right neighbor
                }
            }
            if (p.y != 0) // not top row
            {
                if (grid[p.x, p.y-1] == 1)  count++; // check cell above
            }
            if (p.y != rows-1) // not bottom row
            {
                if (grid[p.x, p.y+1] == 1)   count++; // check cell above
            }
            return count;
        }
        
        public struct Point
        {
            public int x {get; set;}
            public int y {get; set;}
        }
	}
}
