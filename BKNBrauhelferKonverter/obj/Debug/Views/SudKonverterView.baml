   M S B A M L   `   `   `  ����Q  MBKNBrauhelferKonverter, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK*clr-namespace:BKNBrauhelferKonverter.ViewsBKNBrauhelferKonverter.Views  5      3    -BKNBrauhelferKonverter.Views.SudKonverterView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      <local*clr-namespace:BKNBrauhelferKonverter.Views     5        � 	Resources  5
       �� MergedDictionaries �� Source�� 5   
    5      �� 5      $ ../Styles/Style.xaml?�6%   %    5      .��5      � $��5q�6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��* �6    � ColumnDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   �� $��2��6   $��Brauhelfer-Sude:��5      �� 5!   
   $��0��6   $��2��5"      $��Right=�5#      $��Einstellungen��5$      �� 5&   
   $��1��6   $��0��5'      $	��300��5(      ��5)      �� *Items+ �� SelectedItem 5*      �� *SelectedItem+ �� View 5+      �� 5,      .P�5-      �� $
��Name��6%    �� Width$	 250��63    �� DisplayMemberBinding 6?   �� *	Sudname+�� 5.      $��	Braudatum��6%   $ 90��68    6C   �� *	Braudatum+	 �� StringFormat$	 
dd.MM.yyyy��5/      51      �� 53   
   $��1��6   $��1��54      
 �� Orientation$
 Vertical=�55      $��Center=�56      .+�57      �� $��Konvertieren��6   $��90��58      ��59      �� *KonvertierenCommand+�� 5:      $��
Git Commit��6   $��90��5;      ��5<      �� *GitCommitCommand+5=      5@      5A      