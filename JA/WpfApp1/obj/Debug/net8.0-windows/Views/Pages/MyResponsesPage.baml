   M S B A M L   `   `   `  ����C  ?HireVich, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:JA.Views.PagesJA.Views.Pages  5      $    JA.Views.Pages.MyResponsesPage   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      .localclr-namespace:JA.Views.Pages     5        N� Title$  MyResponsesPage��5	      .��5      �  � RowDefinitions 5   
   �� 5      $��60 �6   �� 5      .+�5   
   �� $��0��6    �� Orientation$ 
Horizontal=�6"   .+�5      �� $��20, 10q�6   $��26(�6$   .��62   Мои отклики6?   5      � 5   
   $��1��6   $��
20,0,20,20q�6   .+�5      �� -   5         ��Name$ ApplicationsList��5   ?   ���#F8F8F8$��0q�6+   $��Disabled=�5   0   $��Stretch=�5      ��5      �� *applications+��5      �� 5       �� 
TargetType" ��6   .�5      ��  �� Property � �� �� Value$ Stretch=�6G   5      ��5      �� 5      .R�5       ��  �� CornerRadius$ 4��6!   $��	0,10,0,10q�62   $��Stretch=�6E   
�������._�5!      � $��10q�6#    5"   "   �� 5#   &   $
��Auto �64   �� 5$   &   $
��Auto �64   �� 5%   &   $
��Auto �64   �� 5&   &   $
��Auto �64   �� 5'   &   $
��Auto �64   .+�5+   "   � $��0��6'    � ColumnDefinitions 5,   &   �� 5-   *   $��* �6;   �� 5.   *   $
��Auto �6;   .+�50   &   �� $��0��6,   ��6<   �� *&$AppForList.application.Vacation_Name+�� 51   &   $��Right=�6L   $	��100��6h   $	��100��6w   ��6,   �� *Company_Logo+6�   52   #   �� 55   "   $��1��6-   $ 
Horizontal=�6:   $��0,5,0,0q�6S   .+�56   &   �� $��15��6,   $��15��67   $��/Images/Job wage.png��6C   �� 57   &   $��5,0,0,0q�6\   ��6,   �� *AppForList.application.Wage+6\   58   #   �� 5;   "   $��2��6)   $��0,10,0,0q�66   ._�5<   &   �� $��14(�5>   .   $
��Wrap=�5?   .   $��CharacterEllipsis=�5@   .   $��45��5A   .   $��Stretch=�5C   .   ��5=   .   �� *$"AppForList.application.Description+��5B   .   �� *ActualWidth+	 �� RelativeSource	 �� 
 �� AncestorType

 Border5C   .   5D   #   � 5F   "   $��3��6'    5G   &   �� 5H   *   $��* �6;   �� 5I   *   $
��Auto �6;   .+�5L   &   �� $ 
Horizontal=�61   $��0��6J   .+�5M   *   A� $��25��62   $��25��6=   ��5N   .   �� 5O   2    �� ImageSource 6=   �� * AppForList.application.Country+   CountryToFlagConverter �� 	Converter# [  5Q   +   �� 5R   *   $��Center=�60   ��6K   �� *%#AppForList.application.Company_name+�� 5S   *   $��Center=�60   ��6K   �� *#!AppForList.application.Experience+5T   '   �� 5W   &   $ 
Horizontal=�61   $��1��6J   $��Right=�6Z   .+�5X   *   �� $��Статус:��64   $
��Bold"�6C   �� 5Y   *   $	��5,0q�5[   4   ��5Y   4   �� *
StatusText+��5Z   4   �� *StatusColor+5[   4   5\   '   5]   #   �� 5`   "   $��4��6)   $!��Удалить отклик��5a   )   $��Right=�5b   )   $��0,10,0,0q�5c   )   $
��10,5q�5d   )   $	��120��5e   )   ���#e74c3c
���������5f   )   �� *DeleteResponseCommand+	 �� 
 Page��5g   )   �� ��5j   &   �� 5k   *   " ��60    �� Triggers 5l   .   �� 5m   2    �� Binding 6>   �� *Status+ �� Value 	Withdrawn6Y   .a�5n   6   ��  � {�$ False��6R   �� 5o   6    � �� �#95a5a66S   5p   3   5r   +   5t   #   5u      5v      5w      5y      5z      5{      5|      