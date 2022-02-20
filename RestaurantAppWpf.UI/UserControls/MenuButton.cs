using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace RestaurantAppWpf.UI.UserControls
{
    public class MenuButton : RadioButton
    {
        public ImageSource Image
        {
            get { return (ImageSource)GetValue(ImageProperty); }
            set { SetValue(ImageProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Image.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ImageProperty =
            DependencyProperty.Register("Image", typeof(ImageSource), typeof(MenuButton), new PropertyMetadata(null));


    }
}
