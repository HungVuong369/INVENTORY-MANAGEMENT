   M S B A M L   `   `   `  ����N  JHungVuong_WPF_C4_B1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:HungVuong_WPF_C4_B1HungVuong_WPF_C4_B1  5      &     HungVuong_WPF_C4_B1.ConfirmOrder   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      3local!clr-namespace:HungVuong_WPF_C4_B1     5        � 	Resources  5	      1   +HungVuong_WPF_C4_B1.ConvertPointsToCardType   convertPoints4   .HungVuong_WPF_C4_B1.IndexDataGridItemConverter 	 index��%:   &	        &	        5
   
   6(     5   
   6+   5      .��5      �  � RowDefinitions 5   
   �� 5      $
��auto �6   6,   �� 5      $
��auto �6   6,   �� 5      $
��auto �6   6,   �� 5      $��* �6   6)   �� 5      $��* �6   6)   .+�5   
   �� $��PHIẾU BÁN HÀNG��6   $��25(�5      $��Arial)�6   $��0��5      $
��Bold"�6   61   �� 5   
   
���   �$��0,2,0,2q�6%    �� Padding$ 0,4,0,4q�6?   $��1��5      $
��0 10q�5      ._�5      �  � ColumnDefinitions 5      �� 5      6)   �� 5       6)   .+�5#      �� -   5        $��lbDateCreated��5#      $��0��5$      $��SemiBold"�5%      
 � Tag 5&      �� *DateCreated+��5'      �� *Tag+ �� ElementName$ lbDateCreated�� �� StringFormat$ Ngày tạo: {0}��6l   �� 5(      -   5        $��	lbOrderID��5(      $��1��6-   $��SemiBold"�5*       5)      �� *	OrderID+��5+      �� *Tag+$ 	lbOrderID��$ Mã phiếu: {0}��6h   5,      5-      �� 5/   
   
���   �$��0,2,0,2q�6%   $ 0,4,0,4q�6?   $��2��50      $��0 0 0 10q�6   ._�51      �  52      �� 53      6&   �� 54      6&   �� 55      6&   �� 56      6&   �� 57      6&    5:      �� 5;      6)   �� 5<      6)   .+�5?      �� $��Thông tin khách hàng��6   $
��Bold"�5@      $��14(�5A      $��0��5B      $��0��5C      6*   �� 5E      $��SemiBold"�5F      $��1��5G      $��0��5H      $
��0 10q�5I      ��5E      �� *Customer.Name+$ 	Tên: {0}��5I   (   �� 5K      $��SemiBold"�5L      $��2��5M      $��0��5N      ��5K      �� *Customer.Phone+$ Số điện thoại: {0}��5N   *   �� 5P      $��SemiBold"�5Q      $��3��5R      $��0��5S      $
��0 10q�5T      ��5P      �� *Customer.Points+$ Điểm: {0}��5T   (   �� 5V      $��SemiBold"�5W      $��4��5X      $��0��5Y      ��5V      �� *Customer.Points+$ Loại thẻ: {0}�� �� 	Converter# [  5Y   *   �� 5[      $��Thông tin người dùng��6   $
��Bold"�5\      $��14(�5]      $��0��5^      $��1��5_      6*   �� 5a      $��SemiBold"�5b      $��1��5c      $
��0 10q�5d      $��1��5e      ��5a      �� *
Username+$ Người tạo: {0}��5e   *   �� 5g      $��SemiBold"�5h      $��2��5i      $��1��5j      ��5g      �� *
Quantity+$ Số lượng: {0}��5j   *   �� 5l      $��SemiBold"�5m      $��3��5n      $
��0 10q�5o      $��1��5p      ��5l      �� *Total+$ Số tiền: {0:N0} VND��5p   *   �� 5r      $��SemiBold"�5s      $��4��5t      $��1��5u      ��5r      �� *DateCreated+$ Ngày tạo: {0}��5u   *   5v      5w      &   System.Windows.Controls.DataGrid  5y   
   -   5          Name$ 
dgProducts��5y      $��3��6'   	   AutoGenerateColumns	 .  
   AlternatingRowBackground
 �#F2F2F2   SelectionMode$ Single=�5z   6      
IsReadOnly . ��5|      �� *
Products+   Columns 5}      0  *System.Windows.Controls.DataGridTextColumn  5~      ,  &System.Windows.Controls.DataGridColumn   Header$	 STT��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 5      �� 5�      # [ 5�   *    �� RelativeSource 5�   "   ��  �� Mode$ FindAncestor=� �� AncestorType)  #System.Windows.Controls.DataGridRow"  5�   *   5�        5�      $ Tên sản phẩm��6%    6;   �� *Name+  5�      $ Số lượng��6%    67   �� *
Quantity+   ElementStyle 5�      �� 5�       �� 
TargetType" ��6    .�5�      ��  �� Property � �� �� Value$ Right=�6D   �� 5�       � ��$ 5q�67   5�      5�        5�      $ Giá tiền��6%    67   �� *PriceDiscount+$  {0:N0} VND��  5�      $ Tổng tiền��6%    68   �� *TotalOutput+$  {0:N0} VND��5�      �� 5�   
   $��4��6    �� Orientation$ 
Horizontal=�6"   $��Center=�6;   $
��0 10q�6X   .+�5�      �� -   5        $��
btnConfirm��5�      $��Xác nhận��5�      $	��200��5�      $��0 0 5 0q�6!   5�   0   �� 5�      -   5        $��	btnCancel��5�      $��Hủy��5�      $	��200��5�      $��5 0 0 0q�6!   5�   /   5�      5�      5�      