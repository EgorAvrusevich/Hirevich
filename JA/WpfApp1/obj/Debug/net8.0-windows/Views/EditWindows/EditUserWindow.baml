   M S B A M L   `   `   `  ����C  ?HireVich, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:JA.ViewsJA.Views  5   	   )    #JA.Views.EditWindows.EditUserWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   (localclr-namespace:JA.Views     5   	   $	��400��5	   	   $	��400��6     � WindowStartupLocation$  CenterOwner=�5
   	    � 
ResizeMode$ NoResize=�5   	    � Title 5   	   �� *WindowTitle+ � 	Resources 5       �� 
TargetType �� Property �� Value��%�  '��       '�� �     '�� 1    '�� �    �� 5   
   " ��6   .�5      ��  � ��$ 0,5,0,15q�6'   �� 5       � ��$ 16(�6)   �� 5       � ��$ 5q�6(   5      �� 5   
   " ��6   .�5      ��  � ��$ 14(�6)   �� 5       � ��$ SemiBold"�6+   �� 5       � ��$ 0,10,0,5q�6'   5      �� 5   
   " ��6   .�5      ��  � ��$ 	0,10,0,15q�6'   �� 5       � ��$ 14(�6)   5      �� 5   
   " ��6   .�5       ��  � ��$ 5q�6'   �� 5!       � ��$
 10,5q�6(   �� 5"       � ��$ 14(�6)   �� 5#       � ��$	 100��6)   5$      5%      .��5'      � $��20q�6    � RowDefinitions 5(   
   �� 5)      $
��Auto �6   �� 5*      $
��Auto �6   �� 5+      $
��Auto �6   �� 5,      $
��Auto �6   �� 5-      $
��Auto �6   �� 5.      $��* �6   �� 5/      $
��Auto �6   .+�52   
   �� $��0��6   $��Логин:��6   �� 53   
   $��1��6   ��6   �� *
User.login+ �� UpdateSourceTrigger$ PropertyChanged=��� 55   
   $��2��6   $��Пароль:��6   �� 56   
   $��3��6   ��6   �� *User.password+$ PropertyChanged=��� 58   
   $��4��6   $��Соискатель��6    	 d� 	IsChecked	 59      �� *User.isSercher+�� 5;   
   $��5��6   $ ��Администратор��6    	 5<      �� *
User.admin+�� 5>   
   $��6��6   
 �� Orientation$
 
Horizontal=�6"   $��Right=�6;   .+�5?      �� -   5        $��Отмена��5?      6&   �� 5@      $��Сохранить��6   ���	#FF5CB85C
���������6)   �� *SaveCommand+5A   ,   5B      5C      5D      