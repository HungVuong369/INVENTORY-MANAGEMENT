   M S B A M L   `   `   `  ����N  JHungVuong_WPF_C4_B1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:HungVuong_WPF_C4_B1HungVuong_WPF_C4_B1  5      /    )HungVuong_WPF_C4_B1.ucCustomerInformation   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      3local!clr-namespace:HungVuong_WPF_C4_B1     5        � 	Resources  5	      1   +HungVuong_WPF_C4_B1.ConvertPointsToCardType   pointToCardID��%   &	          5
   
   6(   5      .��5      �  � RowDefinitions 5   
   �� 5      $
��auto �6   6,   �� 5      $
��auto �6   6,   �� 5      $
��auto �6   6,   �� 5      $
��auto �6   6,   �� 5      $
��auto �6   6,   �� 5      $
��auto �6   6,   .+�5   
   �� $��Thông tin khách hàng��6   $��Center=�5      $��20(�5      $��SemiBold"�5      $��0��5      6   �� 5   
   $��1��6    �� Orientation$ 
Horizontal=�6"   .+�5      �� $��Tên khách hàng: ��6   $��16(�60   6@   �� 5      $��16(�6.   ��6   �� *Name+6>   5      �� 5!   
   $��2��6   $ 
Horizontal=�6"   .+�5"      �� $��Số điện thoại: ��6   $��16(�6/   6?   �� 5#      $��16(�6/   ��6   �� *Phone+6?   5$      �� 5%   
   $��3��6   $ 
Horizontal=�6"   .+�5&      �� $��Mã khách hàng: ��6   $��16(�6/   6?   �� 5'      $��16(�60   ��6   �� *CardID+6@   5(      �� 5)   
   $��4��6   $ 
Horizontal=�6"   .+�5*      �� $��Số điểm: ��6   $��16(�6)   69   �� 5+      $��16(�60   ��6   �� *Points+6@   5,      �� 5-   
   $��5��6   $ 
Horizontal=�6"   .+�5.      �� $��Loại thẻ: ��6   $��16(�6*   6:   �� 5/      $��16(�6Z   ��6   �� *Points+ �� 	Converter# [  6j   50      51      52      