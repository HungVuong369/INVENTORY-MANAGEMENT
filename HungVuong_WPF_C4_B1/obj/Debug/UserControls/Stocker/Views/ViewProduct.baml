   M S B A M L   `   `   `  ����N  JHungVuong_WPF_C4_B1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:HungVuong_WPF_C4_B1HungVuong_WPF_C4_B1  5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35`Dclr-namespace:System.Windows.Controls;assembly=PresentationFrameworkSystem.Windows.Controls 5
      N;clr-namespace:System.Windows;assembly=PresentationFrameworkSystem.Windows 5      %    HungVuong_WPF_C4_B1.ViewProduct   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      3local!clr-namespace:HungVuong_WPF_C4_B1     5      YDataGridDclr-namespace:System.Windows.Controls;assembly=PresentationFramework     5
      MStyle;clr-namespace:System.Windows;assembly=PresentationFramework     5      ���#ECF0F1  � 	Resources  5      #   HungVuong_WPF_C4_B1.Converter   	converter4   .HungVuong_WPF_C4_B1.IndexDataGridItemConverter  indexDataGridItemConverter �� 
TargetType �� Property �� Value �� 
TargetType �� Triggers :� RoutedEvent	 �� To g� Duration	 �� TargetProperty
 P� Property P� Value � ColumnDefinitions �� TextAlignment��%�  &	        &	      '�� &       5   
   6     5   
   6+   �� 5   
   " ��6   .�5      ��  � ��
 �����6+   �� 5       � ��
 �����6+   �� 5       � ��$ Center=�62   �� 5       � ��$
 Left=�6;   �� 5       � ��$ 30��6'   �� 5       � ��$	 150��6&   �� 5       � �� 5      �� 5      " ��6&    5      :� 5      $ 
MouseEnter��6+   .[�5   "   �� .��5    &   �� .��5!   *   �� $
 TealX�69   $ 0:0:0.2D�6C   $*	 $(Background).(SolidColorBrush.Color)�6V   �� 5"   *   $ WhiteX�69   $ 0:0:0.2D�6D   $6	 0(TextElement.Foreground).(SolidColorBrush.Color)�6W   5#   '   5$   #   5%      P� 5'      
 �@J�IsMouseOver . . �5(   "   ��  � ��
 �����6?   �� 5)   "    � ��
 ��� �6?   5*      P� 5-      
 �@��
IsSelected . . �5.   "   ��  � ��
 ��� �6?   �� 5/   "    � ��$ SemiBold"�6?   �� 50   "    � ��
 �����6?   51      .R�54      �� #��z��55      #��z��56      ._�57      � #��z��6#    58   "   �� 59   &   $��50 �67   �� 5;   &   .+�5?   "   �� $��1��63   $
 Left=�5@   +   #��z��5A   +   #��z��5B   +   5C      5D      5E      5G      5H      5I      .��5K      �  � RowDefinitions 5L   
   �� 5M      $
��Auto �6   �� 5N      $��* �6   .+�5Q   
   �� $��0��6   $��10q�6"   .+�5R      �� $��Xem sản phẩm��6   $��Center=�5S      $��20(�5T      $��SemiBold"�5U      6,   �� 5W      -   5        $��lstCategories��5W      $��10q�6+   ���#F2F2F2���#CCCCCC��5X      �� 5Y      .R�5Z      �  � Orientation$ 
Horizontal=�6$   5[      ��5]      �� 5^      .R�5_      ��  �� Padding$ 10q�65   ��6$   �� 65   5`      5b      &   System.Windows.Controls.DataGrid  5d      -   5          Name$ 
dgProducts��5d      $��1��6+   $��10q�68      AutoGenerateColumns .     AlternatingRowBackground �#F2F2F2   SelectionMode$ Single=�5e   6      
IsReadOnly .    Columns 5g      0  *System.Windows.Controls.DataGridTextColumn  5h      ,  &System.Windows.Controls.DataGridColumn   Header$	 STT��6)   1  +System.Windows.Controls.DataGridBoundColumn   Binding 5i      �� 5j       �� 	Converter# [ 5k   *    �� RelativeSource 5j   &   ��  �� Mode$ FindAncestor=� �� AncestorType)  #System.Windows.Controls.DataGridRow"  5k   *   5m        5n      $	 Mã��6)      Width5  /System.Windows.Controls.DataGridLengthConverter$ 45 6L    65   �� *Id+6L     5o      $
 Tên��6)   $	 200 6O    66   �� *Name+6O     5p      $ Nhà sản xuất��6)   $	 100 6\    6?   �� *
Producer+6\     5q      $ Giá nhập��6)    6;   �� *
PriceInput+# [    5r      $ 	Giá bán��6)    6:   �� *PriceOutput+# [  5t      5u      5v      5w      