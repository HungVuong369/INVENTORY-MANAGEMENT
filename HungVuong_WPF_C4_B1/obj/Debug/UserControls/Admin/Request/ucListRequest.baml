   M S B A M L   `   `   `  ����N  JHungVuong_WPF_C4_B1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:HungVuong_WPF_C4_B1HungVuong_WPF_C4_B1  5      '    !HungVuong_WPF_C4_B1.ucListRequest   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      3local!clr-namespace:HungVuong_WPF_C4_B1     5        � 	Resources  5	      4   .HungVuong_WPF_C4_B1.IndexDataGridItemConverter 	  index��%   &	          5
   
   6+   5      .��5      �  � RowDefinitions 5   
   �� 5      $
��auto �6   6,   �� 5      6   .+�5   
   �� $��Danh sách yêu cầu��6   $��Center=�5      $��20(�5      $��SemiBold"�5      $��0��5      6   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ 
dgRequests��5      $��1��6'   $��10q�64      AutoGenerateColumns .     AlternatingRowBackground �#F2F2F2   SelectionMode$ Single=�5   6      
IsReadOnly .    Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$	 STT��6%   1  +System.Windows.Controls.DataGridBoundColumn	   Binding	 5      �� 5      
 �� 	Converter#
 [  5   *    �� RelativeSource 5   "   ��  �� Mode$ FindAncestor=� �� AncestorType)  #System.Windows.Controls.DataGridRow"  5   *   5!        5"      $ 
Yêu cầu��6%   	 66   �� *	Request+6T     5#      $ 
Nội dung��6%   	 67   �� *Reason+6T   4  .System.Windows.Controls.DataGridTemplateColumn  5%         CellTemplate 5&      �� 5'      .R�5(      �� -   5        $��
Chi tiết��5(   %   $	��100��5*   %   $��10q�5+   %   
 � Tag 5,   %   �� *
CustomerID+5-      5/      51      52      53      