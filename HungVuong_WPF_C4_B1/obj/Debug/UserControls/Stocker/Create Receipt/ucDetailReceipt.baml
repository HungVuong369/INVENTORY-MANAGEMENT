   M S B A M L   `   `   `  ����N  JHungVuong_WPF_C4_B1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:HungVuong_WPF_C4_B1HungVuong_WPF_C4_B1  5      )    #HungVuong_WPF_C4_B1.ucDetailReceipt   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      3local!clr-namespace:HungVuong_WPF_C4_B1     5      ���#ECF0F1  � 	Resources  5
      #   HungVuong_WPF_C4_B1.Converter   	converter4   .HungVuong_WPF_C4_B1.IndexDataGridItemConverter  indexDataGridItemConverter  ListBoxItemStyle �� 
TargetType �� Property �� Value �� 
TargetType �� Triggers :� RoutedEvent	 �� To g� Duration	 �� TargetProperty
 P� Property P� Value � ColumnDefinitions �� TextAlignment��%�  &	        &	      &	 &       5   
   6     5   
   6+   �� 5   
   " ��6)   .�5      ��  � ��
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
��Auto �6   �� 5I      $
��Auto �6   �� 5J      $��* �6   .+�5M   
   �� $��0��6   .+�5N      �� $#��Chi tiết phiếu nhập kho��6   $��Center=�5O      $��20(�5P      $��SemiBold"�5Q      5R      � 5S      $��0��6   $��10q�6     5T      �� 5U      6)   �� 5V      6)   �� 5W      6)   �� 5X      6)   �� 5Y      6)   .+�5\      �� $��0��6   $��15(�5]      $��10 0 0 0q�5^      ��5_      �� *ReceiptVM.Receipt.ReceiptID+ �� StringFormat$! Mã phiếu nhập kho: {0}�� �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�5`      �� 5b      $��1��6   $��15(�5c      ��5d      �� *ReceiptVM.Receipt.Username+$ Người tạo: {0}��$ TwoWay=�$ PropertyChanged=�5e      �� 5g      $��2��6   $��15(�5h      ��5i      �� *!ReceiptVM.Receipt.TotalQuantity+$, &Tổng số lượng sản phẩm: {0}��$ TwoWay=�$ PropertyChanged=�5j      �� 5l      $��3��6   $��15(�5m      ��5n      �� *ReceiptVM.Receipt.TotalPrice+$$ Tổng số tiền: {0:N0} VND��$ TwoWay=�$ PropertyChanged=�5o      �� 5q      $��4��6   $��15(�5r      ��5s      �� *ReceiptVM.Receipt.CreatedAt+$! Ngày tạo: {0:dd/MM/yyyy}��$ TwoWay=�$ PropertyChanged=�5t      5u      �� 5w      -   5        $��lstCategories��5w      ���#F2F2F2���#CCCCCC$��	10 10 0 0q�5z      #��[ 6)   ��5{      �� 5|      .R�5}      �  � Orientation$ 
Horizontal=�6$   5~      ��5�      �� 5�      .R�5�      ��  �� Padding$ 10q�65   ��6$   �� 65   5�      5�      5�      �� 5�   
   $��0��6   $$��Vui lòng chọn sản phẩm!��6    $��15(�6B   $��1��5�      $��10 8 0 0q�6!   � 5�   
   $��2��6    5�      �� 5�      $��* �6#   �� 5�      $��* �6#   .+�5�      �  5�      �� 5�      $
��Auto �6$   �� 5�      $
��AUto �6$   .+�5�      &   System.Windows.Controls.DataGrid  -   5          Name$ 
dgProducts��5�      $��10q�6/      AutoGenerateColumns .     AlternatingRowBackground �#F2F2F2   SelectionMode$ Single=�5�   >      
IsReadOnly .    	RowHeight$ 50Q�5�   J   $��0��6Y      Columns 5�      0  *System.Windows.Controls.DataGridTextColumn  5�      ,  &System.Windows.Controls.DataGridColumn   Header$	 STT��6-      Width5  /System.Windows.Controls.DataGridLengthConverter$ 50 6:   1  +System.Windows.Controls.DataGridBoundColumn   Binding 5�      �� 5�   "    �� 	Converter# [ 5�   *    �� RelativeSource 5�   *   ��   �� Mode$  FindAncestor=�! �� AncestorType)  #System.Windows.Controls.DataGridRow"!  5�   *   5�        5�      $	 Mã��6-   $ 45 6P    69   �� *Id+6P     5�      $
 Tên��6-   $	 200 6S    6:   �� *Name+6S     5�      $ Nhà sản xuất��6-   $	 100 6`    6C   �� *
Producer+6`     5�      $ Giá nhập��6-   $	 100 6�    6?   �� *
PriceInput+# [  6�   5�      �� 5�      -   5        $��
spQuantity��5�      " �� Orientation$" 
Horizontal=�6/   $��10q�6H   $��1��6T   .+�5�      �� $��Số lượng: ��6    $��18(�62   6B   �� 5�      -   5        $��txtQuantity��5�      $	��100��61   {�.  $��18(�5�      $
��15 0q�5�      6.   �� 5�      -   5        $��btnIncrease��5�      $��+��60   $��35��5�      {�.    specialButton#��[ 5�   /   6X   �� 5�      -   5        $��btnDecrease��5�      $��-��60   $��35��5�      $
��15 0q�6(   {�.  #��[ 5�   /   6X   �� 5�      -   5        $��btnAddProduct��5�      $	��108��5�      $��Thêm��5�      {�.  $��0 0 15 0q�5�      #��[ 5�   9   6b   �� 5�      -   5        $��btnSaveReceipt��5�      $
��Lưu��5�      $��Right=�5�      $	��108��5�      #��[ 5�      5�      5�      �� 5�      $��1��6   $	��450��6+   .��5�      �� # �� CornerRadius$# 20��6   
�������$��2q�6>   ._�5�      � -	   5        $��wpContainer��5�       5�      5�      5�      5�      5�      5�      