   M S B A M L   `   `   `  ����L  HLatihanLKSDesktop, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:LatihanLKSDesktop.AdminPageLatihanLKSDesktop.AdminPage  5      )    #LatihanLKSDesktop.AdminPage.laporan   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ;local)clr-namespace:LatihanLKSDesktop.AdminPage     5        N� Title$  laporan��5	      .��5      � 
������� � RowDefinitions 5   
   �� 5      $	��82* �6   �� 5      $
��143* �6   .+�5   
   �� $��Laporan Penjualan��6   $��Center=�6,   $��0,41,0,0q�6I   $	��Top=�6[   $��24(�6s   $
��Bold"�6�   �� 5   
   $��Tanggal Awal��6   $
��Left=�6'   $��	25,89,0,0q�6B   $	��Top=�6U   $��98��6m   (  "System.Windows.Controls.DatePicker  5   
   -   5          Name$ 
first_date��5      $
��Left=�6)   $��
25,120,0,0q�6D   $	��Top=�6X   $	��198��6p   �� 5   
   $��Tanggal Akhir��6   $
��Left=�6(   $��
288,89,0,0q�6C   $	��Top=�6W   $	��100��6o     5   
   -   5        $ 	last_date��5      $
��Left=�6(   $��288,120,0,0q�6C   $	��Top=�6X   $	��197��6p   �� 5   
   -   5        $��Fillter��5      $
��Left=�6#   $��544,122,0,0q�6>   $	��Top=�6S   $��41��6k   6v   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ datagrid��5      $��1��6%   $��10,0,10,163q�62      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$	 25* 6%      Header$ ID Transaksi��61   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6G   �� *no_transaksi+  5      $	 25* 6%   $ Tanggal Transaksi��61    6L   �� *tgl_transaksi+  5      $	 25* 6%   $ Total Pembayaran��61    6K   �� *total_bayar+  5      $	 25* 6%   $ 
Nama Kasir��61    6E   �� *	id_user+5      5      5       