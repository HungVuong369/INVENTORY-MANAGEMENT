   M S B A M L   `   `   `  ����N  JHungVuong_WPF_C4_B1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:HungVuong_WPF_C4_B1HungVuong_WPF_C4_B1  5      )    #HungVuong_WPF_C4_B1.ucViewInventory   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      3local!clr-namespace:HungVuong_WPF_C4_B1     5      ���#ECF0F1  � 	Resources  5
      4   .HungVuong_WPF_C4_B1.IndexDataGridItemConverter 	  index �� 
TargetType �� Property �� Value �� 
TargetType �� Triggers :� RoutedEvent	 �� To g� Duration	 �� TargetProperty
 P� Property P� Value � ColumnDefinitions �� TextAlignment��%�  &	        '��        5   
   6+   �� 5   
   " ��6   .�5      ��  � ��
 �����6+   �� 5       � ��
 �����6+   �� 5       � ��$ Center=�62   �� 5       � ��$ Center=�6;   �� 5       � ��$ 30��6'   �� 5       � ��$	 120��6&   �� 5       � �� 5      �� 5      " ��6&    5      :� 5      $ 
MouseEnter��6+   .[�5   "   �� .��5   &   �� .��5   *   �� $
 TealX�69   $ 0:0:0.2D�6C   $*	 $(Background).(SolidColorBrush.Color)�6V   �� 5   *   $ WhiteX�69   $ 0:0:0.2D�6D   $6	 0(TextElement.Foreground).(SolidColorBrush.Color)�6W   5   '   5   #   5       P� 5"      
 �@J�IsMouseOver . . �5#   "   ��  � ��
 �����6?   �� 5$   "    � ��
 ��� �6?   5%      P� 5(      
 �@��
IsSelected . . �5)   "   ��  � ��
 ��� �6?   �� 5*   "    � ��$ SemiBold"�6?   �� 5+   "    � ��
 �����6?   5,      .R�5/      �� #��z��50      #��z��51      ._�52      �  53   "   �� 54   &   $
��Auto �67   .+�58   "   �� $��0��63   $	��115��59   3   $ Center=�5:   +   #��z��5;   +   #��z��5<   +   5=      5>      5?      5A      5B      5C      .��5D      �  � RowDefinitions 5E   
   �� 5F      $
��auto �6   6,   �� 5G      $
��auto �6   6,   �� 5H      $��* �6   6)   .+�5K   
   �� $��Xem kho��6   $��Center=�5L      $��20(�5M      $��SemiBold"�5N      $��0��5O      6   �� 5Q   
   -   5        $��lbFeaturare��5Q      $��1��5R      $��10q�5S      ���#F2F2F2���#CCCCCC��5V      �� 5W      .R�5X      �  � Orientation$ 
Horizontal=�6    5Y      .@�5[      �� $��
Kho nhập��6   
 � Tag$ ImportInventory��5\      $��35��5]      6(   �� 5^      $��
Kho xuất��6   $ ExportInventory��5_      $��35��5`      6(   �� 5a      $��Chi tiết kho nhập��6   $ DetailImportInventory��5b      $��35��5c      6(   �� 5d      $��Chi tiết kho xuất��6   $��35��5e      $ DetailExportInventory��5f      6<   5g      &   System.Windows.Controls.DataGrid  5i   
   -   5          Name$ dgInventory��5i      $��3��6(   $��10q�65      AutoGenerateColumns .     AlternatingRowBackground �#F2F2F2   SelectionMode$ Single=�5j   6      
IsReadOnly .    Columns 5k      0  *System.Windows.Controls.DataGridTextColumn  5l      ,  &System.Windows.Controls.DataGridColumn   Header$	 STT��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 5m      �� 5n       �� 	Converter# [  5o   *    �� RelativeSource 5n   "   ��  �� Mode$ FindAncestor=� �� AncestorType)  #System.Windows.Controls.DataGridRow"  5o   *   5q        5r      $ Mã sản phẩm��6%    6:   �� *Id+  5s      $ Tên sản phẩm��6%    6;   �� *Name+  5t      $ Nhà cung cấp��6%    6;   �� *
Producer+  5u      $ Số lượng��6%    67   �� *
Quantity+   ElementStyle 5v      �� 5w      " ��6    .�5x      ��  � ��$ Right=�6D   �� 5y       � ��$ 5q�67   5z      5|      5      5�      5�      