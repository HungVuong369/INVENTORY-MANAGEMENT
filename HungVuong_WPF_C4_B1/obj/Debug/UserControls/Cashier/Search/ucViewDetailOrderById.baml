   M S B A M L   `   `   `  ����N  JHungVuong_WPF_C4_B1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:HungVuong_WPF_C4_B1HungVuong_WPF_C4_B1  5      /    )HungVuong_WPF_C4_B1.ucViewDetailOrderById   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      3local!clr-namespace:HungVuong_WPF_C4_B1     5      -   5        ���#ECF0F1  � 	Resources  5      #   HungVuong_WPF_C4_B1.Converter   	converter��%   &	          5   
   6   5      .��5      �  � RowDefinitions 5   
   �� 5      $
��auto �6   6,   �� 5      $
��auto �6   6,   �� 5      6   .+�5   
   �� $%��Xem phiếu bán hàng theo mã��6   $��Center=�5      $��20(�5      $��SemiBold"�5      $��0��5      6   �� 5   
   $��1��6   $��10q�6"   .+�5      �� $��
Nhập mã��6   $��16(�6&   66   � 5       � ColumnDefinitions 5      �� 5       $��* �6'   63   �� 5!      $��* �6'   63   .+�5$      �� -   5        $��txtInput��5$      $��0��5%      $��0 0 5 0q�5&      $��5q�5'      6U   �� 5)      -   5        $��btnView��5)      $	��Xem��6(   $��1��5+      6+   5,      5-      &   System.Windows.Controls.DataGrid  5/   
   -   5          Name$ dgOrder��5/      $��3��6$   $��10q�61      AutoGenerateColumns .     AlternatingRowBackground �#F2F2F2   SelectionMode$ Single=�50   6      
IsReadOnly .    Columns 51      0  *System.Windows.Controls.DataGridTextColumn  52      ,  &System.Windows.Controls.DataGridColumn	   Header$		 STT��6%   
   Width5  /System.Windows.Controls.DataGridLengthConverter$
 45 6L   1  +System.Windows.Controls.DataGridBoundColumn   Binding 62   �� *Index+6L     53      $	 Người tạo��6%   $	
 100 6U    68   �� *
Username+6U     54      $		 Mã��6%   $
 45 6H    61   �� *Id+6H     55      $	 Tên sản phẩm��6%   $	
 200 6T    6;   �� *Name+6T     56      $	 Nhà sản xuất��6%   $	
 100 6X    6;   �� *
Producer+6X     57      $	 Giá nhập��6%   $	
 100 6|    67   �� *
PriceInput+ �� 	Converter# [  6|     58      $	 	Giá bán��6%   $	
 100 6|    66   �� *PriceOutput+# [  6|     59      $	 Số lượng��6%   $	
 100 6T    67   �� *
Quantity+   ElementStyle 5:      �� 5;       �� 
TargetType" ��6    .�5<      ��  �� Property � �� �� Value$ Right=�6D   �� 5=       � ��$ 5q�67   5>      5@        5A      $	 Số tiền��6%   $	
 100 6v    66   �� *Total+# [  6v     5B      $	 Ngày tạo��6%   $	
 100 6U    67   �� *	CreatedAt+6U   5D      5E      5F      