   M S B A M L   `   `   `  ����O  KWorldskillsChina2016, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:WorldskillsChina2016.pgWorldskillsChina2016.pg  5      1    +WorldskillsChina2016.pg.SponsorshipViewPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      7local%clr-namespace:WorldskillsChina2016.pg     5        N� Title$  Sponsorship View��5	       N� FontSize$ 16(�6     N� 
FontFamily$ Calibri)�6.   .��5      � .+�5   
   �� $��Center=�6   $��Center=�62   .+�5      �� $��Sponsorship View��6   $��25(�60   $��Center=�6>   $��10q�6[   �� 5      $��Center=�6    �� Orientation$ 
Horizontal=�66   $��10q�6O   .+�5      �� $��Event: ��6   $��Center=�6+   �� 5      -   5         ��Name$ cbxEvent��5      $	��300��6-    �� 
IsEditable . 69   �� 5      $��    Skills: ��6   $��Center=�60   �� 5      -   5        $ 	cbxSkills��5      $	��200��6.    . 6:   5      �� 5      $��Center=�6   $ 
Horizontal=�66   $��10q�6O   .+�5      �� $��	Sponsor: ��6   $��Center=�6-   �� 5      -   5         ��Name$ 
tbxSponsor��5      $	��300��6.   �� 5      -   5        $��Search��5   .   $	��100��6?   $��63 0 0 0q�6K   �� 5      -   5        $��Export��5   .   $	��100��6?   $��10 0 0 0q�6K   5      �� 5      $��Center=�6   $��	0 30 0 10q�65   �� 5      .�6   Total Records:6'    �� 5      -   5         ��Name$ txbTotalRecords��5       �� 5      .�6   Total Amount(P):6,    �� 5      -   5        $ txbTotalAmount��5      5       �� 5"      -   5         ��Name$ lv��5"      $	��750��6#   $	��250��6/   $��12(�6<   	 �� View	 5#      �� 5$      .P�5%      �� $��Event��6)   
 �� Width$	
 180��68    �� CellTemplate 5&      �� 5'   "   .R�5(   &   �� $
��Wrap=�6X   ��60   ��  �� Path$ Championship.Name�6X   5)   #   5+      �� 5,      $��Skills��6)   $	
 150��69    5-      �� 5.   "   .R�5/   &   �� $
��Wrap=�6^   ��60   �� $ Competition.NameRussian�6^   50   #   52      �� 53      $��Sponsor��6)   $	
 130��6:    54      �� 55   "   .R�56   &   �� $
��Wrap=�6K   ��60   �� $
 Name�6K   57   #   59      �� 5:      $��SponsorItem��6)   $	
 130��6>    5;      �� 5<   "   .R�5=   &   �� $
��Wrap=�6N   ��60   �� $ Sponsor�6N   5>   #   5@      �� 5A      $��	Amount(P)��6)   $	
 130��6<    5B      �� 5C   "   .R�5D   &   �� $
��Wrap=�6M   ��60   �� $ Amount�6M   5E   #   5G      5H      5J      5K      5L      5M      