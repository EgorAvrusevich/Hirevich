   M S B A M L   `   `   `  ����  HireVich0    *JA.Views.EditWindows.EditCompanyInfoWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	     � Title$H  BРедактирование информации компании��5   	   $	��400��5   	   $	��430��5	   	    � WindowStartupLocation$ CenterOwner=�5
   	    � 
ResizeMode$ NoResize=�5   	   .��5      � $��15q�6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   .+�5   
   �� $��0��6    �� Orientation$ 
Horizontal=�6"   .+�5      �� .+�5      �� $$��Текущий логотип:��6   $��0,0,0,10q�64   �� 5      $	��150��6   $	��150��5      ���#CCCCCC$��1q�5      $
��Left=�5      ._�5      �� $��Uniform=�5      ��5      �� *CurrentLogo+5      5      5       �� 5!      $��70,0,0,0q�6   .+�5"      �� $��2��6   $ ��Новый логотип:��6)   $��0,0,0,10q�6?   �� 5#      $��3��6   $ Vertical=�6*   .+�5$      �� $	��150��6   $	��150��5%      ���#CCCCCC$��1q�5'      $
��Left=�5(      ._�5)      �� -   5         ��Name$ newlogo��5)   ;   $��Uniform=�5*       ��5)       �� *	NewLogo+5*       5+      �� 5,      -   5        $.��(Выбрать изображение...��5,      $	��150��5-      $
��Left=�5.      $��0,10,0,0q�50      51      52      53      �� 57   
   $��1��6   $��0,20,0,0q�6"   .+�58      �� $(��"Название компании:��6   $��0,0,0,5q�62   �� 59      -   5         ��Name$ _CompanyName��59      ��6,   �� *CompanyName+ �� UpdateSourceTrigger$ PropertyChanged=�5:      �� 5=   
   $��2��6   $ 
Horizontal=�6"   $��Right=�6;   $��0,20,0,0q�6W   .+�5>      �� -   5        $��Отмена��5>      $��80��6&   $��0,0,10,0q�61   6C   �� 5?      -   5        $��Сохранить��5?      $��80��6)   64   5@      5A      5B      