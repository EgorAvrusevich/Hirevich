   M S B A M L   `   `   `  ����C  ?HireVich, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:JA.ViewsJA.Views  5   	       JA.Views.AdminWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   (localclr-namespace:JA.Views     5   	   -   5          � Title$3  -Административная панель��5	   	   $	��650��5
   	   $
��1000��6    � WindowStartupLocation$ CenterScreen=�5   	    � WindowState$ 	Maximized=�5   	    � 	Resources 5         AdminButton �� 
TargetType �� Property �� Value  DeleteButton �� BasedOn  
EditButton  AdminDataGrid&   System.Windows.Controls.DataGrid��%R  &	        &	 �     7   &	 8    7   &	 �    �� 5   
   " ��6$   .�5      ��  � ��$ 5q�6'   �� 5       � ��$	 8 4q�6(   �� 5       � ��$ 14(�6)   �� 5       �@�Cursor$
 Hand��6'   5      �� 5   
   8   " ��6L   .�5      ��  � �� �	#FFCD5C5C6+   �� 5       � ��
 �����6+   5      �� 5   
   8   " ��6J   .�5      ��  � �� �	#FF5CB85C6+   �� 5       � ��
 �����6+   5      �� 5"   
   "  6&   .�5#      ��  � ��$ 10q�6'   �� 5$       �@ AutoGenerateColumns$ False��64   �� 5%       �@ 
IsReadOnly$
 True��6+   �� 5&       �@ SelectionMode$ Single=�6.   �� 5'       �@ SelectionUnit$ FullRow=�6.   �� 5(       �@ GridLinesVisibility$
 None=�64   �� 5)       �@ HeadersVisibility$ Column=�62   �� 5*       �@ RowHeaderWidth$ 0Q�6/   �� 5+       �@ CanUserAddRows$ False��6/   �� 5,       �@ CanUserDeleteRows$ False��62   �� 5-       �@ CanUserResizeRows$ False��62   5.      5/      .��51      � .+�52   
   �� .@�54      �� $��Пользователи��6   .��55      �  � RowDefinitions 56      �� 57      $
��Auto �6(   �� 58      .+�5<      �� $��0��6!   	 �� Orientation$	 
Horizontal=�6.   $��10q�6G   .+�5=      �� $��Обновить��6!   #��[  6\   ��64   �� *RefreshUsersCommand+6\   �� 5>      $/��)Добавить пользователя��6!   #��[ 6d   ��6A   �� *AddUserCommand+6d   5?        5B      $��1��6   #��[ 6J   ��6,   �� *Users+
   Columns
 5C      0  *System.Windows.Controls.DataGridTextColumn  5D      ,  &System.Windows.Controls.DataGridColumn   Header$ ID��61      Width5  /System.Windows.Controls.DataGridLengthConverter$
 Auto 6T   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6=   �� *id+6T     5E      $ 
Логин��61   $ * 6Z    6@   �� *login+6Z   4  .System.Windows.Controls.DataGridCheckBoxColumn  5F      $ Соискатель��65   $
 Auto 6g    6I   �� *	isSercher+6g     5G      $ 
Админ��65   $
 Auto 6^    6D   �� *admin+6^   4  .System.Windows.Controls.DataGridTemplateColumn  5H      $ Действия��65   $
 Auto 6G      CellTemplate 5I   "   �� 5J   &   .R�5K   *   �� $	 
Horizontal=�65   .+�5L   .   �� $ ��Редактировать��65   #��[ 5O   5   ��5M   5   �� *DataContext.EditUserCommand+ �� RelativeSource ��  �� AncestorType
 Window��5N   5   �� 5O   5   �� 5P   .   $��Удалить��65   #��[ 5S   5   ��5Q   5   �� *DataContext.DeleteUserCommand+ �� 
 Window��5R   5   �� 5S   5   5T   +   5U   '   5W      5Y      5Z      5[      �� 5^      $��Вакансии��6   .��5_      �  5`      �� 5a      $
��Auto �6(   �� 5b      .+�5e      �� $��0��6!   $	 
Horizontal=�6.   $��10q�6G   .+�5f      �� $��Обновить��6!   #��[  6`   ��64   �� *RefreshVacanciesCommand+6`   �� 5g      $'��!Добавить вакансию��6!   #��[ 6c   ��6=   �� *AddVacancyCommand+6c   5h        5j      $��1��6   #��[ 6N   ��6,   �� *	Vacancies+
 5k        5l      $ ID��61   $
 Auto 6T    6=   �� *Id+6T     5m      $ Название��61   $ * 6e    6C   �� *Vacation_Name+6e     5n      $ Компания��61   $ * 6d    6C   �� *Company_name+6d     5o      $ Зарплата��61   $
 Auto 6\    6C   �� *Wage+6\     5p      $ Действия��65   $
 Auto 6G    5q   "   �� 5r   &   .R�5s   *   �� $	 
Horizontal=�65   .+�5t   .   �� $ ��Редактировать��65   #��[ 5w   5   ��5u   5   �� * DataContext.EditVacancyCommand+ �� 
 Window��5v   5   �� 5w   5   �� 5x   .   $��Удалить��65   #��[ 5{   5   ��5y   5   �� *" DataContext.DeleteVacancyCommand+ �� 
 Window��5z   5   �� 5{   5   5|   +   5}   '   5      5�      5�      5�      �� 5�      $��Отклики��6   .��5�      �  5�      �� 5�      $
��Auto �6(   �� 5�      .+�5�      �� $��0��6!   $	 
Horizontal=�6.   $��10q�6G   .+�5�      �� $��Обновить��6!   #��[  6`   ��64   �� *RefreshResponsesCommand+6`   5�        5�      $��1��6   #��[ 6N   ��6,   �� *	Responses+
 5�        5�      $ ID��61   $
 Auto 6]    6=   �� *Response.Id+6]     5�      $ Вакансия��61   $ * 6|    6C   �� *&$AppForList.application.Vacation_Name+6|     5�      $ Соискатель��61   $ * 6v    6E   �� *PersonalData.Applicant.Email+6v     5�      $ Статус��61   $
 Auto 6\    6A   �� *Status+6\     5�      $ Дата��61   $
 Auto 6�    6?   �� *Response.ResponseDate+ �� StringFormat$ {0:dd.MM.yyyy}��6�     5�      $ Действия��65   $
 Auto 6G    5�   "   �� 5�   &   .R�5�   *   �� $	 
Horizontal=�65   .+�5�   .   �� $��Удалить��65   #��[ 5�   5   ��5�   5   �� *#!DataContext.DeleteResponseCommand+ �� 
 Window��5�   5   �� 5�   5   5�   +   5�   '   5�      5�      5�      5�      5�      5�      5�      