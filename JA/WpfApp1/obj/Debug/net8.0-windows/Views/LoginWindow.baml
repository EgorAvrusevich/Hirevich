   M S B A M L   `   `   `  ����C  ?HireVich, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:JAJA  5   	       JA.Views.LoginWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   "localclr-namespace:JA     5   	   LmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes     5   	     � Title$  Hirevich��5	   	   $	��444��6   $	��500��6'   $	��500��63   $	��500��6B   $	��444��6Q   .��5
      � $	��500��6   $	��500��6   $	��495��6)   $��0,0,0,-6q�65    � RowDefinitions 5   
   �� 5      �� 5      �� 5      �� 5      .+�5   
   �� $��0��6   $��Вход��6   $��Center=�6,   $��40,0,0,0q�6G   $��35(�6Y   �� 5   
   $��1��6   $��
Логин��6   $��16(�6-   $��40,0,0,0q�6;   �� 5   
   $��1��6    �� CornerRadius$ 4��6   $��Center=�6/   $	��420��6L   ���#F8F8F8$��48��6p   $��48��6   ._�5      �� -   5         ��Name$ 	login_box��5       �� TextWrapping$
 Wrap=�6)   $�� ��6=   ���#F8F8F8$��Center=�6Z   $��0q�6u   $��10, 0q�6�   $��16(�6�   5      �� 5   
   $��2��6   $��Пароль��6   $��16(�6.   $��40,0,0,0q�6<   �� 5   
   $��2��6   $ 4��6   $��Center=�6/   $	��420��6L   ���#F8F8F8$��48��6p   $��48��6   ._�5      G� -   5         G�Name$ password_box��5      ���#F8F8F8$��Center=�6E   $��0q�6`   $��10, 0q�6t   $��16(�6�   5      �� 5   
   -   5         ��Name$ warning��5      $��2��6   $5��/Неверный логин или пароль��6.   $��0,75,0,0q�6R   $	��170��6d   ���	#FFC76666$y�Hidden=�6�   �� 5   
   $��3��6   $ 4��6   $��Center=�6/   $	��420��6L   ���#F8F8F8$��48��6p   $��48��6   $	��Top=�5      ._�5      �� -   5        $��0q�5      $��
Войти��6*   $��16(�6:   6I   5      �� 5   
   -   5        $��0q�5      $��3��6%   $��Bottom=�62   $��Center=�6M   $��0,0,0,20q�6j   
�������$��15(�6�   ��5       �� 5!       �� 
TargetType" ��6   .�5"      ��  �� Property � ��	 �� Value$0	 *У меня ещё нет аккаунта��60   
 �� Triggers
 5#      P� 5$       P� Property �@J�IsMouseOver P� Value$
 True��69   . �5%      ��  � ��
	 �����6;   5&      5(      5*      5+      5,      