using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace SnakeGame
{
    public partial class Form1 : Form
    {
        private const int CellSize = 14;

        private readonly List<Point> snake = new List<Point>();
        private readonly Random random = new Random();
        private readonly System.Windows.Forms.Timer gameTimer = new System.Windows.Forms.Timer();

        private Point food;
        private Direction direction = Direction.Right;
        private bool gameStarted;
        private bool gameOver;
        private int score;

        private enum Direction
        {
            Up,
            Down,
            Left,
            Right
        }

        public Form1()
        {
            InitializeComponent();

            gameTimer.Interval = 130;
            gameTimer.Tick += GameTimer_Tick;

            panelGame.Paint += PanelGame_Paint;
            KeyPreview = true;
            KeyDown += Form1_KeyDown;

            ResetGame();
        }

        private void ResetGame()
        {
            gameTimer.Stop();
            snake.Clear();

            int middleX = (panelGame.ClientSize.Width / CellSize) / 2;
            int middleY = (panelGame.ClientSize.Height / CellSize) / 2;

            snake.Add(new Point(middleX, middleY));
            snake.Add(new Point(middleX - 1, middleY));
            snake.Add(new Point(middleX - 2, middleY));

            direction = Direction.Right;
            score = 0;
            gameStarted = false;
            gameOver = false;

            lblScore.Text = "Xal:    0";
            CreateFood();
            panelGame.Invalidate();
        }

        private void CreateFood()
        {
            int columns = Math.Max(1, panelGame.ClientSize.Width / CellSize);
            int rows = Math.Max(1, panelGame.ClientSize.Height / CellSize);

            do
            {
                food = new Point(random.Next(columns), random.Next(rows));
            }
            while (snake.Contains(food));
        }

        private void StartOrChangeDirection(Direction newDirection)
        {
            if (gameOver)
            {
                ResetGame();
                direction = newDirection;
                gameStarted = true;
                gameTimer.Start();
                return;
            }

            if (!gameStarted)
            {
                direction = newDirection;
                gameStarted = true;
                gameTimer.Start();
                return;
            }

            if (!IsOpposite(direction, newDirection))
                direction = newDirection;
        }

        private bool IsOpposite(Direction current, Direction next)
        {
            return (current == Direction.Up && next == Direction.Down) ||
                   (current == Direction.Down && next == Direction.Up) ||
                   (current == Direction.Left && next == Direction.Right) ||
                   (current == Direction.Right && next == Direction.Left);
        }

        private void GameTimer_Tick(object? sender, EventArgs e)
        {
            Point newHead = snake[0];

            switch (direction)
            {
                case Direction.Up:
                    newHead.Y--;
                    break;
                case Direction.Down:
                    newHead.Y++;
                    break;
                case Direction.Left:
                    newHead.X--;
                    break;
                case Direction.Right:
                    newHead.X++;
                    break;
            }

            int columns = panelGame.ClientSize.Width / CellSize;
            int rows = panelGame.ClientSize.Height / CellSize;

            if (newHead.X < 0 || newHead.Y < 0 ||
                newHead.X >= columns || newHead.Y >= rows)
            {
                EndGame();
                return;
            }

            bool eatingFood = newHead == food;

            // The last cell moves away on this turn unless food is eaten.
            int bodyLengthToCheck = eatingFood ? snake.Count : snake.Count - 1;
            for (int i = 0; i < bodyLengthToCheck; i++)
            {
                if (snake[i] == newHead)
                {
                    EndGame();
                    return;
                }
            }

            snake.Insert(0, newHead);

            if (eatingFood)
            {
                score++;
                lblScore.Text = "Xal:    " + score;
                CreateFood();
            }
            else
            {
                snake.RemoveAt(snake.Count - 1);
            }

            panelGame.Invalidate();
        }

        private void EndGame()
        {
            gameTimer.Stop();
            gameStarted = false;
            gameOver = true;
            MessageBox.Show(
                "Oyun bitdi! Yenidən başlamaq üçün ox düymələrindən birinə basın.",
                "Snake",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void PanelGame_Paint(object? sender, PaintEventArgs e)
        {
            e.Graphics.Clear(Color.White);

            using (SolidBrush snakeBrush = new SolidBrush(Color.Black))
            using (SolidBrush foodBrush = new SolidBrush(Color.Red))
            {
                e.Graphics.FillRectangle(
                    foodBrush,
                    food.X * CellSize,
                    food.Y * CellSize,
                    CellSize,
                    CellSize);

                foreach (Point part in snake)
                {
                    e.Graphics.FillRectangle(
                        snakeBrush,
                        part.X * CellSize,
                        part.Y * CellSize,
                        CellSize,
                        CellSize);
                }
            }
        }

        private void Form1_KeyDown(object? sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                    StartOrChangeDirection(Direction.Up);
                    e.Handled = true;
                    break;
                case Keys.Down:
                    StartOrChangeDirection(Direction.Down);
                    e.Handled = true;
                    break;
                case Keys.Left:
                    StartOrChangeDirection(Direction.Left);
                    e.Handled = true;
                    break;
                case Keys.Right:
                    StartOrChangeDirection(Direction.Right);
                    e.Handled = true;
                    break;
            }
        }

        private void btnUp_Click(object? sender, EventArgs e) =>
            StartOrChangeDirection(Direction.Up);

        private void btnDown_Click(object? sender, EventArgs e) =>
            StartOrChangeDirection(Direction.Down);

        private void btnLeft_Click(object? sender, EventArgs e) =>
            StartOrChangeDirection(Direction.Left);

        private void btnRight_Click(object? sender, EventArgs e) =>
            StartOrChangeDirection(Direction.Right);

        private void btnExit_Click(object? sender, EventArgs e)
        {
            gameTimer.Stop();
            Close();
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            gameTimer.Dispose();
            base.OnFormClosed(e);
        }
    }
}
