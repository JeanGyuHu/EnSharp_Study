   M S B A M L   `   `   `  ����N  JHu_s_WindowExplorer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:Hu_s_WindowExplorerHu_s_WindowExplorer  5           Hu_s_WindowExplorer.TopBar   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      3local!clr-namespace:Hu_s_WindowExplorer     5      .��5
      � -   5        $��mainGrid��5
        � ColumnDefinitions  5   
   �� 5      $��40 �6   �� 5      $��40 �6   �� 5      $��40 �6   �� 5      $��40 �6   �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5       � RowDefinitions 5   
   �� 5      $��30 �6   �� 5      $��30 �6   .+�5!   
   �� $��파일��6   $��0��6   $��0��6-   $��Center=�6:   $��Center=�6W   �� 5"   
   $	��홈��6   $��1��6   $��0��6,   $��Center=�69   $��Center=�6V   �� 5#   
   $��공유��6   $��2��6   $��0��6-   $��Center=�6:   $��Center=�6W   �� 5$   
   $��보기��6   $��3��6   $��0��6-   $��Center=�6:   $��Center=�6W   �� 5&   
   -   5        $��
backButton��5&      $��0��6#   $��1��63   $��Center=�6@   $��Center=�6]   $��0q�6x   .��5'      �� $��Images\Back.PNG��6   5(      �� 5)   
   -   5        $��forwardButton��5)      $��1��6&   $��1��66   $��Center=�6C   $��Center=�6`   $��0q�6{   .��5*      �� $��Images\for.PNG��6   5+      �� 5,   
   -   5        $��parentButton��5,      $��2��6%   $��1��65   $��Center=�6B   $��Center=�6_   $��0q�6z   .��5-      �� $��Images\parent.PNG��6   5.      �� 5/   
   $��주소��6   $��3��6   $��1��6-   $
��Left=�6:   $��Center=�6U   �� 50   
   -   5        $��pathTextBox��50      $��4��6%   $��25��65   $	��650��6A   $��10��6M   $��1��6b   $
��Left=�6o   $��Center=�6�   6�   51      52      