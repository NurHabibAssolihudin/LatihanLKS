   M S B A M L   `   `   `  ����L  HLatihanLKSDesktop, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:LatihanLKSDesktopLatihanLKSDesktop  5   	       LatihanLKSDesktop.Gudang   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:LatihanLKSDesktop     5   	     � Title$  Gudang��5   	   $	��450��6   $	��800��6%   .��5	      � .+�5
   
   � $
��Left=�6   $	��194��6*   ���	#FF29C3FF.+�5      �� $��GUDANG��6   $��Center=�6%   $��0,30,0,0q�6B   $	��Top=�6T   $��24(�6l   $
��Bold"�6z   �� 5      $	��100��6   $��
47,93,47,0q�6!   $	��Top=�65   $��/storage-stacks.png��6M   �� 5      $��KELOLA
BARANG��6   $��Center=�65   $��	0,217,0,0q�6R   $	��Top=�6e   $��24(�6}   $
��Bold"�6�   $	��114��6�   �� 5      -   5        $��Logout��5      $��Center=�6&   $��	0,345,0,0q�6C   $	��Top=�6V   6n   5      � 5   
   $��	199,0,0,0q�6   .+�5      �� $��Kelola Barang��6   $��Center=�6,   $��0,17,0,0q�6I   $	��Top=�6[   $��24(�6s   $
��Bold"�6�   $	��166��6�   �� 5      $��Kode Barang��6   $
��Left=�6*   $��	45,72,0,0q�6E   $	��Top=�6X   $	��111��6p   �� 5      -   5         ��Name$ input_satuan��5      $
��Left=�6-   $��330,161,0,0q�6H   $	��Top=�6]   $	��224��6u   .@�5      �� $��Botol��6   �� 5      $	��Pcs��6   5      �� 5      $��Nama Barang��6   $
��Left=�6*   $��
45,130,0,0q�6E   $	��Top=�6Y   $	��130��6q   �� 5      -   5         ��Name$ input_nama_barang��5      $
��Left=�61   $��
45,161,0,0q�6L    �� TextWrapping$
 Wrap=�6`   $	��Top=�6t   $	��225��6�   �� 5      $��Expred Date��6   $
��Left=�6*   $��
45,194,0,0q�6E   $	��Top=�6Y   $��95��6q   �� 5      $��Jumlah Barang��6   $
��Left=�6,   $��
328,72,0,0q�6G   $	��Top=�6[   $	��111��6s   �� 5      $��Satuan��6   $
��Left=�6%   $��328,130,0,0q�6@   $	��Top=�6U   $��77��6m   �� 5      -   5        $ input_kode_barang��5      $
��Left=�61   $��
46,103,0,0q�6L   $
 Wrap=�6`   $	��Top=�6t   $	��224��6�   �� 5      $��Harga Per Satuan��6   $
��Left=�6/   $��328,194,0,0q�6J   $	��Top=�6_   $	��111��6w   �� 5      -   5        $ input_harga_satuan��5      $
��Left=�62   $��328,225,0,0q�6M   $
 Wrap=�6b   $	��Top=�6v   $	��224��6�   �� 5      -   5        $ input_jumlah_barang��5      $
��Left=�63   $��328,103,0,0q�6N   $
 Wrap=�6c   $	��Top=�6w   $	��224��6�   �� 5       -   5        $��Tambah��5       $
��Left=�6&   $��
45,267,0,0q�6A   $	��Top=�6U   $��66��6   �� 5!      -   5        $
��Edit��5!      $
��Left=�6$   $��140,267,0,0q�6?   $	��Top=�6T   $��35��6   �� 5"      -	   5        $��Hapus��5"      $
��Left=�6%   $��205,267,0,0q�6@   $	��Top=�6U   $��54��6�   �� 5#      $��Search��6   $
��Left=�6%   $��
45,304,0,0q�6@   $	��Top=�6T   $��39��6l   �� 5$      -
   5        $ input_search��5$      $
��Left=�6,   $��
93,312,0,0q�6G   $
 Wrap=�6[   $	��Top=�6o   $	��224��6�   6�   &   System.Windows.Controls.DataGrid  5%      -   5          Name$ datagrid��5%      $��10,335,11,10q�6)      
IsReadOnly$
 True��6?      Columns 5&      0  *System.Windows.Controls.DataGridTextColumn  5'      ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$	 20* 6)      Header$ 	ID Barang��65   1  +System.Windows.Controls.DataGridBoundColumn	   Binding	 6H   �� *	id_barang+  5(      $	 20* 6)   $ Kode Barang��65   	 6J   �� *kode_barang+  5)      $	 20* 6)   $ Nama Barang��65   	 6J   �� *nama_barang+  5*      $	 20* 6)   $ Expired Date��65   	 6K   �� *expired_date+  5+      $	 20* 6)   $ Jumlah��65   	 6E   �� *jumlah_barang+  5,      $	 20* 6)   $ Satuan��65   	 6E   �� *satuan+  5-      $	 20* 6)   $ Harga Satuan��65   	 6K   �� *harga_satuan+5/      �� 50      -   5        $ input_id��50      $
��Left=�6(   $��330,281,0,0q�6C   $
 Wrap=�6X   $��TextBox��6l   $	��Top=�6{   $��90��6�   ${�False��6�   
 J� Opacity$
 0Q�6�   (  "System.Windows.Controls.DatePicker  51      -   5          Name$ input_expired_date��51      $
��Left=�65   $��
50,220,0,0q�6P   $	��Top=�6d   $	��220��6|   52      54      55      