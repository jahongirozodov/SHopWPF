using ForJob.Domain.Shops;
using ForJob.Service.DTOs.Shops;
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

namespace ForJob.App.Components.Shops;

/// <summary>
/// Interaction logic for ShopsViewUserControl.xaml
/// </summary>
public partial class ShopsViewUserControl : UserControl
{
    public ShopsViewUserControl()
    {
        InitializeComponent();
    }

    public void SetData(ShopResultDto shop)
    {
        lbName.Content = shop.Name;
        tbdescription.Text = shop.Description;
    }
}
