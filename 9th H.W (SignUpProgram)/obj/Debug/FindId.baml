   M S B A M L   `   `   `  ����F  BHu_s_SignUp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:Hu_s_SignUpHu_s_SignUp  5   	       Hu_s_SignUp.FindId   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:Hu_s_SignUp     5   	   -   5          � Title$  아이디 찾기��5   	   $	��300��6   $	��300��6%    � 
ResizeMode$ NoResize=�6J   .��5	      �  � RowDefinitions 5
   
   �� 5      $��5 �6   �� 5      $
��0.8* �6   �� 5      $��30 �6   �� 5      $
��0.5* �6   �� 5      $
��0.6* �6    � ColumnDefinitions 5   
   �� 5      �� 5      $��2* �6   �� 5      .+�5   
   �� -   5        $��title��5      $��아이디 찾기��6   $��3��6.   $��1��6B   $��Center=�6O   $��Center=�6l   $
��Bold"�6�   $��30(�6�   �� 5   
   -   5        $��answer��5      $$��이메일을 입력하세요 !��6   $��1��65   $��2��6E   $��Center=�6R   $��Center=�6o   �� 5   
   -   5        $��emailTextBox��5      $��3��6&   $��3��6:   $��Center=�6G   $��Center=�6d   $	��150��6   $��25��6�   6�   �� 5   
   -   5        $��emailButton��5      $��전송��6$   $��2��61   $��3��6A   $��Center=�6N   $��Center=�6k   $��35��6�   $��30��6�   6�   � 5   
   -   5        $��confirmPanel��5      $��3��6#   $��4��67   $y�Hidden=�6D   .+�5      �� $��인증번호��6   $��60��6#   $��30��6.   $��10,8,223.6,22.8q�6:   �� 5      -   5        $��ConfirmTextBox��5      $��Right=�6,   $	��100��6H   $��0,20,118.6,29.4q�6T   6m   �� 5      -   5        $��checkNumberButton��5      $��확인��6.   $��40��6;   $��30��6F   $��
180,18,0,0q�6R    J� RenderTransformOrigin$ 
0.81,0.446&�6f   $
��Left=�6�   $	��Top=�6�   6�   �� 5       -	   5        $��
timerLabel��5       $
��3:00��6&   $��30��65   $��40��6A   $��235,10,18.6,15.2q�6L   
���  ��6f   5!      5#      5$      