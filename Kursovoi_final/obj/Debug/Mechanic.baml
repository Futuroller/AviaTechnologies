   M S B A M L   `   `   `  ����I  EKursovoi_final, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:Kursovoi_finalKursovoi_final  5   	       Kursovoi_final.Mechanic   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:Kursovoi_final     5   	     � Title$  Механик��5   	   $	��700��6   $	��900��6&   $��Comic Sans MS)�5	   	   $��14(�6$    � WindowStartupLocation$ CenterScreen=�5
   	   ���#E0E0E0 � Icon$ /airbus.png��5      .��5      �  � RowDefinitions 5   
   �� 5      $��80 �6   �� 5      $��50 �6   �� 5      $
��282* �6   �� 5      $��80 �6   .+�5   
   ��  �� Orientation$ 
Horizontal=�6   ���#007ACC$��Stretch=�6C   .+�5      �� $"��АвиаТехнологии��6   $��Center=�6.   
�������$��18(�6\   $��Center=�6j   $��350,10,10,10q�6�   5      �� 5   
   $��/airbus.png��6   $��50��6%   $��Right=�60   $��50��6L   $��10,10,10,10q�6X   �� 5   
   $ 
Horizontal=�6   $��1��6.   $��Right=�6;   $��Center=�6W   $��0,0,20,0q�6r   .+�5      �� $'��!Поиск по названию:��6   $��Center=�62   $��	30,0,10,0q�6M   �� 5      -   5         ��Name$ SearchTextBox��5      $	��150��6-   $��25��69   $��Center=�6E   $��0,0,10,0q�6`   6r   �� 5      $3��-Фильтр по производителю:��6   $��Center=�68   $��	30,0,10,0q�6S   �� 5       -   5         ��Name$ ManufacturerComboBox��5       $	��150��65   $��25��6A   $��Center=�6M   $��0,0,10,0q�6h   6z   �� 5!      -   5         ��Name$ ClearSearchButton��5!      $��Отмена��60   $	��120��6A   $��25��6M   $��Center=�6Y   6t   5"      �� 5%   
   -   5         ��Name$ PartsListBox��5%      $��2��6(   $	��Top=�65   $��	10,5,10,0q�6M   $	��450��6`   $y�Visible=�6m   ��5&      �� 5'      .R�5(      �� $ 
Horizontal=�6!   .+�5)      �� 	 ��Name$	 PartCheckBox��6#   $��5q�69   
 d� 	IsChecked
 6D   �� *
IsSelected+�� 5*      $��5q�6>   ��6$   �� *
Nazvanie+6>   �� 5+      $�� (��6$   $��5q�6.   �� 5,      $��5q�6N   ��6$   �� *b_Proizvoditeli.Nazvanie+6N   �� 5-      $��)��6$   $��5q�6-   5.      5/      51      �� 54   
   -   5        $ ManageMaintenancesButton��54      $��3��63   $7��1Управление обслуживаниями��6@   $��30��6d   $��258,25,432,25q�6p   ���#007ACC
�������6�   �� 57   
   -   5        $ AddToRequestButton��57      $��3��6-   $��16(�6:   $&�� Добавить в запрос��6H   $��30��6d   $��658,25,81,25q�6p   ���#007ACC
�������6�   �� 5:   
   -   5        $ ButtonVihod��5:      $��3��6&   $��
Выйти��6N   $��14(�6^   $
��Left=�6l   $��Center=�6�   $	��130��6�   $��33,0,0,0q�6�   $��30��6�    � Cursor$
 Hand��6�   5;      5<      