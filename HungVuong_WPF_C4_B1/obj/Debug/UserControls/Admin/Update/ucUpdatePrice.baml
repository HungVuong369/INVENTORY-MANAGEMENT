   M S B A M L   `   `   `  ����N  JHungVuong_WPF_C4_B1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:HungVuong_WPF_C4_B1HungVuong_WPF_C4_B1  5      '    !HungVuong_WPF_C4_B1.ucUpdatePrice   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      3local!clr-namespace:HungVuong_WPF_C4_B1     5      ���#ECF0F1  � 	Resources  5
      #   HungVuong_WPF_C4_B1.Converter   	converter4   .HungVuong_WPF_C4_B1.IndexDataGridItemConverter 	 index �� 
TargetType �� Property �� Value �� 
TargetType �� Triggers :� RoutedEvent	 �� To g� Duration	 �� TargetProperty
 P� Property P� Value � ColumnDefinitions �� TextAlignment��%�  &	        &	      '�� &       5   
   6     5   
   6+   �� 5   
   " ��6   .�5      ��  � ��
 �����6+   �� 5       � ��
 �����6+   �� 5       � ��$ Center=�62   �� 5       � ��$ Center=�6;   �� 5       � ��$ 30��6'   �� 5       � ��$	 120��6&   �� 5       � �� 5      �� 5      " ��6&    5      :� 5      $ 
MouseEnter��6+   .[�5   "   �� .��5   &   �� .��5   *   �� $
 TealX�69   $ 0:0:0.2D�6C   $*	 $(Background).(SolidColorBrush.Color)�6V   �� 5   *   $ WhiteX�69   $ 0:0:0.2D�6D   $6	 0(TextElement.Foreground).(SolidColorBrush.Color)�6W   5   '   5    #   5!      P� 5#      
 �@J�IsMouseOver . . �5$   "   ��  � ��
 �����6?   �� 5%   "    � ��
 ��� �6?   5&      P� 5)      
 �@��
IsSelected . . �5*   "   ��  � ��
 ��� �6?   �� 5+   "    � ��$ SemiBold"�6?   �� 5,   "    � ��
 �����6?   5-      .R�50      �� #��z��51      #��z��52      ._�53      �  54   "   �� 55   &   $
��Auto �67   .+�59   "   �� $��0��63   $	��115��5:   3   $ Center=�5;   +   #��z��5<   +   #��z��5=   +   5>      5?      5@      5B      5C      5D      .��5F      �  � RowDefinitions 5G   
   �� 5H      $
��auto �6   6,   �� 5I      $
��auto �6   6,   �� 5J      $
��auto �6   6,   �� 5K      $
��auto �6   6,   .+�5N   
   �� $��0��6   $��Cập nhật giá��5O      $��Center=�5P      $��20(�5Q      $��SemiBold"�5R      6(   �� 5T   
   -   5        $��lstCategories��5T      $��1��5U      $��20 0 0 0q�5V      ���#F2F2F2���#CCCCCC��5Y      �� 5Z      .R�5[      �  � Orientation$ 
Horizontal=�6    5\      ��5^      �� 5_      .R�5`      ��  �� Padding$ 10q�61   ��6    �� 61   5a      5c      �� 5e   
   $��2��6   .+�5f      �� $$��Vui lòng chọn sản phẩm!��6   $��20 10 10 10q�66   6M   &   System.Windows.Controls.DataGrid  5g      -   5          Name$ 
dgProducts��5g      $��20 10 10 10q�6+      AutoGenerateColumns .     AlternatingRowBackground �#F2F2F2   SelectionMode$ Single=�5h   2      
IsReadOnly .    Columns 5j      0  *System.Windows.Controls.DataGridTextColumn  5k      ,  &System.Windows.Controls.DataGridColumn   Header$	 STT��6)   1  +System.Windows.Controls.DataGridBoundColumn   Binding 5l      �� 5m       �� 	Converter# [ 5n   *    �� RelativeSource 5m   &   ��  �� Mode$ FindAncestor=� �� AncestorType)  #System.Windows.Controls.DataGridRow"  5n   *   5p        5q      $	 Mã��6)      Width5  /System.Windows.Controls.DataGridLengthConverter$ 45 6L    65   �� *Id+6L     5r      $
 Tên��6)   $	 200 6O    66   �� *Name+6O     5s      $ Nhà sản xuất��6)   $	 100 6\    6?   �� *
Producer+6\     5t      $ Giá nhập��6)   $	 100 6�    6;   �� *
PriceInput+# [  6�     5u      $ 	Giá bán��6)   $	 100 6�    6:   �� *PriceOutput+# [  6�   5w      5x      �� 5z   
   -   5        $��spUpdatePrice��5z   "   $��3��6   $��10q�67   .+�5{      �� $��Giá nhập: ��6   $��18(�6*   $��SemiBold"�68   6P   �� 5}      -   5        $��txtPriceInput��5}      $��30��6+   $��18(�5~      $
��0 10q�5      {�.  .��5�   (   5�      �� 5�      -   5        $��btnUpdatePrice��5�      $��Cập nhật��6+   $��18(�6>   {�.  5�   )   5�      5�      5�      