   M S B A M L   `   `   `  ����C  ?HireVich, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:JA.Classes
JA.Classes  5   	   !    JA.Views.ChangeStatusDialog   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   *localclr-namespace:JA.Classes     5   	     � Title$'  !Изменение статуса��5   	   $	��200��6#   $	��300��60    � WindowStartupLocation$ CenterOwner=�5   	   .��5      � $��10q�6    � RowDefinitions 5	   
   �� 5
      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   .+�5   
   �� $/��)Выберите новый статус:��6   $��0 0 0 10q�62   �� 5   
   -   5         ��Name$ StatusComboBox��5      $��1��6+    �� SelectedIndex$ 0��68   ��5      �� 5       �� Type   JA.Classes.ResponseStatus"  6   .s�5       Pending=�64    5      Approved=�65    5      Rejected=�65    5      	Withdrawn=�66   5      5      �� 5   
   -   5        $��2��5      $��Сохранить��6   $��Right=�62   $��0 15 0 0q�5      $
��15 3q�6#   62   5      5      