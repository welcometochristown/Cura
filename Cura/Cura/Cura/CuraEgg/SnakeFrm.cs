using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Cura.CuraEgg
{
    public partial class SnakeFrm : Form
    {
        #region Fields
        private Snake snake;
        private System.Timers.Timer timer;

        private Food foodpiece;

        private int score;
        #endregion

        #region Constructor
        public SnakeFrm()
        {
            InitializeComponent();

            this.score = 0;

            snake = new Snake(10) { Direction = SnakePart.PartDirection.UP, Position = new Point(50, 50) };

            foodpiece = new Food() { x = 100, y = 100, color = Color.Red };

            timer = new System.Timers.Timer(50);

            timer.Elapsed += timer_Elapsed;
    
        }
        #endregion

        public void ResetGame()
        {
            score = 0;

            snake.Reset();

            snake.Position = new Point(50, 50);
        }

        #region Timer
        void timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {

            //first check for collision
            if(snake.parts.Count > 2)
            {
                    for(int i = 2; i < snake.parts.Count; i++)
                    {
                        SnakePart part = snake.parts[i];

                        if(part.GetRectangle().IntersectsWith(snake.FirstPart.GetRectangle()))
                        {
                            timer.Stop();

                            MessageBox.Show("Aww Too Bad. Game Over");

                            ResetGame();
                    
                            toolStripStatusLabel1.Text = "";

                            return;
                        }
                    }

            }
           
            //check for direction change first
            if (snake.Direction != newDirection)
                snake.ChangeDirection(newDirection);


            if (new Rectangle(foodpiece.x, foodpiece.y, 5, 5).IntersectsWith(snake.FirstPart.GetRectangle()))
            {
                snake.FirstPart.color = foodpiece.color;


                Random r = new Random(DateTime.Now.Millisecond);

                foodpiece.x = 10 + (r.Next() % (this.ClientRectangle.Width - 20));
                foodpiece.y = 10 + (r.Next() % (this.ClientRectangle.Height - 50));

                foodpiece.color = Color.FromArgb(r.Next() % 200, r.Next() % 200, r.Next() % 200);

                snake.LastPart.Length += 1;
             

                score++;

                toolStripStatusLabel1.Text = "Score : " + score.ToString();
            }


            //move the snake
            snake.MoveSnake();

            this.Invalidate();

            //for (int i = 0; i < snake.parts.Count; i++ )
            //{
            //    SnakePart part =  snake.parts[i];
            //    Console.WriteLine("Part [" + i.ToString() + "] \r\n" + new Point(part.x, part.y).ToString() + " Length : " + part.Length.ToString() + ", Direction : " + part.Direction.ToString() + "\r\n");
            //}
        }
        #endregion

        #region Paint
        private void Snake_Paint(object sender, PaintEventArgs e)
        {
            foodpiece.Draw(e.Graphics);
            snake.Draw(e.Graphics);
        }
        #endregion

        #region IO
        private SnakePart.PartDirection newDirection;

        private void SnakeFrm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Up && e.KeyCode != Keys.Down && e.KeyCode != Keys.Left && e.KeyCode != Keys.Right)
                return;

            timer.Start();

            if (e.KeyCode == Keys.Up && snake.Direction != SnakePart.PartDirection.DOWN)
                newDirection = SnakePart.PartDirection.UP;
            else if (e.KeyCode == Keys.Down && snake.Direction != SnakePart.PartDirection.UP)
                newDirection = SnakePart.PartDirection.DOWN;
            else if (e.KeyCode == Keys.Left && snake.Direction != SnakePart.PartDirection.RIGHT)
                newDirection = SnakePart.PartDirection.LEFT;
            else if (e.KeyCode == Keys.Right && snake.Direction != SnakePart.PartDirection.LEFT)
                newDirection = SnakePart.PartDirection.RIGHT;
        }
        #endregion
       
    }

    public class Snake
    {
        #region Fields
        public List<SnakePart> parts;

        public int startsize;
        #endregion

        #region Properties
        public SnakePart FirstPart
        {
            get
            {
                return parts[0];
            }
        }

        public SnakePart LastPart
        {
            get
            {
                return parts[parts.Count - 1];
            }
        }

        public SnakePart.PartDirection Direction
        {
            get
            {
                return FirstPart.Direction;
            }
            set
            {
                FirstPart.Direction = value;
            }
        }

        public Point Position
        {
            get
            {
                return new Point(FirstPart.x, FirstPart.y);
            }
            set
            {
                FirstPart.x = value.X;
                FirstPart.y = value.Y;
            }
        }


        #endregion

        #region Constructor
        public Snake(int initial_size)
        {
           this.startsize = initial_size;

            Reset();
        }

        #endregion

        public void Reset()
        {
            if (parts == null)
                this.parts = new List<SnakePart>();
            else
                this.parts.Clear();

            this.parts.Add(new SnakePart() { Length = startsize, color = Color.Black });
        }

        public void ChangeDirection(SnakePart.PartDirection newDirection)
        {
            if (newDirection == Direction)
                return;

            SnakePart newpart = new SnakePart() { Direction = newDirection, x = FirstPart.x , y = FirstPart.y, color = FirstPart.color };

            if (Direction == SnakePart.PartDirection.RIGHT && newpart.Direction == SnakePart.PartDirection.UP)
            {
                newpart.MoveSnakePartBack();
            }
            else if (Direction == SnakePart.PartDirection.DOWN && newpart.Direction == SnakePart.PartDirection.LEFT)
            {
                newpart.MoveSnakePartBack();
            }              

            parts.Insert(0, newpart);
        }

        public void MoveSnake()
        {
            //change how the snake looks given the new direction.
            if (parts.Count == 1)
            {

                FirstPart.MoveSnakePart();
            }
            else if (parts.Count > 1)
            {
                //shrink the end of the last part
                LastPart.Length -= 1;

                //increase the length of the first one
                FirstPart.Length += 1;

                if (LastPart.Length == 0)
                    parts.Remove(LastPart);

                FirstPart.MoveSnakePart();

            }

        }

        #region Drawing
        public void Draw(Graphics g)
        {
            foreach (SnakePart part in parts)
            {
                part.Draw(g);
            }
        }
        #endregion
        
    }

    public class SnakePart
    {
        #region Fields
        private const int partSize = 5;

        public int x, y;
        private int _length;

        public PartDirection Direction;

        public Color color;
        #endregion

        #region Properties
        public int Length
        {
            get
            {
                return _length;
            }
            set
            {
                _length = value;
            }
        }
        #endregion

        #region Enum
        public enum PartDirection
        {
            UP, DOWN, LEFT, RIGHT
        }
        #endregion

        #region Move Snake Part
        public void MoveSnakePart()
        {
            switch (Direction)
            {
                case PartDirection.LEFT:
                    x -= 1*partSize; break;
                case PartDirection.RIGHT:
                    x += 1*partSize; break;
                case PartDirection.UP:
                    y -= 1*partSize; break;
                case PartDirection.DOWN:
                    y += 1*partSize; break;

            }
        }

        public void MoveSnakePartBack()
        {
            switch (Direction)
            {
                case PartDirection.LEFT:
                    x += 1 * partSize; break;
                case PartDirection.RIGHT:
                    x -= 1 * partSize; break;
                case PartDirection.UP:
                    y += 1 * partSize; break;
                case PartDirection.DOWN:
                    y -= 1 * partSize; break;

            }
        }

        #endregion
      
        public void Draw(Graphics g)
        {
            System.Drawing.SolidBrush myBrush = new System.Drawing.SolidBrush(color);

            Rectangle rect = GetRectangle();

            g.FillRectangle(myBrush, rect);
        }

        public Rectangle GetRectangle()
        {
            int nx = x;
            int ny = y;

            int w = Direction == PartDirection.LEFT || Direction == PartDirection.RIGHT ? Length : 0;
            int h = Direction == PartDirection.UP || Direction == PartDirection.DOWN ? Length : 0;

            w = w == 0 ? 1 : w;
            h = h == 0 ? 1 : h;

            if (Direction == PartDirection.RIGHT)
            {
                nx -= w * partSize;
            }

            if (Direction == PartDirection.DOWN)
            {
                ny -= h * partSize;
            }

            return new Rectangle(nx, ny, partSize * w, partSize * h);
        }
    }

    public class Food
    {
        public int x, y;
        public Color color;
        public void Draw(Graphics g)
        {
            System.Drawing.SolidBrush myBrush = new System.Drawing.SolidBrush(color);

            g.FillRectangle(myBrush, x, y, 5, 5);
        }
    }
}
