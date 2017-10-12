﻿using System.Collections.Generic;
using System.Threading;
using System.Drawing;
namespace BarberShop
{
    public class GlobalVariable
    {
        public static Semaphore maxCapacity = new Semaphore(20, 20);
        public static Semaphore sofa = new Semaphore(4, 4);
        public static Semaphore barberChair = new Semaphore(3, 3);
        public static Semaphore coord = new Semaphore(3, 3);
        public static Semaphore mutex1 = new Semaphore(1, 1);
        public static Semaphore mutex2 = new Semaphore(1, 1);
        public static Semaphore mutex3 = new Semaphore(1, 1);
        public static Semaphore custReady = new Semaphore(0, 50);
        //public static Semaphore leaveBChair = new Semaphore(0, 50);
        public static Semaphore payment = new Semaphore(0, 50);
        //public static Semaphore receipt = new Semaphore(0, 50);
        public static Semaphore[] finished = new Semaphore[50];
        public static Semaphore[] leaveBChair = new Semaphore[50];
        public static Semaphore[] receipt = new Semaphore[50];
        public static int numberOfCustomer = 50;
        public static Queue<int> queue1 = new Queue<int>(50);
        public static Queue<int> queue2 = new Queue<int>(50);
        public static Queue<int> sofaQueue = new Queue<int>(4);
        public static Queue<int> barberChairQueue = new Queue<int>(3);
        static int x = 15, y = 15;
        static Semaphore getPlaceSemaphore = new Semaphore(1, 1);
        public static PointF GetPlace()
        {
            getPlaceSemaphore.WaitOne();
            PointF pf = new PointF();
            if (y >= 340)
            {
                x += 30;
                y = 15;
            }
            pf.X = x;
            pf.Y = y;
            y += 30;
            if (x == 135)
                if (y > 180)
                {
                    x = 15;
                    y = 15;
                }
            getPlaceSemaphore.Release();
            return pf;
        }
        public GlobalVariable()
        {
            for (int i = 0; i < 50; i++)
            {
                finished[i] = new Semaphore(0, 1);
                leaveBChair[i] = new Semaphore(0, 1);
                receipt[i] = new Semaphore(0, 1);
            }
            for (int i = 1; i <= 4; i++)
                sofaQueue.Enqueue(i);
            for (int i = 1; i <= 3; i++)
                barberChairQueue.Enqueue(i);
        }
    }
}