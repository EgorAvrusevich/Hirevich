   M S B A M L   `   `   `  ����  HireVich)    #JA.Views.Pages.CompanyResponsesPage   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5        N� Title$%  Отклики компании��5      .��5
      � $��10q�6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   �� $��0��6   $*��$Отклики на вакансии��6!   $��24(�5      $
��Bold"�6"   $��0 0 0 20q�64   � 5   
   $��1��6   $��0 0 0 15q�6    � ColumnDefinitions 5      �� 5      $	��160 �6#   �� 5      .+�5      �� -   5         ��Name$ FilterComboBox��5      $	��150��6/   $��0 0 10 0q�6;   .@�5      �� 
 � Tag$ Все��6   $��Все статусы��6)   �� 5      $# На рассмотрении��6   $#��На рассмотрении��65   �� 5       $ Приглашение��6   $��Приглашение��61   �� 5!      $ Отклонено��6   $��Отклонено��6/   �� 5"      $ Отозвано��6   $��Отозвано��6.   5#      �� 5%      -   5         ��Name$ SearchTextBox��5%      $��5q�6-   $��1��69   5&      5'      �� 5*   
   -   5         ��Name$ ResponsesListView��5*      $��2��6.   ��5+      �� 5,       �� 
TargetType" ��6   .�5-      ��  �� Property � ��	 �� Value$	 Stretch=�6C   5.      ��51      �� 52      .R�53      �� 
 �� CornerRadius$
 5��6   $��1q�6.   ���#DDD$	��0 5q�54       �� Padding$ 10q�6*   
�������._�55      �  56      �� 57   "   $��* �63   �� 58   "   $
��Auto �63   .+�5;      �� $��0��6)   .+�5<   "   �� $
��Bold"�5=   ,   $��16(�6>   ��5<   ,   �� *&$AppForList.application.Vacation_Name+5=   >   �� 5>   "    �� Orientation$ 
Horizontal=�6-   $��0 5 0 0q�6F   .+�5?   &   A� $��30��6.   $��30��69   $��0 0 5 0q�6E   ��5@   *   �� 5A   .    �� ImageSource 69   �� *PersonalData.Photo+5C   '   �� 5D   &   .+�5E   *   �� $��SemiBold"�6[   ��64   �� *PersonalData.FullName+6[   �� 5F   *   
���������64   �� *PersonalData.Email+6X   5G   '   5H   #   �� 5J   "   $��0 5 0 0q�5K      $��14(�6!   ��5J   ,   �� *%#AppForList.application.Company_name+5K   !   �� 5M   "   $ 
Horizontal=�6-   $��0 5 0 0q�6F   .+�5N   &   �� ��60   �� *AppForList.application.Wage+ �� StringFormat$ Зарплата: {0:C}���� 5O   &   $��10 0 0 0q�5P   0   ��5O   0   �� *#!AppForList.application.Experience+$ Опыт: {0}��5P   0   �� 5Q   &   $��10 0 0 0q�5R   0   ��5Q   0   �� * AppForList.application.Country+5R   0   5S   #   5T      �� 5V      $��1��6)   $��Center=�69   .+�5W   "   �� $ 
Horizontal=�6-   .+�5X   &   �� $��Статус:��60   $��0 0 5 0q�6?   �� 5Y   &   $
��Bold"�5[   0   ��5Y   0   �� *
StatusText+��5Z   0   �� *StatusColor+5[   0   5\   #   �� 5^   "   $#��Изменить статус��6)   $��0 10 0 0q�5b   )   $
��10 2q�6;   ��5_   )   �� *ChangeStatusCommand+ �� RelativeSource ��  �� AncestorType Page��5a   )   �� 5b   ;   5c      5d      5e      5f      5h      5i      5j      