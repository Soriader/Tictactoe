using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Tictactoe
{
	public partial class MainWindow : Window
	{
		public bool IsPlayer1Turn { get; set; }
		public bool LastPlayer1Turn { get; set; }
		public int Counter { get; set; }
		public int Player1Win { get; set; }
		public int Player2Win { get; set; }
		public int Draw { get; set; }

		public MainWindow()
		{
			InitializeComponent();
			NewGame();
		}

		public void NewGame()
		{
			IsPlayer1Turn = !LastPlayer1Turn; 
			Counter = 0;

			if (Player1Win == 3 || Player2Win == 3)
			{
				Player1Win = 0;
				Player2Win = 0;
				Draw = 0;
			}

			foreach (Button btn in new[] { Button_0_0, Button_1_0, Button_2_0, Button_0_1, Button_1_1, Button_2_1, Button_0_2, Button_1_2, Button_2_2 })
			{
				btn.Content = string.Empty;
				btn.Tag = null; 
				btn.Background = Brushes.White;
			}

			Player1.Content = "Player 1 score: " + Player1Win;
			DrawTheGame.Content = "Draw: " + Draw;
			Player2.Content = "Player 2 score: " + Player2Win;
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			if (!(sender is Button button) || button.Tag != null)
				return;

			string imageName = IsPlayer1Turn ? "O" : "X";

			button.Content = new Image
			{
				Source = new BitmapImage(new Uri($"C:/Users/ROG/source/repos/Tictactoe/Tictactoe/Photos/{imageName}.png", UriKind.Absolute))
			};

			button.Tag = imageName; 

			IsPlayer1Turn = !IsPlayer1Turn;
			LastPlayer1Turn = IsPlayer1Turn; 

			Counter++;

			if (CheckIfPlayerWon())
			{
				if (!IsPlayer1Turn)
				{
					Player1Win++;
					Player1.Content = "Player 1 score a point!";

					if (Player1Win == 3)
					{
						Player1.Content = "Player 1 win!";
					}
				}
				else
				{
					Player2Win++;
					Player2.Content = "Player 2 score a point!";

					if (Player2Win == 3)
					{
						Player2.Content = "Player 2 win!";
					}
				}

				Counter = 9;

				PleaseLate();
			}
			else if (Counter == 9)
			{
				Draw++;
				Button_0_0.Background = Brushes.Yellow;
				Button_1_0.Background = Brushes.Yellow;
				Button_2_0.Background = Brushes.Yellow;
				Button_0_1.Background = Brushes.Yellow;
				Button_1_1.Background = Brushes.Yellow;
				Button_2_1.Background = Brushes.Yellow;
				Button_0_2.Background = Brushes.Yellow;
				Button_1_2.Background = Brushes.Yellow;
				Button_2_2.Background = Brushes.Yellow;

				PleaseLate();
			}
		}

		private void PleaseLate()
		{
			Dispatcher.Invoke(async () =>
			{
				await Task.Delay(2000);
				NewGame();
			});
		}
		private bool CheckIfPlayerWon()
		{
			if (CheckLine(Button_0_0, Button_0_1, Button_0_2) ||
				CheckLine(Button_1_0, Button_1_1, Button_1_2) ||
				CheckLine(Button_2_0, Button_2_1, Button_2_2) ||
				CheckLine(Button_0_0, Button_1_0, Button_2_0) ||
				CheckLine(Button_0_1, Button_1_1, Button_2_1) ||
				CheckLine(Button_0_2, Button_1_2, Button_2_2) ||
				CheckLine(Button_0_0, Button_1_1, Button_2_2) ||
				CheckLine(Button_0_2, Button_1_1, Button_2_0))
			{
				return true;
			}
			return false;
		}

		private bool CheckLine(Button b1, Button b2, Button b3)
		{
			string tag1 = b1.Tag as string;
			string tag2 = b2.Tag as string;
			string tag3 = b3.Tag as string;

			if (!string.IsNullOrEmpty(tag1) && tag1 == tag2 && tag2 == tag3)
			{
				b1.Background = Brushes.Green;
				b2.Background = Brushes.Green;
				b3.Background = Brushes.Green;
				return true;
			}
			return false;
		}
	} 
} 

