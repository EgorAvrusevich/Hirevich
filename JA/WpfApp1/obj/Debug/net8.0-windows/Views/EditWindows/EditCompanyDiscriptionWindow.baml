   M S B A M L   `   `   `  ����  HireVich7    1JA.Views.EditWindows.EditCompanyDiscriptionWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	     � Title$H  BРедактирование информации компании��5   	   $	��370��5   	   $	��430��5	   	    � WindowStartupLocation$ CenterOwner=�5
   	    � 
ResizeMode$ NoResize=�5   	   .��5      � .+�5   
   � $��15q�6    � RowDefinitions 5      �� 5      $
��Auto �6    �� 5      $
��Auto �6    .+�5      �� $��0��6   $��0,20,0,0q�6&   .+�5      �� $��О компании:��6   $��0,0,0,5q�6/   �� 5      -   5         ��Name$ _Discription��5        �� TextWrapping$
 Wrap=�5      $��0q�6.   $��16(�69    �� AcceptsReturn$
 True��5       �� 
AcceptsTab$
 True��5      " �� VerticalScrollBarVisibility$
 Auto=�5      $	 �� HorizontalScrollBarVisibility$	 Disabled=�5      $	��220��5      $	��220��5      ��5      �� *Discription+
 �� UpdateSourceTrigger$
 PropertyChanged=�5       5!      �� 5$      $��1��6    �� Orientation$ 
Horizontal=�6&   $��Right=�6?   $��0,20,0,0q�6[   .+�5%      �� -   5        $��Отмена��5%      $��80��6*   $��0,0,10,0q�65   6G   �� 5&      -   5        $��Сохранить��5&      $��80��6-   68   5'      5(      5)      5*      