   M S B A M L   `   `   `  ����Z  VInterfejs_Kochanski_Klimek_Koza, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullQ-clr-namespace:Interfejs_Kochanski_Klimek_KozaInterfejs_Kochanski_Klimek_Koza  5   	   2    ,Interfejs_Kochanski_Klimek_Koza.Edytsamochod   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ?local-clr-namespace:Interfejs_Kochanski_Klimek_Koza     5   	   -   5          � Title$  Edycja bazy samochodów��5   	   $	��500��6(   $
��1000��65    � WindowStartupLocation$ CenterScreen=�6B   .��5	      �  � RowDefinitions 5
   
   �� 5      $��* �6   �� 5      $��* �6    � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $��* �6   .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ DGsamo��5      $��2��6#      AutoGenerateColumns .     SelectionMode$ Single=�6P      
IsReadOnly .    CanUserAddRows .  	   Columns	 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn
   Header$
 Marka��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 64   �� *marka+  5      $
 Model��6%    64   �� *model+  5      $
 Silnik��6%    65   �� *silnik+  5      $
 Pojemność��6%    68   �� *	pojemnosc+  5      $
 Numer rejestracyjny��6%    6B   �� *numer_rejestracyjny+  5      $
 Status wypożyczenia��6%    6B   �� *statuswypoz+  5      $
 Cena (za dzień)��6%    6>   �� *	cenawyp+  5      $
 Stan Techniczny��6%    6>   �� *stantechniczny+  5      $
 OC(do)��6%    65   �� *OC+  5      $
 AC(do)��6%    65   �� *AC+  5      $
 Przegląd(do)��6%    6;   �� *przeglad_techniczny+5       �� 5!   
   -   5         ��Name$ txtstan��5!      $��1��6#   $
��Left=�63   $��23��6N   $��366,209,0,0q�6Z    �� TextWrapping$
 Wrap=�6o   $	��Top=�6�   $	��120��6�   �� 5"   
   -   5        $ 	txtnrreje��5"      $��1��6%   $
��Left=�65   $��23��6P   $��366,181,0,0q�6\   $
 Wrap=�6q   $	��Top=�6�   $	��120��6�   �� 5#   
   -   5        $ txtpoje��5#      $��1��6#   $
��Left=�63   $��23��6N   $��366,153,0,0q�6Z   $
 Wrap=�6o   $	��Top=�6�   $	��120��6�   �� 5$   
   -   5        $ 	txtsilnik��5$      $��1��6%   $
��Left=�65   $��23��6P   $��366,125,0,0q�6\   $
 Wrap=�6q   $	��Top=�6�   $	��120��6�   �� 5%   
   -   5        $ txtmodel��5%      $��1��6$   $
��Left=�64   $��23��6O   $��
366,97,0,0q�6[   $
 Wrap=�6o   $	��Top=�6�   $	��120��6�   �� 5&   
   -   5        $ txtmarka��5&      $��1��6$   $
��Left=�64   $��23��6O   $��
366,69,0,0q�6[   $
 Wrap=�6o   $	��Top=�6�   $	��120��6�   �� 5'   
   -	   5        $ txtcena��5'      $��1��6#   $
��Left=�63   $��23��6N   $��
366,58,0,0q�6Z   $
 Wrap=�6n   $	��Top=�6�   $	��120��6�   $��1��6�   �� 5(   
   $��Marka��6   $��1��6    $
��Left=�60   $��
323,69,0,0q�6K   $	��Top=�6_   �� 5)   
   $��Model
��6   $��1��6*   $
��Left=�6:   $��
323,97,0,0q�6U   $	��Top=�6i   �� 5*   
   $��Silnik��6   $��1��6!   $
��Left=�61   $��323,125,0,0q�6L   $	��Top=�6a   �� 5+   
   $��Pojemność silnika
��6   $��1��66   $
��Left=�6F   $��262,153,0,0q�6a   $	��Top=�6v   �� 5,   
   $��Numer rejestracyjny
��6   $��1��68   $
��Left=�6H   $��245,181,0,0q�6c   $	��Top=�6x   �� 5-   
   $��Stan Techniczny
��6   $��1��64   $
��Left=�6D   $��266,209,0,0q�6_   $	��Top=�6t   $��34��6�   $��2��6�   �� 5.   
   $��OC(do kiedy?)��6   $��1��6(   $
��Left=�68   $��	277,2,0,0q�6S   $	��Top=�6f   $��1��6~   �� 5/   
   $"��Cena wypożyczenia samochodu��6   $��1��66   $
��Left=�6F   $��
182,58,0,0q�6a   $	��Top=�6u   $��1��6�    J� RenderTransformOrigin$ 0.228,0.481&�6�   �� 50   
   $%��Przegląd techniczny(do kiedy?)��6   $��1��69   $
��Left=�6I   $��
187,86,0,0q�6d   $	��Top=�6x   $��1��6�   �� 51   
   $��AC(do kiedy?)��6   $��1��6(   $
��Left=�68   $��
277,30,0,0q�6S   $	��Top=�6g   $��1��6   (  "System.Windows.Controls.DatePicker  52   
   -
   5          Name$
 DPOC��52      $��1��6#   $
��Left=�63   $��	366,4,0,0q�6N   $��1��6a   $	��Top=�6n     53   
   -   5        $
 DPAC��53      $��1��6#   $
��Left=�63   $��
366,32,0,0q�6N   $��1��6b   $	��Top=�6o     54   
   -   5        $ DPtech��54      $��1��6%   $
��Left=�65   $��
366,86,0,0q�6P   $��1��6d   $	��Top=�6q   �� 55   
   -   5         ��Name$ btnusun��55      $��Usuń samochód
��6"   $��1��6D   $
��Left=�6T   $��
10,203,0,0q�6o   $��1��6�   $	��Top=�6�   $	��118��6�   $��22��6�   6�   �� 56   
   -   5        $ btndodaj��56      $��Dodaj samochód
��6#   $��1��6F   $
��Left=�6V   $��384,203,0,0q�6q   $��1��6�   $	��Top=�6�   $	��102��6�   $��22��6�   6�   �� 57   
   -   5        $ 
btnodswiez��57      $��	Odśwież��6%   $��1��67   $
��Left=�6G   $��	10,10,0,0q�6b   $	��Top=�6u   $��75��6�   6�   58      59      