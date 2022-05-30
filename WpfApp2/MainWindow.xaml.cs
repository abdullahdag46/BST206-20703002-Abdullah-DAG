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

namespace WpfApp2
{
    /// <summary>
    /// MainWindow.xaml etkileşim mantığı
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        productdal _productdal = new productdal();
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            urunlerigetir();
        }

        private void urunlerigetir()
        {
            _productdal.UrunleriGetir();
        }

        private void btnekle_Click(object sender, RoutedEventArgs e)
        {
            _productdal.Ekle(new product
            {
                Name=txtProductName.Text;
                Fiyat =Convert.ToDecimal(txtfiyat.Text),
                Stok =Convert.ToInt32(txtstok.Text)
            });
        urunlerigetir();
        }
    private void Dtgproducts_SelectionChanged(object sender, SelectedCellsChangedEventArgs e)
    {
        product product = new product();
       product=(product) dtgproducts.SekectionItem;
        grd1.DataContext=product;
    }
    }
}
