namespace Mario_Game
{
    internal class ground
    {
        public ground()
        {
        }
        public void generate()
        {
            for (int i = 0; i < 1000; i++)
            {
                level1.groundblocks.Add(i);
                level1.groundblocks[0] = -1950;
                level1.groundblocks[i] = level1.groundblocks[0] + level1.groundrec.Width * i;
            }
        }
        public void move()
        {
            if (level1.rightgo == false)
            {
                for (int i = 0; i < level1.groundblocks.Count; i++)
                {
                    if (level1.groundblocks[i] <= -100)
                    {
                        level1.groundblocks.RemoveAt(0);
                        level1.groundblocks.Add(1);
                        level1.groundblocks[100] = level1.groundblocks[99] + level1.groundrec.Width;
                    }
                    if (level1.groundblocks[i] >= 1600)
                    {
                        level1.groundblocks.RemoveAt(100);
                        level1.groundblocks.Add(1);
                        //level1.groundblocks.
                        level1.groundblocks[100] = level1.groundblocks[99] + level1.groundrec.Width;
                    }
                }
            }
        }
    }
}
