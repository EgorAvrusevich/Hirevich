   M S B A M L   `   `   `  ����C  ?HireVich, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:JA.Classes
JA.Classes  5   	   *    $JA.Views.EditWindows.EditAboutWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:JA.Classes     5   	   $	��300��5   	   $	��400��5	   	     � Title$9  3Редактироввание информации��5
   	    � WindowStartupLocation$ CenterOwner=�5   	    � 
ResizeMode$ NoResize=�5   	    � 	Resources 5      )   #JA.Classes.GreaterThanZeroConverter   GreaterThanZeroConverter��%   &	          5   
   6)   5      .��5      � $��15q�6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $
��Auto �6   .+�5   
   �� $��0��6   $'��!Расскажите о себе:��6   $
��Bold"�6:   �� 5   
   -   5         ��Name$ AboutTextBox��5      $��1��6    �� AcceptsReturn$
 True��5       �� TextWrapping$
 Wrap=�5       " �� VerticalScrollBarVisibility$
 Auto=�5!      $��	0,10,0,10q�5"      ��5      �� *	AboutText+	 �� UpdateSourceTrigger$	 PropertyChanged=�5"      �� 5%   
   $��2��6   
 �� Orientation$
 
Horizontal=�6"   $��Right=�6;   .+�5&      �� -   5        $��Отмена��5&      $��80��6&   $��0,0,10,0q�61   6C   �� 5'      -   5        $��Сохранить��5'      $��80��6)   {�5(      �� *Text.Length+ �� ElementName$ AboutTextBox�� �� 	Converter# [  5)      5*      5+      