   M S B A M L   `   `   `  ����C  ?HireVich, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:JA.Views.EditWindowsJA.Views.EditWindows  5   	   .    (JA.Views.EditWindows.EditEducationWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   4local"clr-namespace:JA.Views.EditWindows     5   	     � Title$9  3Редактирование образования��5   	   $	��160��5	   	   $	��230��5
   	    � WindowStartupLocation$ CenterOwner=�5   	    � 
ResizeMode$ NoResize=�5   	   .��5      � $��15q�6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��60 �6   �� 5      $
��Auto �6   .+�5   
   �� $��0��6   $5��/Укажите ваше образование:��6   $
��Bold"�6A   �� 5   
   -   5         ��Name$ EducationBox��5       $��1��6   $
��0,10q�66   ���#133F42$	��160��5       �� Text 5      �� *EducationText+ �� UpdateSourceTrigger$ PropertyChanged=�.@�5      �� $#��Нет образования��6   �� 5      $��Среднее общее��6   �� 5      $+��%Среднее специальное��6   �� 5       $+��%Неоконченное высшее��6   �� 5!      $��Высшее��6   5"      �� 5%   
   $��2��6    �� Orientation$ 
Horizontal=�6"   $��Center=�6;   .+�5&      �� -   5        $��Отмена��5&      $��80��6&   $��0,0,10,0q�61   6C   �� 5'      -   5        $��Сохранить��5'      $��80��6)   64   5(      5)      5*      