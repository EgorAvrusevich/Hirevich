   M S B A M L   `   `   `  ����  HireVich$    JA.Views.Pages.MyVacationsPage   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      $
��auto��5      $
��auto��6     N� Title$  MyVacationsPage��5      .��5      �  � RowDefinitions 5   
   �� 5	      $
��Auto �6   �� 5
      .+�5   
   �� $��0��6    �� Orientation$ 
Horizontal=�6"   $��20 10q�6;   .+�5      ��    
HeaderText#��[  6   $��Мои вакансии��6<   $��Center=�6P   $
��0,10q�6k   �� 5      -   5          PrimaryButton#��[ 5      $��5q�5      $��20 15q�5      $)��#+ Добавить вакансию��5      5      5      �� 5   
   -   5         ��Name$ ApplicationsList��5      $��1��5        CardList#��[ 5      ��5      �� *applications+��5      �� 5       �� 
TargetType" ��6     CardListItem �� BasedOn# [ 61   ��5"      �� 5#      .R�5$      ��   	CardStyle#��[ 6   ._�5%      � $��10q�6    5&      �� 5'   "   $
��Auto �60   �� 5(   "   $
��Auto �60   �� 5)   "   $
��Auto �60   �� 5*   "   $
��Auto �60   �� 5+   "   $
��Auto �60   .+�5/      � $��0��6#    � ColumnDefinitions 50   "   �� 51   &   $��* �67   �� 52   &   $
��Auto �67   .+�54   "   �� $��0��6,   #��[  56   ,   ��55   ,   �� *application.Vacation_Name+56   ,   �� 57   "   $��1��6(     CompanyLogo#��[ 58   (   ��59   (   �� *Company_Logo+5:      �� 5=      $��1��6)   $ 
Horizontal=�66   $��0 5 0 0q�6O   .+�5>   "   ��   	IconStyle#��[ 6(   $��/Images/Job wage.png��6K   �� 5?   "     PrimaryLabel#��[ 6(   ��5@   (   �� *application.Wage+5A      �� 5D      $��2��6(     BodyText#��[ 5E   (   $��0 10 0 0q�5G   (   $��CharacterEllipsis=�5H   (   $��45��5I   (   ��5F   (   �� *application.Description+5I   (   � 5L      $��3��6#    5M   "   �� 5N   &   �� 5O   &   .+�5Q   "   �� $��0��6-   $ 
Horizontal=�6=   $��0 10 0 0q�6V   .+�5R   &   A� $��20��6.   $��20��69   ��5S   *   �� 5T   .    �� ImageSource 69   �� *application.Country+ 	 CountryToFlagConverter �� 	Converter# [	 5V   '   �� 5W   &   #��[ 6,   ��5X   ,   �� *application.Company_name+�� 5Y   &   #��[ 6,   ��5Z   ,   �� *application.Experience+5[   #   �� 5^   "   $��1��6-   $ 
Horizontal=�6=   $��Right=�6V   $��0 10 0 0q�6r   .+�5_   &   ��  
 DangerButton#��[
 6-   $	��100��5`   -   $��35��5a   -   $��Удалить��5b   -   ��5c   -   �� *DeleteVacancyCommand+	 �� RelativeSource	 �� 
 �� AncestorType
 Page��5d   -   �� 5e   #   5f      5g      5h      5i      5k      5l      5m      