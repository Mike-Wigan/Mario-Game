using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace Mario_Game
{
    public partial class level1 : UserControl
    {
        SolidBrush redbrush = new SolidBrush(Color.Red);
        #region declaring stuff
        Stopwatch movewatch = new Stopwatch();
        Stopwatch jumpwatch = new Stopwatch();

        public static bool wdown = false;
        public static bool sdown = false;
        public static bool adown = false;
        public static bool ddown = false;
        public static bool rdown = false;
        public static bool updown = false;
        public static bool downdown = false;
        public static bool rightdown = false;
        public static bool leftdown = false;
        public static bool onflag = false;
        public static bool afterflag = false;
        public static bool rightdirection = true;
        public static bool rightgo = true;
        public static bool isJumping = false;
        public static bool intercetion = true;

        Image groundimage = Properties.Resources.groundblock;
        Image marioImage = Properties.Resources.mario_still;
        Image bighill = Properties.Resources.big_hill;
        Image smallhill = Properties.Resources.small_hill;
        Image bush1 = Properties.Resources._1_light_bush;
        Image bush2 = Properties.Resources._2_light_bush;
        Image bush3 = Properties.Resources.light_green_thing;
        Image smallpipe = Properties.Resources.pipe;
        Image medpipe = Properties.Resources.medpipe;
        Image bigpipe = Properties.Resources.bigpipe;
        Image cloud1 = Properties.Resources.smallcloud;
        Image cloud2 = Properties.Resources.bigcloud;
        Image cloud3 = Properties.Resources.cloud3;
        Image flag = Properties.Resources.flag;

        public static Rectangle mariorec = new Rectangle(1, 440, 96, 80);
        public static Rectangle mariotop = new Rectangle(0, 439, 97, 1);
        public static Rectangle mariobottom = new Rectangle(0, 520, 97, 1);
        public static Rectangle marioleft = new Rectangle(0, 440, 1, 80);
        public static Rectangle marioright = new Rectangle(97, 440, 1, 80);
        public static Rectangle groundrec = new Rectangle(/*-195*/0, 520, 39, 60);
        public static Rectangle bighillrec = new Rectangle(500, 420, 300, 100);
        public static Rectangle smallhillrec = new Rectangle(1200, 470, 152, 50);
        public static Rectangle bush1rec = new Rectangle(1600, 470, 110, 50);
        public static Rectangle bush2rec = new Rectangle(2400, 470, 150, 50);
        public static Rectangle bush3rec = new Rectangle(1000, 470, 208, 50);
        public static Rectangle cloud1rec = new Rectangle(1500, 80, 110, 50);
        public static Rectangle cloud2rec = new Rectangle(2200, 100, 150, 50);
        public static Rectangle cloud3rec = new Rectangle(600, 110, 208, 70);
        public static Rectangle piperec = new Rectangle(1850, 420, 98, 113);
        public static Rectangle medpiperec = new Rectangle(2200, 349, 98, 178);
        public static Rectangle bigpiperec = new Rectangle(2600, 302, 98, 251);
        public static Rectangle pipetop = new Rectangle(0, 0, 0, 0);
        public static Rectangle medpipetop = new Rectangle(0, 0, 0, 0);
        public static Rectangle bigpipetop = new Rectangle();
        public static Rectangle flagrec = new Rectangle(3000, 120, 34, 400);

        public static List<float> groundblocks = new List<float>();

        public static int sizeX;
        public static int sizeY;
        public static int marioyspeed = 10;
        public static int marioxspeed = 10;
        public static int start = 0;

        mario Mario = new mario();
        ground floor = new ground();

        public static float velocityY = 0;
        public static float gravity = 9.81f;
        public static float deltaTime = 0.01f;
        public static float positionY = 0;
#endregion
        public level1()
        {
            InitializeComponent();
            InitalizeGame();
        }
        private void InitalizeGame()
        {
            marioImage = Properties.Resources.mario_still;
            Mario = new mario();
            floor = new ground();

            this.BackColor = Color.CornflowerBlue;
            this.Location = new Point(0, 0);

            this.Size = Screen.PrimaryScreen.WorkingArea.Size;
            groundrec.Y = this.Height - groundrec.Height;
            mariorec.Y = this.Height - groundrec.Height - mariorec.Height;
            smallhillrec.Y = this.Height - groundrec.Height - bush1rec.Height;
            bighillrec.Y = this.Height - groundrec.Height - bighillrec.Height;
            bush1rec.Y = this.Height - groundrec.Height - bush1rec.Height;
            bush2rec.Y = this.Height - groundrec.Height - bush2rec.Height;
            bush3rec.Y = this.Height - groundrec.Height - bush3rec.Height;
            piperec.Y = this.Height - groundrec.Height - piperec.Height;
            medpiperec.Y = this.Height - groundrec.Height - medpiperec.Height;
            bigpiperec.Y = this.Height - groundrec.Height - bigpiperec.Height;
            flagrec.Y = this.Height - groundrec.Height - flagrec.Height;
            sizeX = this.Size.Width;
            sizeY = this.Size.Height;
            marioright.X = mariorec.X + mariorec.Width;


            floor.generate();
        }
        private void level1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                    if (isJumping == false)
                    {
                        wdown = true;
                        marioyspeed = 10;
                        jumpwatch.Start();
                        isJumping = true;
                    }
                    break;
                case Keys.S:
                    sdown = true;
                    break;
                case Keys.D:
                    ddown = true;
                    break;
                case Keys.A:
                    adown = true;
                    break;
                case Keys.Up:
                    if (isJumping == false)
                    {
                        wdown = true;
                        marioyspeed = 8;
                        jumpwatch.Start();
                        isJumping = true;
                    }
                    break;
                case Keys.Down:
                    sdown = true;
                    break;
                case Keys.Right:
                    ddown = true;
                    break;
                case Keys.Left:
                    adown = true;
                    break;
            }
        }
        private void level1_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                    wdown = false;
                    break;
                case Keys.S:
                    sdown = false;
                    break;
                case Keys.D:
                    ddown = false;
                    break;
                case Keys.A:
                    adown = false;
                    break;
                case Keys.Up:
                    wdown = false;
                    break;
                case Keys.Down:
                    sdown = false;
                    break;
                case Keys.Right:
                    ddown = false;
                    break;
                case Keys.Left:
                    adown = false;
                    break;
            }
        }
        private void level1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(groundimage, groundrec);
            e.Graphics.DrawImage(bighill, bighillrec);
            e.Graphics.DrawImage(smallhill, smallhillrec);
            e.Graphics.DrawImage(bush1, bush1rec);
            e.Graphics.DrawImage(bush2, bush2rec);
            e.Graphics.DrawImage(bush3, bush3rec);
            e.Graphics.DrawImage(cloud1, cloud1rec);
            e.Graphics.DrawImage(cloud2, cloud2rec);
            e.Graphics.DrawImage(cloud3, cloud3rec);
            e.Graphics.DrawImage(smallpipe, piperec);
            e.Graphics.DrawImage(medpipe, medpiperec);
            e.Graphics.DrawImage(bigpipe, bigpiperec);
            e.Graphics.DrawImage(flag, flagrec);  
            e.Graphics.DrawImage(marioImage, mariorec);
            e.Graphics.FillRectangle(redbrush, marioright);
            e.Graphics.FillRectangle(redbrush, mariotop);
            e.Graphics.FillRectangle(redbrush, mariobottom);
            e.Graphics.FillRectangle(redbrush, marioleft);

            for (int i = 0; i < groundblocks.Count; i++)
            {
                e.Graphics.DrawImage(groundimage, groundblocks[i], groundrec.Y, groundrec.Width, groundrec.Height);
            }
        }
        private void GameTimer_Tick(object sender, EventArgs e)
        {
            label1.Text = $"{isJumping}";
            label2.Text = $"{mariorec.Y + mariorec.Height}";
            marioleft.X = mariorec.X;
            marioright.X = mariorec.X;
            mariotop.X = mariorec.X;
            mariobottom.X = mariorec.X;

            #region move right
            if (ddown == true)
            {
                rightdirection = true; // to set resting direction
                                       // moving animation
                movewatch.Start();
                if (movewatch.ElapsedMilliseconds >= 0)
                {
                    marioImage = Properties.Resources.mario_running_4;
                }
                if (movewatch.ElapsedMilliseconds >= 150)
                {
                    marioImage = Properties.Resources.mario_runnning_3;
                }
                if (movewatch.ElapsedMilliseconds >= 300)
                {
                    marioImage = Properties.Resources.mario_running_2;
                }
                if (movewatch.ElapsedMilliseconds >= 450)
                {
                    marioImage = Properties.Resources.mario_running_4;
                    movewatch.Reset();
                    movewatch.Stop();
                }
                //getting code from mario class
                Mario.Move("Right");
            }
            else
            {
                if (rightdirection == true)
                {
                    marioImage = Properties.Resources.mario_still;
                }
            }
            #endregion

            #region Move Left
            if (adown == true)
            {
                rightdirection = false;
                Mario.Move("Left");

                movewatch.Start();
                if (movewatch.ElapsedMilliseconds >= 0)
                {
                    marioImage = Properties.Resources.mario_running_4_left;
                }
                if (movewatch.ElapsedMilliseconds >= 150)
                {
                    marioImage = Properties.Resources.mario_runnning_3_left;
                }
                if (movewatch.ElapsedMilliseconds >= 300)
                {
                    marioImage = Properties.Resources.mario_running_2_left;
                }
                if (movewatch.ElapsedMilliseconds >= 450)
                {
                    marioImage = Properties.Resources.mario_running_4_left;
                    movewatch.Reset();
                    movewatch.Stop();
                }
            }
            else if (rightdirection == false)
            {
                marioImage = Properties.Resources.mario_still_left;
            }
            #endregion

            #region Jump
            //if (wdown == true)
            //{
            //    Mario.Move("up");
            //}
            if (wdown == true || isJumping == true && jumpwatch.IsRunning == true)
            {
                if (onflag == false && afterflag == false)
                {
                    marioImage = Properties.Resources.mario_jumping;
                    mariorec.Y -= marioyspeed;
                    if (rightdirection == false)
                    {
                        marioImage = Properties.Resources.mario_jumping_left;
                    }
                    else
                    {
                        marioImage = Properties.Resources.mario_jumping;
                    }
                }
                mariorec.Y -= marioyspeed;
                isJumping = true;
                if (jumpwatch.ElapsedMilliseconds >= 200)
                {
                    marioyspeed = 6;
                }
                if (jumpwatch.ElapsedMilliseconds >= 300)
                {
                    marioyspeed = 4;
                }
                if (jumpwatch.ElapsedMilliseconds >= 400)
                {
                    marioyspeed = 2;
                }
                if (jumpwatch.ElapsedMilliseconds >= 500)
                {
                    marioyspeed = 0;
                }
                if (jumpwatch.ElapsedMilliseconds >= 600)
                {
                    marioyspeed = -3;
                }
                if (jumpwatch.ElapsedMilliseconds >= 700)
                {
                    marioyspeed = -6;
                }
                if (jumpwatch.ElapsedMilliseconds >= 800)
                {
                    marioyspeed = -9;
                }
                if (jumpwatch.ElapsedMilliseconds >= 900)
                {
                    marioyspeed = -15;
                }
                if (jumpwatch.ElapsedMilliseconds >= 1000)
                {
                    if (rightdirection == false)
                    {
                        marioImage = Properties.Resources.mario_still_left;
                    }
                    else
                    {
                        marioImage = Properties.Resources.mario_still;
                    }
                }
            }
            if (isJumping == false)
            {
                marioyspeed = 10;
            }
            // make jumping work when holding the jump button
            if (isJumping == true)
            {
                if (marioyspeed == 0 && jumpwatch.IsRunning == false)
                {
                    isJumping = false;
                }
            }
            #endregion

            #region intercetions
            if (mariorec.Y >= groundrec.Y - mariorec.Height && isJumping == true)
            {
                mariorec.Y = groundrec.Y - mariorec.Height - 2;
                marioyspeed = 0;
                isJumping = false;
                jumpwatch.Reset();
                jumpwatch.Stop();
            }
            if (marioright.IntersectsWith(piperec) || marioright.IntersectsWith(medpiperec) || marioright.IntersectsWith(bigpiperec))
            {
                marioxspeed = 0;
            }
            #endregion

            Refresh();
        }
    }
}