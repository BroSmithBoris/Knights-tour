using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using System.Text.RegularExpressions;

namespace Knight_s_tour
{
    public partial class Form1 : Form
    {
        // Визуализация доски
        #region
        const int pixelSize = 20;
        int BoardWidth = 0, BoardHeight = 0;
        Panel[,] BoardGrid;
        Point startPosition = new Point(-1, -1);
        Point endPosition = new Point(-1, -1);
        Board GameBoard;
        Knight Knight;
        

        public Form1()
        {

            Form message = new Form();
            var heigth = new TextBox { Location = new Point(60, 30), Name = "Heigth" , Size = new Size(50,30), Text = "Высота"};
            var width = new TextBox { Location = new Point(0, 30), Name = "Width", Size = new Size(50, 30), Text = "Ширина" };
            var button = new Button { Text = "Ok", Location = new Point(30, 80)};
            button.Click += (sender, args) =>
            {
                if (Regex.Match(width.Text, @"[0-9]").Success)
                    BoardWidth = int.Parse(width.Text, NumberStyles.Integer);
                else BoardWidth = 1;
                if (Regex.Match(heigth.Text, @"[0-9]").Success)
                    BoardHeight = int.Parse(heigth.Text, NumberStyles.Integer);
                else BoardHeight = 1;
                message.Close();
                StartProgram();
            };
            message.Controls.Add( new Label { Text = "Укажите размер доски: ", Location = new Point(0, 0) });
            message.Controls.Add(width);
            message.Controls.Add(heigth);
            message.Controls.Add(button);
            message.Size = new Size(150, 150);
            message.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            message.TopMost = true;
            message.StartPosition = FormStartPosition.CenterScreen;
            message.Show();
        }

        void StartProgram()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Normal;
            BoardGrid = new Panel[BoardWidth, BoardHeight];
            for (int i = 0; i < BoardWidth; i++)
                for(int j = 0; j < BoardHeight; j++)
                {
                    var color = Color.Wheat;

                    if (Convert.ToBoolean(i % 2) ^ Convert.ToBoolean(j % 2))
                        color = Color.Brown;
                    var panel = new Panel() { Size = new Size(pixelSize, pixelSize),
                        Location = new Point(j * pixelSize, i * pixelSize), BackColor = color };
                    panel.Click += new EventHandler(Panel_Click);
                    panel.Tag = i + ":" + j;
                    BoardGrid[i, j] = panel;
                }
            UpdateBoard();
        }

        void Panel_Click(Object sender, EventArgs args)
        {
            var panel = (Panel)sender;
            var st = panel.Tag.ToString().Split(':');
            if(startPosition == new Point(-1, -1))
            {
                panel.BackColor = Color.PaleGreen;
                startPosition = new Point (int.Parse(st[0]), int.Parse(st[1]) );
            }
            else if (endPosition == new Point(-1, -1))
            {
                panel.BackColor = Color.PaleTurquoise;
                endPosition = new Point( int.Parse(st[0]), int.Parse(st[1]) );
                KnightTour(startPosition, endPosition);
            }
            
        }

        void UpdateBoard()
        {
            this.Controls.Clear();
            foreach (var panel in BoardGrid)
                this.Controls.Add(panel);
        }
        #endregion

        

        void KnightTour(Point startPosition, Point endPosition)
        {
            Knight = new Knight(startPosition, endPosition, new Size(BoardWidth, BoardHeight));
            GameBoard = new Board(new Size(BoardWidth, BoardHeight), Knight.Direction);
            //var knigthPanel = new Panel() { 
            //    Location = BoardGrid[startPosition.X, startPosition.Y].Location, 
            //    BackColor = Color.Red,
            //    Size = BoardGrid[startPosition.X, startPosition.Y].Size};
            //this.Controls.Add(knigthPanel);
            if (MessageBox.Show("ХОД КОНЁМ!") == DialogResult.OK)
            {
                for(int i =0; i < BoardGrid.Length; i++)
                {
                    BoardGrid[Knight.Position.X, Knight.Position.Y].BackColor = Color.Red;
                    Knight.MoveNext(GameBoard);
                    MessageBox.Show("STEP" + i);
                }
            }

        }
    }
}
