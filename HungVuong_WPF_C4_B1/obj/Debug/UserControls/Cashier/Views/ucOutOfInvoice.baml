   M S B A M L   `   `   `  ����N  JHungVuong_WPF_C4_B1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:HungVuong_WPF_C4_B1HungVuong_WPF_C4_B1  5      (    "HungVuong_WPF_C4_B1.ucOutOfInvoice   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      3local!clr-namespace:HungVuong_WPF_C4_B1     5      ���#ECF0F1  � 	Resources  5
      4   .HungVuong_WPF_C4_B1.IndexDataGridItemConverter 	  index��%   &	          5   
   6+   5      .��5      �  � RowDefinitions 5   
   �� 5      $
��auto �6   6,   �� 5      $
��auto �6   6,   �� 5      $��* �6   6)   .+�5   
   �� $��Liệt kê hết hàng��6   $��Center=�5      $��20(�5      $��SemiBold"�5      $��0��5      6   �� 5   
   $
��Left=�5      $��20(�5      $��1��5      $��10q�5      ��5      �� *Min+ �� StringFormat$&  Số lượng tối thiểu: {0}��5   "   &   System.Windows.Controls.DataGrid  5    
   -   5          Name$ dgOutOfInvoice��5       $��2��6+   $��10q�68      AutoGenerateColumns .     AlternatingRowBackground �#F2F2F2   SelectionMode$ Single=�5!   6      
IsReadOnly .    Columns 5#      0  *System.Windows.Controls.DataGridTextColumn  5$      ,  &System.Windows.Controls.DataGridColumn	   Header$		 STT��6%   1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 5%      �� 5&       �� 	Converter# [  5'   *    �� RelativeSource 5&   "   ��  �� Mode$ FindAncestor=� �� AncestorType)  #System.Windows.Controls.DataGridRow"  5'   *   5)        5*      $		 Mã��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ 50 6H   
 61   �� *Id+6H     5+      $
	 Tên��6%   
 62   �� *Name+  5,      $	 Nhà cung cấp��6%   
 6;   �� *
Producer+  5-      $	 Giá nhập��6%   
 67   �� *
PriceInput+$  {0:N0} VND��  5.      $	 	Giá bán��6%   
 66   �� *PriceOutput+$  {0:N0} VND��  5/      $	 Số lượng��6%      
Foreground
 �  ��
 67   �� *
Quantity+   ElementStyle 50      �� 51       �� 
TargetType" ��6    .�52      ��  �� Property � �� �� Value$ Right=�6D   �� 53       � ��$ 5q�67   54      56      58      59      5:      