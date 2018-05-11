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

namespace ImageSearch
{
    /// <summary>
    /// 확대된 화면을 표시하기 위한 창
    /// </summary>
    public partial class PictureDialog : Window
    {
        public PictureDialog()
        {
            InitializeComponent();
        }
        
        public void SetImage(Image image)
        {
            Image img = image;
            bigImage.Source = img.Source;
        }
    }
}
