   M S B A M L   `   `   `  ����H  DJournal-IO-v2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:Journal_IO_v2Journal_IO_v2  5   	       Journal_IO_v2.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F BNHotkey.Wpf, Version=1.2.1.0, Culture=neutral, PublicKeyToken=nullR NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:Journal_IO_v2     5   	   -   5          �Name$  Window_1��5   	    � Title$ 
MainWindow��5   	   $��802.515��6   $��1355.639��6-   .��5	      ]� .+�5
   
   � $��0,0,2.667,10.333q�6    J� IsManipulationEnabled .  � ColumnDefinitions 5      �� 5      $
��139* �6#   �� 5      $��0* �6#   �� 5      $��1207* �6#   �� 5      $��0* �6#   .+�5      �� -   5         ��Name$ 	dateEntry��5      $
��Left=�6)   $��	25,45,0,0q�6D    �� TextWrapping$
 Wrap=�6W   $	��Top=�6k   $
��Left=�6�   $��21��6�   $	��104��6�   �� 5      -   5        $ NewEntryBox��5      $��Stretch=�6+   $
��auto��6I   $��2.667,23,10,466q�6W   $
 Wrap=�6p   $��Stretch=�6�   $
��auto��6�   $��2��6�    �� 	IsEnabled . 6�   �� 5      -   5        $ Output��5      $��Stretch=�6&   $
��auto��6D   $
 Wrap=�6R   $��Stretch=�6f   $
��auto��6�   $��2.667,302,10,0q�6�   $��2��6�    �� 
IsReadOnly . " �� VerticalScrollBarVisibility$ Visible=�6�   �� 5      -   5        	 ��Name$	 AddEntry��5      $	��Add��6'   $
��Left=�65   $��	54,71,0,0q�6P   $	��Top=�6c   $��75��6{   $��20��6�   $
��Left=�6�   c� 5      $
��Left=�6   $��16��61   $	��Top=�6=   $��53��6U   $
��File��6`   .@�5      �� -   5        $	 
SaveButton��5      $��Save (Control + S)��6-   6J   �� 5      -   5        $	 SaveAsButton��5      $#��Save As (Control + Shift + S)��6/   6W   �� 5      -   5        $	 
OpenButton��5      $��Open (Control + O)��6-   6J   �� 5      -	   5        $	 	NewButton��5      $��New (Control + N)��6,   6H   �� 5      -
   5        $	 SearchButton��5      $��Search (Control +F)��6/   6M   5      5      5      5      