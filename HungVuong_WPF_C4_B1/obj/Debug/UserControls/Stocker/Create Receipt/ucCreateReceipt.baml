   M S B A M L   `   `   `  ����N  JHungVuong_WPF_C4_B1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:HungVuong_WPF_C4_B1HungVuong_WPF_C4_B1  5      )    #HungVuong_WPF_C4_B1.ucCreateReceipt   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      3local!clr-namespace:HungVuong_WPF_C4_B1     5      ���#ECF0F1.��5
      � -   5        $��grdCreateReceipt��5
      $��10q�6#   $��Center=�6/     � RowDefinitions  5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   .+�5   
   �� -   5        $��spCreateReceipt��5      .+�5      �� 
���OO/�$��2q�61    �� Padding$	 100q�6E   ._�5      �� .+�5      �� $��Tạo phiếu nhập kho��6    $��Center=�5      $��20(�5      $��SemiBold"�5      $��0,0,0,20q�5      �� 5      $��1��6!    �� Orientation$ 
Horizontal=�6.   $��0,0,0,10q�6G   .+�5      �� $��Mã phiếu nhập kho: ��6$   $��Center=�5      $��0,0,10,0q�5       $��20(�5!      �� 5"      $	��200��5#      $��Center=�5$      $��20(�5%      ��5"   $   �� *ReceiptVM.Receipt.ReceiptID+5%      5&      �� 5(      $��2��6!   $ 
Horizontal=�6.   $��0,0,0,10q�6G   .+�5)      �� $��Người tạo: ��6$   $��Center=�5*      $��0,0,10,0q�5+      $��20(�5,      �� 5-      $	��200��5.      $��Center=�5/      $��20(�50      ��5-   $   �� *ReceiptVM.Receipt.Username+50      52      �� 54      $��3��6!   $ 
Horizontal=�6.   $��0,0,0,10q�6G   .+�55      �� $��Ngày tạo: ��6$   $��Center=�56      $��0,0,10,0q�57      $��20(�58      �� 59      $	��200��5:      $��Center=�5;      $��20(�5<      ��59   $   �� *ReceiptVM.Receipt.CreatedAt+ �� StringFormat$ 
dd/MM/yyyy��5<      5=      �� 5?      $��4��6!   $ Vertical=�6.   .+�5@      �� -   5        $��btnCreateReceipt��5@   !   $��Tạo phiếu nhập kho��69   $��25��5A      $
��0 20q�5B      5C      �� 5E      -   5        $��CancelReceipt��5E   !   $��Hủy��5F      $��25��5G      5H      5J      5K      5L      5M      � 5O   
   -   5        $��grdSaveReceipt��5O      $y�	Collapsed=�6%   5Q      5R      5S      