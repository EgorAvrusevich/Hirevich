   M S B A M L   `   `   `  ����C  ?HireVich, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:JA.Classes
JA.Classes  5   	   )    #JA.Views.EditWindows.EditInfoWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /
convertersclr-namespace:JA.Classes     5   	     � Title$1  +Редактирование профиля��5   	   $	��500��5	   	   $	��400��5
   	    � WindowStartupLocation$ CenterOwner=�5   	    � 	Resources 5      '  !JA.Classes.CountryToFlagConverter   CountryToFlagConverter��%   &	          5   
   6,   5      .��5      � $��15q�6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   .+�5   
   �� $��0��6    �� Orientation$ 
Horizontal=�6"   $��0,0,0,20q�6;   .+�5      �� $	��100��6   $	��100��6!    �� CornerRadius$ 50��6.   ���#CCCCCC$��1q�6V   ._�5       �� $��UniformToFill=�5!      ��5       �� *Photo+ J� Clip 5"      @� 5#       @� RadiusX$ 50Q�6*    @� RadiusY$ 50Q�67   	 @� Center$	 50,50&�6D   5%      5&      �� 5'      -   5        $��Изменить фото��5'      $��20,0,0,0q�5(      $��Center=�5)      $	��120��5*      5+      5,      �� 5/   
   $��1��6   $��Имя:��6   $��0,0,0,5q�6,   �� 50   
   $��2��6   $��0,0,0,15q�6_   ��6   �� *	FirstName+
 �� UpdateSourceTrigger$
 PropertyChanged=�6_   �� 53   
   $��3��6   $��Фамилия:��6   $��0,0,0,5q�60   �� 54   
   $��4��6   $��0,0,0,15q�6^   ��6   �� *
LastName+$
 PropertyChanged=�6^   �� 57   
   $��5��6   $��Возраст:��6   $��0,0,0,5q�60   �� 58   
   -   5         ��Name$ AgeBox��58      $��6��6"   $��0,0,0,15q�6i   ��6/   �� *Age+$
 PropertyChanged=�6i   �� 5;   
   $��7��6   $ 
Horizontal=�6"   $��Right=�6;   .+�5<      �� -   5        $��Отмена��5<      $��80��6&   $��0,0,10,0q�61   6C   �� 5=      -   5        $��Сохранить��5=      $��80��6)   64   5>      5?      5@      