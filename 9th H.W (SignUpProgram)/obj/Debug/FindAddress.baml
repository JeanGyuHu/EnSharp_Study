   M S B A M L   `   `   `  ����F  BHu_s_SignUp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:Hu_s_SignUpHu_s_SignUp  5   	       Hu_s_SignUp.FindAddress   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:Hu_s_SignUp     5   	     � Title$  FindAddress��5   	   $	��400��6   $	��400��6*    � 
ResizeMode$ NoResize=�66   .��5	      �  � ColumnDefinitions 5
   
   �� 5      �� 5      �� 5      �� 5       � RowDefinitions 5   
   �� 5      $��45 �6   �� 5      $��45 �6   �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      .+�5   
   �� $&�� 주소 검색(ex. 능동로 209)��6   $��4��6-   $��20(�6A   $
��Bold"�6O   �� 5   
   $��주소 입력��6   $��0��6    $��1��60   $��Center=�6=   �� 5   
   -   5        $��addressInputTextBox��5      $��1��6-   $��2��6=   $��1��6Q   $��Center=�6^   $��25��6y   6�   �� 5   
   -   5        $��searchButton��5      $��검색��6%   $��3��62   $��1��6B   $��Center=�6O   $��Center=�6j   $��25��6�   $��40��6�   6�   �� 5   
   $��2��6   $��5��6$   $��4��65   $��Hidden=�6I   .��5       �� -   5        $��listBox��5       5"      5#      �� 5$   
   -   5        $��	endButton��5$      $��선택 완료��6"   $��7��62   $��1��6?   $��2��6O   6}   5%      5&      