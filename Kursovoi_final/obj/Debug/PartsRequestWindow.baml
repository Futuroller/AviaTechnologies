   M S B A M L   `   `   `  ����I  EKursovoi_final, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:Kursovoi_finalKursovoi_final  5   	   '    !Kursovoi_final.PartsRequestWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:Kursovoi_final     5   	     � Title$9  3Заявка на покупку запчастей��5   	   $	��539��6-   $	��500��6:   $��Century Gothic)�6F   $��14(�6b    � WindowStartupLocation$ CenterScreen=�6p   ���	#FFFBF8F5 � Cursor$
 Hand��6�    � Icon$ /airbus.png��6�   .��5	      �  � RowDefinitions 5
   
   �� 5      $��80 �6   �� 5      $��50 �6   �� 5      $��* �6   �� 5      $��50 �6   �� 5      $��50 �6   �� 5      $��70 �6   .+�5   
   ��  �� Orientation$ 
Horizontal=�6   ���#007ACC$��Stretch=�6C   .+�5      �� $"��АвиаТехнологии��6   $��Center=�6.   
�������$��18(�6\   $��Center=�6j   $��150,10,10,10q�6�   5      �� 5   
   $��/airbus.png��6   $��50��6%   $��Right=�60   $��50��6L   $��10,10,10,10q�6X   �� 5      -   5         ��Name$ TextBlockZagolovok��5      $9��3Заявка на покупку запчастей��68   $��1��6[    �� TextAlignment$ Center=�6h   $��20(�6   $��Center=�6�   $��26��6�   $	��349��6�   $��0,13,0,0q�6�   �� 5    
   -   5         ��Name$ SelectedPartsListBox��5       $��2��60   $��15,43,15,31q�6=   ��5!      �� 5"      .R�5#      �� $��5q�6:   ��6    �� *
Nazvanie+6:   5$      5&      �� 5)   
   $0��*Выберите обслуживание:��6   $��Center=�62   $��20,0,0,0q�6M   $��3��6_   �� 5*   
   -   5        	 ��Name$	 MaintenanceComboBox��5*      $	��350��60   $��30��6<   $��Center=�6H   $��20,0,0,0q�6c   $��4��6u   
 �� DisplayMemberPath$
 Opisanie��6�   �� 5-   
   -   5         ��Name$ CreateRequestButton��5-      $��5��6.   $!��Создать заявку��6;   $	��150��6T   $��30��6`   $��Center=�6m   $��Center=�6�   ���#007ACC
�������6�   5.      5/      