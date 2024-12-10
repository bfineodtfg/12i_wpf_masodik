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

namespace _12i_wpf_masodik
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Test();
        }
        void Test()
        {
            Disz disz = new Disz() { name = "Kolbász", price = 2000, stock = 50000 };
            CreateStoreItem(disz);
            CreateStoreItem(disz);

        }
        void CreateStoreItem(Disz oneDisz)
        {
            Border oneBorder = new Border();
            oneBorder.Background = new SolidColorBrush(Colors.Beige);
            oneBorder.CornerRadius = new CornerRadius(15);
            oneBorder.Padding = new Thickness(10);
            oneBorder.Margin = new Thickness(0, 0, 5, 0);
            Store.Children.Add(oneBorder);
            Grid oneGrid = new Grid();
            oneBorder.Child = oneGrid;
            RowDefinition firstRow = new RowDefinition();
            RowDefinition secondRow = new RowDefinition();
            RowDefinition thirdRow = new RowDefinition();
            RowDefinition fourthRow = new RowDefinition();
            oneGrid.RowDefinitions.Add(firstRow);
            oneGrid.RowDefinitions.Add(secondRow);
            oneGrid.RowDefinitions.Add(thirdRow);
            oneGrid.RowDefinitions.Add(fourthRow);
            TextBlock name = new TextBlock();
            TextBlock price = new TextBlock();
            Grid count = new Grid();
            Button buyButton = new Button();
            oneGrid.Children.Add(name);
            oneGrid.Children.Add(price);
            oneGrid.Children.Add(count);
            oneGrid.Children.Add(buyButton);
            Grid.SetRow(price, 1);
            Grid.SetRow(count, 2);
            Grid.SetRow(buyButton, 3);

            TextBlock countText = new TextBlock();
            TextBox countBox = new TextBox();
            count.Children.Add(countText);
            count.Children.Add(countBox);

            ColumnDefinition gridOne = new ColumnDefinition();
            ColumnDefinition gridTwo = new ColumnDefinition();

            count.ColumnDefinitions.Add(gridOne);
            count.ColumnDefinitions.Add(gridTwo);

            Grid.SetColumn(countBox, 1);

            name.Text = "Dísz neve: " + oneDisz.name;
            price.Text = "Ár: " + oneDisz.price;
            countText.Text = "Darabszám:";
            countBox.Text = "1";
            buyButton.Content = "Vásárlás";

            buyButton.Click += (s, e) =>
            {
                CreateCartItem(oneDisz, countBox.Text);
            };

            name.TextAlignment = TextAlignment.Center;
            price.TextAlignment = TextAlignment.Center;
            countText.TextAlignment = TextAlignment.Center;
            countBox.TextAlignment = TextAlignment.Center;

            countBox.Margin = new Thickness(5, 0, 5, 5);
        }
        void CreateCartItem(Disz oneDisz, string num)
        {
            Border oneBorder = new Border();
            oneBorder.Background = new SolidColorBrush(Colors.Beige);
            oneBorder.CornerRadius = new CornerRadius(15);
            oneBorder.Padding = new Thickness(10);
            oneBorder.Margin = new Thickness(0, 0, 5, 0);
            Cart.Children.Add(oneBorder);
            Grid oneGrid = new Grid();
            oneBorder.Child = oneGrid;
            RowDefinition firstRow = new RowDefinition();
            RowDefinition secondRow = new RowDefinition();
            RowDefinition thirdRow = new RowDefinition();
            RowDefinition fourthRow = new RowDefinition();
            RowDefinition fifthRow = new RowDefinition();
            oneGrid.RowDefinitions.Add(firstRow);
            oneGrid.RowDefinitions.Add(secondRow);
            oneGrid.RowDefinitions.Add(thirdRow);
            oneGrid.RowDefinitions.Add(fourthRow);
            oneGrid.RowDefinitions.Add(fifthRow);
            TextBlock name = new TextBlock();
            TextBlock price = new TextBlock();
            Grid count = new Grid();
            Button moreButton = new Button();
            Button lessButton = new Button();
            oneGrid.Children.Add(name);
            oneGrid.Children.Add(price);
            oneGrid.Children.Add(count);
            oneGrid.Children.Add(moreButton);
            oneGrid.Children.Add(lessButton);
            Grid.SetRow(price, 1);
            Grid.SetRow(count, 2);
            Grid.SetRow(moreButton, 3);
            Grid.SetRow(lessButton, 4);

            TextBlock countText = new TextBlock();
            TextBox countBox = new TextBox();
            count.Children.Add(countText);
            count.Children.Add(countBox);

            ColumnDefinition gridOne = new ColumnDefinition();
            ColumnDefinition gridTwo = new ColumnDefinition();

            count.ColumnDefinitions.Add(gridOne);
            count.ColumnDefinitions.Add(gridTwo);

            Grid.SetColumn(countBox, 1);

            name.Text = "Dísz neve: " + oneDisz.name;
            price.Text = "Ár: " + oneDisz.price;
            countText.Text = "Darabszám:";
            countBox.Text = num;
            moreButton.Content = "Több";
            lessButton.Content = "Kevesebb";

            moreButton.Click += (s, e) =>
            {
                int currentValue = int.Parse(countBox.Text);
                currentValue++;
                countBox.Text = currentValue.ToString();
            };
            lessButton.Click += (s, e) =>
            {
                int currentValue = int.Parse(countBox.Text);
                currentValue--;
                if (currentValue < 1)
                {
                    Cart.Children.Remove(oneBorder);
                }
                countBox.Text = currentValue.ToString();
            };

            name.TextAlignment = TextAlignment.Center;
            price.TextAlignment = TextAlignment.Center;
            countText.TextAlignment = TextAlignment.Center;
            countBox.TextAlignment = TextAlignment.Center;

            countBox.Margin = new Thickness(5, 0, 5, 5);
        }
    }
}
