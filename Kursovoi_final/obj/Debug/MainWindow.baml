   M S B A M L   `   `   `  ����I  EKursovoi_final, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:Kursovoi_finalKursovoi_final  5   	       Kursovoi_final.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:Kursovoi_final     5   	     � Title$  Авторизация��5   	   $	��520��6   $	��400��6*   $��Comic Sans MS)�5	   	   $��14(�6$    � WindowStartupLocation$ CenterScreen=�5
   	   ���#E0E0E0 � Icon$ /airbus.png��5      .��5      �  � RowDefinitions 5   
   �� 5      $	��27* �6   �� 5      $	��17* �6   �� 5      $
��208* �6   .+�5   
   �� $��0��6    �� Orientation$ 
Horizontal=�6"   ���#007ACC$��0,0,0,17q�6Q   $��2��6c   .+�5      �� -   5         ��Name$ TextBlockZagolovok��5      $��Center=�64   $��
130,25,0,0q�6Q   $
��Wrap=�6e   $"��АвиаТехнологии��6y   $	��Top=�6�   $��18(�6�   $
��Bold"�6�   
�������6�   5      �� 5   
   $��50��6   $
��Left=�6   $��318,11,0,27q�67   $��/airbus.png��6L   $
��Fill=�6a   $��60��6p   $��2��6{    J� RenderTransformOrigin$ 
5.311,0.35&�6�   �� 5   
   $��Center=�6   $��0,41,0,0q�61   $��2��6C   $��18(�6P   $
��Wrap=�6^   $��Авторизация��6r   $	��Top=�6�   $
��Bold"�6�   ���#3333336�   �� 5   
   $
��Left=�6   $��
120,97,0,0q�6/   $��2��6C   $
��Wrap=�6P   $��
Логин��6d   $	��Top=�6q   ���#3333336�   �� 5   
   -   5         ��Name$ TextBoxLogin��5      $��5,2,0,0q�6(   $��Center=�6:   $��2��6W    �� TextWrapping$ NoWrap=�6d   $�� ��6z   $	��Top=�6�   $	��160��6�   $��	0,114,0,0q�6�   $��26��6�   
����������#3333336�   �� 5   
   $
��Left=�6   $��120,146,0,0q�6/   $��2��6D   $��NoWrap=�6Q   $��Пароль��6g   $	��Top=�6u   ���#3333336�   G� 5    
   -   5        	 G�Name$	 TextBoxPassword��5       $��5,2,0,0q�6/   $��Center=�6A   $��	0,163,0,0q�6^   $��2��6q   $	��Top=�6~   $	��160��6�   $��26��6�   
����������#3333336�   �� 5#   
   -   5        
 ��Name$
 
ButtonVhod��5#      $��
Войти��6%   $��Center=�65   $��	0,227,0,0q�6R   $��2��6e   $	��Top=�6r   $	��102��6�   ���#007ACC
���   �$��28��6�    � Cursor$
 Hand��6�   
�������6�   5'      5(      