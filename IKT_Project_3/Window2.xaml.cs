using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace IKT_Project_3
{
    public partial class Window2 : Window
    {
        public int size = MainWindow.size;
        private Button[,] buttons;
        private bool isPlayerX = true;
        private bool isGameEnded = false;

        public Window2()
        {
            InitializeComponent();
            Generate();
        }

        private void Generate()
        {
            buttons = new Button[size, size];
            Game.RowDefinitions.Clear();
            Game.ColumnDefinitions.Clear();
            Game.Children.Clear();

            for (int i = 0; i < size; i++)
            {
                Game.RowDefinitions.Add(new RowDefinition());
            }
            for (int i = 0; i < size; i++)
            {
                Game.ColumnDefinitions.Add(new ColumnDefinition());
            }

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    Button btn = new Button();
                    btn.Background = new SolidColorBrush(Colors.DarkGray);
                    btn.FontSize = 24;
                    btn.Click += Button_Click;
                    buttons[i, j] = btn;
                    Grid.SetRow(btn, i);
                    Grid.SetColumn(btn, j);
                    Game.Children.Add(btn);
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (isGameEnded)
                return;

            Button btn = sender as Button;
            int row = Grid.GetRow(btn);
            int col = Grid.GetColumn(btn);

            if (buttons[row, col].Content != null)
                return;

            if (isPlayerX)
                buttons[row, col].Content = "X"; 
            else
                buttons[row, col].Content = "O";
            isPlayerX = !isPlayerX; 

            if (Winner("X"))
            {
                MessageBox.Show("Player X wins!");
                isGameEnded = true;
                Hide();
            }
            else if (Winner("O"))
            {
                MessageBox.Show("Player O wins!");
                isGameEnded = true;
                Hide();
            }
            else if (Draw())
            {
                MessageBox.Show("It's a draw!");
                isGameEnded = true;
                Hide();
            }
        }

        private bool Winner(string player)
        {
           switch (size)
            {
                case 3:
                    for (int i = 0; i < size; i++)
                    {
                        if (buttons[i, 0].Content == player && buttons[i, 1].Content == player && buttons[i, 2].Content == player)
                            return true;
                    }

                    for (int i = 0; i < size; i++)
                    {
                        if (buttons[0, i].Content == player && buttons[1, i].Content == player && buttons[2, i].Content == player)
                            return true;
                    }


                    if (buttons[0, 0].Content == player && buttons[1, 1].Content == player && buttons[2, 2].Content == player)
                        return true;
                    if (buttons[0, 2].Content == player && buttons[1, 1].Content == player && buttons[2, 0].Content == player)
                        return true;
                    break;

                case 4:
                    for (int i = 0; i < size; i++)
                    {
                        if (buttons[i, 0].Content == player && buttons[i, 1].Content == player && buttons[i, 2].Content == player && buttons[i, 3].Content == player)
                            return true;
                    }

                    for (int i = 0; i < size; i++)
                    {
                        if (buttons[0, i].Content == player && buttons[1, i].Content == player && buttons[2, i].Content == player && buttons[3, i].Content == player)
                            return true;
                    }


                    if (buttons[0, 0].Content == player && buttons[1, 1].Content == player && buttons[2, 2].Content == player && buttons[3, 3].Content == player)
                        return true;
                    if (buttons[0, 3].Content == player && buttons[1, 2].Content == player && buttons[2, 1].Content == player && buttons[3, 0].Content == player)
                        return true;
                    break;

                case 5:
                    for (int i = 0; i < size; i++)
                    {
                        if (buttons[i, 0].Content == player && buttons[i, 1].Content == player && buttons[i, 2].Content == player && buttons[i, 3].Content == player && buttons[i, 4].Content == player)
                            return true;
                    }

                    for (int i = 0; i < size; i++)
                    {
                        if (buttons[0, i].Content == player && buttons[1, i].Content == player && buttons[2, i].Content == player && buttons[3, i].Content == player && buttons[4, i].Content == player)
                            return true;
                    }


                    if (buttons[0, 0].Content == player && buttons[1, 1].Content == player && buttons[2, 2].Content == player && buttons[3, 3].Content == player && buttons[4, 4].Content == player)
                        return true;
                    if (buttons[0, 4].Content == player && buttons[1, 3].Content == player && buttons[2, 2].Content == player && buttons[3, 1].Content == player && buttons[4, 0].Content == player)
                        return true;
                    break;
            }
                return false;
            
        }
        private bool Draw()
        {
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (buttons[i, j].Content == null)
                        return false;
                }
            }
            return true;
        }
    }
}
