   M S B A M L   `   `   `  ����N  JHungVuong_WPF_C4_B1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:HungVuong_WPF_C4_B1HungVuong_WPF_C4_B1  5      -    'HungVuong_WPF_C4_B1.ucViewDetailInvoice   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      3local!clr-namespace:HungVuong_WPF_C4_B1     5      ���#ECF0F1  � 	Resources  5
      #   HungVuong_WPF_C4_B1.Converter   	converter��%   &	          5   
   6   5      .��5      � $��10q�6    � RowDefinitions 5   
   �� 5      $
��auto �6   6,   �� 5      $
��auto �6   6,   �� 5      $
��auto �6   6,   �� 5      $��* �6   6)   .+�5   
   �� $'��!Xem chi tiết phiếu xuất kho��6   $��Center=�5      $��20(�5      $��SemiBold"�5      $��0��5      6   �� 5   
   -   5        $��	cbFeature��5      $��1��6$    �� SelectedIndex$ 0��61   $��10q�5      .@�5      �� $��Theo mã��6   
 � Tag$ Id��6-   68   �� 5       $��
Theo ngày��6   $
 Date��6/   6<   5!      � 5#   
   $��2��6   $��10q�6    � ColumnDefinitions 5$      �� 5%      6%   �� 5&      6%   .+�5)      (  "System.Windows.Controls.DatePicker  -   5        $��
DatePicker��5)      $��0��6+   $y�	Collapsed=�6;     5*      :  4System.Windows.Controls.Primitives.DatePickerTextBox �� 
TargetType �� Property �� Value �� Path	 �� StringFormat
 �� RelativeSource �� AncestorType��%�   '        �� 5+      "  6   .�5,      ��  � �� 5-      �� 5.   "   .R�5/   &   �� {�.  ��6@   �� $ SelectedDate�$	 
dd/MM/yyyy��
 �� "  52   #   54      55      56      57      �� 58      -   5        $��txtInput��58      $y�Visible=�6&   $��0��6;   $��0 0 5 0q�6K   $��5q�59      6$   �� 5:      -   5        $��btnView��5:      $	��Xem��6$   $��1��5<      6'   5=      &   System.Windows.Controls.DataGrid  5?   
   -   5          Name$ dgDetailInvoice��5?      $��3��6,   $��10q�69      AutoGenerateColumns .     AlternatingRowBackground �#F2F2F2   SelectionMode$ Single=�5@   6      
IsReadOnly .    Columns 5A      0  *System.Windows.Controls.DataGridTextColumn  5B      ,  &System.Windows.Controls.DataGridColumn   Header$	 STT��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ 45 6L   1  +System.Windows.Controls.DataGridBoundColumn   Binding 62   �� *Index+6L     5C      $ Người tạo��6%   $	 100 6U    68   �� *
Username+6U     5D      $	 Mã��6%   $ 45 6H    61   �� *Id+6H     5E      $ Tên sản phẩm��6%   $	 200 6T    6;   �� *Name+6T     5F      $ Nhà sản xuất��6%   $	 100 6X    6;   �� *
Producer+6X     5G      $ Giá nhập��6%   $	 100 6|    67   �� *
PriceInput+ �� 	Converter# [  6|     5H      $ 	Giá bán��6%   $	 100 6|    66   �� *PriceOutput+# [  6|     5I      $ Số lượng��6%   $	 100 6T    67   �� *
Quantity+   ElementStyle 5J      �� 5K      " ��6    .�5L      ��  � ��$ Right=�6D   �� 5M       � ��$ 5q�67   5N      5P        5Q      $ Tổng tiền��6%   $	 100 6x    68   �� *Total+# [  6x     5R      $ Ngày tạo��6%   $	 100 6U    67   �� *	CreatedAt+6U   5T      5U      5V      