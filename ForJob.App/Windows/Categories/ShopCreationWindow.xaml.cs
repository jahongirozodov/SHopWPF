using ForJob.Domain.Shops;
using ForJob.Service.DTOs.Shops;
using ForJob.Service.Services;
using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;

namespace ForJob.App.Windows.Categories;

/// <summary>
/// Interaction logic for CategoryCreationWindow.xaml
/// </summary>
public partial class ShopCreationWindow : Window
{
    private readonly ShopService shopService;
    public static bool IsCreated { get;set;}
    public ShopCreationWindow()
    {
        this.shopService = new();

        InitializeComponent();
    }
    
    private async void AddButton_Click(object sender, RoutedEventArgs e)
    {
        if(string.IsNullOrEmpty(tbName.Text))
        {
            MessageBox.Show("Name kitilishi majburiy!");
            return;
        }

        string savedUserId = Application.Current.Properties["UserId"].ToString();

        var shopCreationDto = new ShopCreationDto
        {
            UserId = long.Parse(savedUserId),
            Name = tbName.Text,
            Description =  new TextRange(rtbDesctiprion.Document.ContentStart, rtbDesctiprion.Document.ContentEnd).Text
        };

        try{
            var result = await shopService.CreateAsync(shopCreationDto);
            IsCreated = true;
            this.Close();
        }
        catch(Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }
}
