   M S B A M L   `   `   `  ����C  ?HireVich, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:JA.ViewsJA.Views  5   	       JA.Views.AddVacancyWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   (localclr-namespace:JA.Views     5   	     � Title$+  %Добавление вакансии��5   	   $	��500��5	   	   $	��400��6    � WindowStartupLocation$ CenterOwner=�5
   	   .��5      � $��10q�6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $
��Auto �6   .+�5   
   �� $��0��6   $)��#Название вакансии*:��6   �� 5   
   -   5         ��Name$ VacationNameBox��5      $��1��6   $��0,0,0,10q�5      ��5      �� *NewVacancy.Vacation_Name+ �� UpdateSourceTrigger$ PropertyChanged=�5      �� 5   
   $��2��6   $��Зарплата:��6   �� 5    
   -   5        $ WageBox��5       $��3��6   $��0,0,0,10q�5"      ��5!      �� *NewVacancy.Wage+$ PropertyChanged=�5"      � 5%   
   $��4��6   $��0,0,0,10q�6    � ColumnDefinitions 5&      �� 5'      $��* �6#   �� 5(      $��10 �6#   �� 5)      $��* �6#   .+�5,      �� $��0��6   .+�5-      �� $��Страна*:��6   �� 5.      -   5         ��Name$ 
CountryBox��5.       �� DisplayMemberPath$ Value��50       �� SelectedValuePath$	 Key��51      ��5/      �� *	Countries+	 �� SelectedValue	 52      �� *NewVacancy.Country+53      �� 55      $��2��6   .+�56      �� $��
Опыт*:��6   �� 57      -   5        $ ExpBox��57      ��58      �� *ExperienceLevels+
 �� SelectedItem
 59      �� *NewVacancy.Experience+5:      5;      �� 5>   
   $��5��6   $��Описание:��6   �� 5?   
   -   5        $ DescriptionBox��5?      $��6��6    �� AcceptsReturn$
 True��5A       �� TextWrapping$
 Wrap=�5B      " �� VerticalScrollBarVisibility$
 Auto=�5C      $��0,0,0,15q�5D      ��5@      �� *NewVacancy.Description+5D      �� 5G   
   $��7��6    �� Orientation$ 
Horizontal=�6"   $��Right=�6;   .+�5H      �� -   5        $��Отмена��5H      $��80��6&   $��0,0,10,0q�61   6C   �� 5I      -   5        $��Сохранить��5I      $��80��6)   64   5J      5K      5L      