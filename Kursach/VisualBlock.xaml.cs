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

namespace Kursach
{
    /// <summary>
    /// Interaction logic for VisualBlock.xaml
    /// </summary>
    public partial class VisualBlock : UserControl
    {
        private Point _positionInBlock;
        private string textInput;
        public bool buttonFromIsPressed = false;
        public bool buttonToIsPressed = false;

        public VisualBlock(string textInput)
        {
            InitializeComponent();
            this.textInput = textInput;

            TextBlock txtBlock = new TextBlock();
            txtBlock.Text = textInput;
            txtBlock.FontSize = 20;
            txtBlock.HorizontalAlignment = HorizontalAlignment.Center;
            txtBlock.VerticalAlignment = VerticalAlignment.Center;
            VB.Children.Add(txtBlock);

            Button buttonFrom = new Button();
            buttonFrom.FontSize = 10;
            buttonFrom.Content = "From";
            buttonFrom.Name = textInput+"_From";
            buttonFrom.Height = 30;
            buttonFrom.Width = 30;
            buttonFrom.Margin = new Thickness(0, 0, 70, 0);
            VB.Children.Add(buttonFrom);
            buttonFrom.Click += new RoutedEventHandler(buttonFrom_click);

            Button buttonTo = new Button();
            buttonTo.Content = "To";
            buttonTo.Name = textInput+"_To";
            buttonTo.Height = 30;
            buttonTo.Width = 30;
            buttonTo.Margin = new Thickness(70, 0, 0, 0);
            VB.Children.Add(buttonTo);
            buttonTo.Click += new RoutedEventHandler(buttonTo_click);
        }

        private void buttonFrom_click(object sender, RoutedEventArgs e)
        {
            buttonFromIsPressed = true;
        }

        private void buttonTo_click(object sender, RoutedEventArgs e)
        {
            buttonToIsPressed = true;
        }

        private void UserControl_MouseDown(object sender, MouseButtonEventArgs e)
        {
            _positionInBlock = Mouse.GetPosition(this);
        }

        private void UserControl_MouseMove(object sender, MouseEventArgs e)
        {
            if (IsMouseCaptured)
            {
                // get the parent container
                var container = (UIElement)VisualTreeHelper.GetParent(this);

                // get the position within the container
                var mousePosition = e.GetPosition(container);

                // move the usercontrol.
                RenderTransform = new TranslateTransform(mousePosition.X - _positionInBlock.X, mousePosition.Y - _positionInBlock.Y);
            }
        }

        private void UserControl_MouseUp(object sender, MouseButtonEventArgs e)
        {
            ReleaseMouseCapture();
        }
    }
}