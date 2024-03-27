using System;

namespace Mario_Game
{
    internal class mario
    {
        public mario()
        {
            //ground floor;
        }
        public void Move(string direction)
        {
            if (direction == "Right")
            {    
                level1.mariorec.X += level1.marioxspeed;
                level1.marioright.X += level1.marioxspeed;
                if (level1.mariorec.X >= level1.sizeX / 2 - level1.mariorec.Width)
                {
                    level1.marioxspeed = 0;
                    level1.rightgo = false;
                    level1.bighillrec.X -= 10;
                    level1.smallhillrec.X -= 10;
                    level1.bush1rec.X -= 10;
                    level1.bush2rec.X -= 10;
                    level1.bush3rec.X -= 10;
                    level1.cloud1rec.X -= 10;
                    level1.cloud2rec.X -= 10;
                    level1.cloud3rec.X -= 10;
                    level1.piperec.X -= 10;
                    level1.medpiperec.X -= 10;
                    level1.bigpiperec.X -= 10;
                    level1.start -= 10;
                    level1.flagrec.X -= 10;

                    if (level1.rightgo == false)
                    {
                        for (int i = 0; i < level1.groundblocks.Count; i++)
                        {
                            level1.groundblocks[i] -= 10;
                        }
                    }
                }
                if (level1.start > 0)
                {
                    level1.marioxspeed = 10;
                    level1.rightgo = true;
                }
            }
            if (direction == "Left" && level1.mariorec.X > 0)
            {
                level1.mariorec.X -= level1.marioxspeed;

                if (level1.start < 0)
                {
                    if (level1.rightgo == false)
                    {
                        for (int i = 0; i < level1.groundblocks.Count; i++)
                        {
                            level1.groundblocks[i] += 10;
                        }
                    }
                    level1.marioxspeed = 0;
                    level1.bighillrec.X += 10;
                    level1.smallhillrec.X += 10;
                    level1.bush1rec.X += 10;
                    level1.bush2rec.X += 10;
                    level1.bush3rec.X += 10;
                    level1.cloud1rec.X += 10;
                    level1.cloud2rec.X += 10;
                    level1.cloud3rec.X += 10;
                    level1.piperec.X += 10;
                    level1.medpiperec.X += 10;
                    level1.bigpiperec.X += 10;
                    level1.start += 10;
                    level1.flagrec.X += 10;
                }
                else
                {
                    level1.marioxspeed = 10;
                }
            }
            if (direction == "up")
            {
                if (level1.isJumping == false)
                {
                    level1.velocityY = 10.0f;
                    level1.positionY -= level1.velocityY;
                    level1.mariorec.Y -= Convert.ToInt32(level1.velocityY);
                    level1.isJumping = true;
                }
                while (level1.isJumping == true) // Simulate until the character reaches the ground
                {
                    // Update character's position and velocity
                    level1.positionY -= level1.velocityY * level1.deltaTime; // Update position based on velocity
                    level1.velocityY -= level1.gravity * level1.deltaTime; // Apply gravity to velocity
                    level1.mariorec.Y -= Convert.ToInt32(level1.positionY);

                    // Check if the character has landed
                    if (level1.positionY <= 0)
                    {
                        // Reset character's position and velocity
                        level1.positionY = 0;
                        level1.velocityY = 0;
                        level1.isJumping = false;
                        break;
                    }
                }
            }
            if (direction == "Duck")
            {
                // future project
            }
        }

    }
}
