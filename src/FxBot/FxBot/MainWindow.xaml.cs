using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FxBot
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
		}

		private void AddMovingAverage_CanExecute(object sender, CanExecuteRoutedEventArgs e)
		{
			e.CanExecute = true;
		}

		private void AddMovingAverage_Executed(object sender, ExecutedRoutedEventArgs e)
		{
			AddMovingAverageWindow window = new AddMovingAverageWindow();
			window.ShowDialog();
		}
	}

	public static class MyCommands
	{
		static MyCommands()
		{
			AddMovingAverage = new RoutedUICommand("Add Moving Average", "AddMovingAverage", typeof(MyCommands));
		}

		public static RoutedUICommand AddMovingAverage
		{
			get;
			private set;
		}
	}

}
