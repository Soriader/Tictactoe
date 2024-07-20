using System;
using System.Collections.Generic;
using System.Linq;
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
		public bool IsPlayer1Turn { get; set; } = true;
		public MainWindow()
		{
			InitializeComponent();
			NewGame();
		}

		public void NewGame()
		{

		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			IsPlayer1Turn ^= true;

			var button = sender as Button;

			button.Content = IsPlayer1Turn ? "O": "X";

		}
	}
}
