   M S B A M L   `   `   `  ����Q  MBKNBrauhelferKonverter, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK*clr-namespace:BKNBrauhelferKonverter.ViewsBKNBrauhelferKonverter.Views  5      4    .BKNBrauhelferKonverter.Views.EinstellungenView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      <local*clr-namespace:BKNBrauhelferKonverter.Views     5        � 	Resources  5
       �� MergedDictionaries �� Source�� 5   
    5      �� 5      $ ../Styles/Style.xaml?�6%   %    5      .��5      �� .+�5   
   �� $��Der Kleine Brauhelfer��6   .��5      �  � ColumnDefinitions 5      �� 5      $��1* �6'   �� 5      $��3* �6'   �� 5      $��1* �6'   .+�5      �� $��0��6   $��0��6%   $��
Datenbank:��65   �� 5      $��0��6   $��1��6'   $
��Auto��67   ��6D   �� *DkbDatenbank+�� 5      $��0��6   $��2��6&   $��Prüfen��66   5      5      �� 5!   
   $��Git Credentials��6   .��5"      �  � RowDefinitions 5#      �� 5$      $
��Auto �6$   �� 5%      $
��Auto �6$   �� 5&      $
��Auto �6$   �� 5'      $
��Auto �6$    5)      �� 5*      $��1* �6'   �� 5+      $��3* �6'   �� 5,      $��1* �6'   .+�5/      �� $��0��6   $��0��6%   $��Login:��65   �� 50      $��0��6   $��1��6'   $
��Auto��67   ��6D   �� *User+�� 52      $��1��6   $��0��6%   $��	Password:��65   G� 53      -   5        $��1��53      $��1��6+   $
��Auto��6;   6H   � 55      $��2��6   $��0��6$   $��2��64    56      �� 57      $��* �6+   �� 58      $
��Auto �6+   �� 59      $��* �6+   .+�5<      �� $��0��6    $��5,0,0,0q�5=       �� 5>      $��1��6   
�������$��8(�5@      $
��ODER��5A      �� 5B      $��2��6    $��0,0,5,0q�5C       5D      �� 5F      $��3��6   $��0��6%   $��Token:��65   �� 5G      $��3��6   $��1��6'   $
��Auto��67   ��6D   �� *Token+�� 5H      $��3��6   $��2��6&   $��Prüfen��66   5I      5J      �� 5L   
   $��Rohstoffe Datenbank��6   .��5M      �  5N      �� 5O      $
��Auto �6$   �� 5P      $
��Auto �6$   �� 5Q      $
��Auto �6$   �� 5R      $
��Auto �6$    5T      �� 5U      $��1* �6'   �� 5V      $��3* �6'   �� 5W      $��1* �6'   .+�5Z      �� $��0��6   $��0��6%   $��Server:��65   �� 5[      $��0��6   $��1��6'   $
��Auto��67   ��6D   �� *	SqlServer+�� 5]      $��1��6   $��0��6%   $��
Datenbank:��65   �� 5^      $��1��6   $��1��6'   $
��Auto��67   ��6D   �� *SqlDatabase+�� 5`      $��2��6   $��0��6%   $��User:��65   �� 5a      $��2��6   $��1��6'   $
��Auto��67   ��6D   �� *	SqlUser+�� 5c      $��3��6   $��0��6%   $��	Password:��65   G� 5d      -   5        $��3��5d      $��1��6+   $
��Auto��6;   6H   �� 5e      $��3��6   $��2��6&   $��Prüfen��66   5f      5g      � 5j   
    5k      �� 5l      $��* �6#   �� 5m      $
��Auto �6#   �� 5n      $
��Auto �6#   .+�5q      �� $��1��6   $��	Speichern��6%    �� 	IsDefault . ��6J   �� *SaveCommand+�� 5r      $��2��6   $��	Abbrechen��6%    �� IsCancel . 69   5s      5u      5v      