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
using System.Windows.Shapes;

namespace FxBot
{
	/// <summary>
	/// Interaction logic for AddMovingAverageWindow.xaml
	/// </summary>
	public partial class AddMovingAverageWindow : Window
	{
		private MovingAverageObject _maObject;
		public AddMovingAverageWindow()
		{
			InitializeComponent();
			_maObject = new MovingAverageObject();
			DataContext = _maObject;
		}
	}
}
