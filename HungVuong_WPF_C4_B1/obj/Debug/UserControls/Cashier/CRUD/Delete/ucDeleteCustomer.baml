   M S B A M L   `   `   `  ����N  JHungVuong_WPF_C4_B1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:HungVuong_WPF_C4_B1HungVuong_WPF_C4_B1  5      *    $HungVuong_WPF_C4_B1.ucDeleteCustomer   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      3local!clr-namespace:HungVuong_WPF_C4_B1     5        � 	Resources  5	      1   +HungVuong_WPF_C4_B1.ConvertPointsToCardType   convertPointsToCardType4   .HungVuong_WPF_C4_B1.IndexDataGridItemConverter 	 index��%:   &	        &	        5
   
   6(     5   
   6+   5      .��5      �  � RowDefinitions 5   
   �� 5      $
��auto �6   6,   �� 5      6   .+�5   
   �� $��Danh sách khách hàng��6   $��Center=�5      $��20(�5      $��SemiBold"�5      $��0��5      6   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ 
dgCustomer��5      $��1��6'   $��10q�64      AutoGenerateColumns .     AlternatingRowBackground �#F2F2F2   SelectionMode$ Single=�5   6      
IsReadOnly .    Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$	 STT��6%   1  +System.Windows.Controls.DataGridBoundColumn	   Binding	 5      �� 5       
 �� 	Converter#
 [ 5!   *    �� RelativeSource 5    "   ��  �� Mode$ FindAncestor=� �� AncestorType)  #System.Windows.Controls.DataGridRow"  5!   *   5#        5$      $ 	Mã thẻ��6%   	 65   �� *CardID+  5%      $
 Tên��6%   	 62   �� *Name+  5&      $ Số điện thoại��6%   	 6<   �� *Phone+  5'      $ Điểm��6%   	 63   �� *Points+ �� StringFormat$  {0:N0}��  5(      $ Loại thẻ��6%   	 67   �� *Points+#
 [     ElementStyle 5)      �� 5*       �� 
TargetType" ��6    .�5+      ��  �� Property � �� �� Value
 �����6;   �� 5,       � ��
 �   �6;    �� Triggers 5-      �� 5.   "    �� Binding 6.   �� *Points+#
 [   �� Value	 Vàng6}   .a�5/   &   ��  � ��
 � ���6C   50   #   �� 51   "    6.   �� *Points+#
 [   
Bạch Kim6}   .a�52   &   ��  � ��
 ��·�6C   53   #   55      57      4  .System.Windows.Controls.DataGridTemplateColumn  59         CellTemplate 5:      �� 5;      .R�5<      �� -   5        $
��Xóa��5<   %     ButtonDeleteStyle#��[ 63   
 � Tag 5>   %   �� *CardID+5?   %   5@      5B      5D      5E      5F      