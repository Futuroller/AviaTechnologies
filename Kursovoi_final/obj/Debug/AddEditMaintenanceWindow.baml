   M S B A M L   `   `   `  ����I  EKursovoi_final, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:Kursovoi_finalKursovoi_final  5   	   -    'Kursovoi_final.AddEditMaintenanceWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:Kursovoi_final     5   	     � Title$P  JДобавление/Редактирование обслуживания��5   	   $	��500��68   $	��600��6E   $��Comic Sans MS)�5	   	   $��14(�6$    � WindowStartupLocation$ CenterScreen=�5
   	   ���#E0E0E0 � Icon$ /airbus.png��5      .��5      �  � RowDefinitions 5   
   �� 5      $��80 �6   �� 5      $��50 �6   �� 5      $��50 �6   �� 5      $��50 �6   �� 5      $��50 �6   �� 5      $��50 �6   �� 5      $��50 �6   �� 5      $��50 �6   .+�5   
   ��  �� Orientation$ 
Horizontal=�6   ���#007ACC$��Stretch=�6C   .+�5      �� $"��АвиаТехнологии��6   $��Center=�6.   
�������$��18(�6\   $��Center=�6j   $��220,10,10,10q�6�   5      �� 5   
   $��/airbus.png��6   $��50��6%   $��Right=�60   $��50��6L   $��10,10,10,10q�6X   �� 5    
   $��Описание:��6   $��Center=�6%   $��10,0,0,0q�6@   $��1��6R   �� 5!   
   -   5         ��Name$ DescriptionTextBox��5!      $	��400��6.   $��25��6:   $��Center=�6F   $��10,0,0,0q�6a   $��2��6s   �� 5#   
   $(��"Дата обслуживания:��6   $��Center=�6.   $��10,0,0,0q�6I   $��3��6[   (  "System.Windows.Controls.DatePicker  5$   
   -   5          Name$ MaintenanceDatePicker��5$      $	��400��64   $��25��6@   $��Center=�6L   $��10,0,0,0q�6g   $��4��6y   �� 5&   
   $��Самолет:��6   $��Center=�6$   $��10,0,0,0q�6?   $��5��6Q   �� 5'   
   -   5         ��Name$ AircraftComboBox��5'      $	��400��6-   $��25��69   $��Center=�6E   $��10,0,0,0q�6`   $��6��6r   �� 5*   
   $ 
Horizontal=�6   $��Center=�6.   $��7��6K   .+�5+      �� -   5         ��Name$ 
SaveButton��5+      $��Сохранить��6)   $	��100��6=   $��30��6I   $��10q�6U   ���#007ACC
�������6�   �� 5,      -   5        $ ButtonCancel��5,      $��Отмена��6G   $	��100��6X   $��30��6d   $��10q�6p   
����������#007ACC$
��Bold"�6�   ���#007ACC	 � Cursor$
	 Hand��6�   5-      5.      5/      