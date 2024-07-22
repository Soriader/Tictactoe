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
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public bool IsPlayer1Turn { get; set; }
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
			IsPlayer1Turn = true;
			Counter = 0;

			if (Player1Win == 3 || Player2Win == 3)
			{
				Player1Win = 0;
				Player2Win = 0;
				Draw = 0;
			}


			Button_0_0.Content = string.Empty;
			Button_1_0.Content = string.Empty;
			Button_2_0.Content = string.Empty;
			Button_0_1.Content = string.Empty;
			Button_1_1.Content = string.Empty;
			Button_2_1.Content = string.Empty;
			Button_0_2.Content = string.Empty;
			Button_1_2.Content = string.Empty;
			Button_2_2.Content = string.Empty;

			Player1.Content = "Player 1 score: " +Player1Win;
			DrawTheGame.Content = "Draw: " + Draw;
			Player2.Content = "Player 2 score: " + Player2Win;

			Button_0_0.Background = Brushes.White;
			Button_1_0.Background = Brushes.White;
			Button_2_0.Background = Brushes.White;
			Button_0_1.Background = Brushes.White;
			Button_1_1.Background = Brushes.White;
			Button_2_1.Background = Brushes.White;
			Button_0_2.Background = Brushes.White;
			Button_1_2.Background = Brushes.White;
			Button_2_2.Background = Brushes.White;
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			if (!(sender is Button button) || !string.IsNullOrEmpty(button.Content.ToString()))
				return;

			button.Content = IsPlayer1Turn ? "O" : "X";
			Counter++;

			if (CheckIfPlayerWon())
			{
				if (IsPlayer1Turn)
				{
					Player1Win++;
					if(Player1Win == 3)
					{
						Player1.Content = "Player 1 win!";
					}
				}
				else
				{
					Player2Win++;
					if (Player2Win == 3)
					{
						Player2.Content = "Player 2 win!";
					}
				}

				Counter = 9;

				Dispatcher.Invoke(async () =>
				{
					await Task.Delay(2000);
					NewGame();
				});

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

				Dispatcher.Invoke(async () =>
				{
					await Task.Delay(2000);
					NewGame();
				});
			}
			else
			{
				IsPlayer1Turn ^= true;
			}

		}

		private bool CheckIfPlayerWon()
		{
			if (Button_0_0.Content == Button_0_1.Content && Button_0_1.Content == Button_0_2.Content && Button_0_0.Content != string.Empty)
			{
				Button_0_0.Background = Brushes.Green;
				Button_0_1.Background = Brushes.Green;
				Button_0_2.Background = Brushes.Green;
				return true;
			}
			if (Button_1_0.Content == Button_1_1.Content && Button_1_1.Content == Button_1_2.Content && Button_1_0.Content != string.Empty)
			{
				Button_1_0.Background = Brushes.Green;
				Button_1_1.Background = Brushes.Green;
				Button_1_2.Background = Brushes.Green;
				return true;
			}
			if (Button_2_0.Content == Button_2_1.Content && Button_2_1.Content == Button_2_2.Content && Button_2_0.Content != string.Empty)
			{
				Button_2_0.Background = Brushes.Green;
				Button_2_1.Background = Brushes.Green;
				Button_2_2.Background = Brushes.Green;
				return true;
			}

			if (Button_0_0.Content == Button_1_0.Content && Button_1_0.Content == Button_2_0.Content && Button_0_0.Content != string.Empty)
			{
				Button_0_0.Background = Brushes.Green;
				Button_1_0.Background = Brushes.Green;
				Button_2_0.Background = Brushes.Green;
				return true;
			}
			if (Button_0_1.Content == Button_1_1.Content && Button_1_1.Content == Button_2_1.Content && Button_0_1.Content != string.Empty)
			{
				Button_0_1.Background = Brushes.Green;
				Button_1_1.Background = Brushes.Green;
				Button_2_1.Background = Brushes.Green;
				return true;
			}
			if (Button_0_2.Content == Button_1_2.Content && Button_1_2.Content == Button_2_2.Content && Button_0_2.Content != string.Empty)
			{
				Button_0_2.Background = Brushes.Green;
				Button_1_2.Background = Brushes.Green;
				Button_2_2.Background = Brushes.Green;
				return true;
			}

			if (Button_0_0.Content == Button_1_1.Content && Button_1_1.Content == Button_2_2.Content && Button_0_0.Content != string.Empty)
			{
				Button_0_0.Background = Brushes.Green;
				Button_1_1.Background = Brushes.Green;
				Button_2_2.Background = Brushes.Green;
				return true;
			}
			if (Button_0_2.Content == Button_1_1.Content && Button_1_1.Content == Button_2_0.Content && Button_0_2.Content != string.Empty)
			{
				Button_0_2.Background = Brushes.Green;
				Button_1_1.Background = Brushes.Green;
				Button_2_0.Background = Brushes.Green;
				return true;
			}

			return false;

		}
	} 
} 

