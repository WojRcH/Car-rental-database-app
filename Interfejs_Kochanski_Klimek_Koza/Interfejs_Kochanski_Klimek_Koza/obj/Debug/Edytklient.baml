   M S B A M L   `   `   `  ����Z  VInterfejs_Kochanski_Klimek_Koza, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullQ-clr-namespace:Interfejs_Kochanski_Klimek_KozaInterfejs_Kochanski_Klimek_Koza  5   	   0    *Interfejs_Kochanski_Klimek_Koza.Edytklient   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ?local-clr-namespace:Interfejs_Kochanski_Klimek_Koza     5   	   -   5          � Title$  Edycja danych o klientach��5   	   $	��500��6+   $
��1000��68    � WindowStartupLocation$ CenterScreen=�6E   .��5	      �  � RowDefinitions 5
   
   �� 5      $��* �6   �� 5      $��* �6    � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $��* �6   .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ 	DGklienci��5      $��2��6&      AutoGenerateColumns .     SelectionMode$ Single=�6S      
IsReadOnly .    CanUserAddRows .  	   Columns	 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn
   Header$
 Nazwisko��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 67   �� *
nazwisko+  5      $
 Imię��6%    63   �� *imie+  5      $
 Telefon kontaktowy��6%    6A   �� *	telefon+  5      $
 Miejscowość��6%    6:   �� *miejscowosc+  5      $
 Ulica��6%    64   �� *ulica+  5      $
 Kod pocztowy��6%    6;   �� *
kodpoczt+  5      $
 Numer dokumentu��6%    6>   �� *nrdokumentu+  5      $
 Dokument wydane przez��6%    6D   �� *dokumwydany+5      �� 5   
   -   5         ��Name$ txtkodpoczt��5      $��1��6'   $
��Left=�67   $��23��6R   $��366,209,0,0q�6^    �� TextWrapping$
 Wrap=�6s   $	��Top=�6�   $	��120��6�   �� 5   
   -   5        $ 
txtulicanr��5      $��1��6&   $
��Left=�66   $��23��6Q   $��366,181,0,0q�6]   $
 Wrap=�6r   $	��Top=�6�   $	��120��6�   �� 5    
   -   5        $ 
txtmiejsco��5       $��1��6&   $
��Left=�66   $��23��6Q   $��366,153,0,0q�6]   $
 Wrap=�6r   $	��Top=�6�   $	��120��6�   �� 5!   
   -   5        $ txttel��5!      $��1��6"   $
��Left=�62   $��23��6M   $��366,125,0,0q�6Y   $
 Wrap=�6n   $	��Top=�6�   $	��120��6�   �� 5"   
   -   5        $ txtimie��5"      $��1��6#   $
��Left=�63   $��23��6N   $��
366,97,0,0q�6Z   $
 Wrap=�6n   $	��Top=�6�   $	��120��6�   �� 5#   
   -   5        $ txtnazwisko��5#      $��1��6'   $
��Left=�67   $��23��6R   $��
366,69,0,0q�6^   $
 Wrap=�6r   $	��Top=�6�   $	��120��6�   �� 5$   
   -	   5        $ txtnrdok��5$      $��1��6$   $
��Left=�64   $��23��6O   $��	366,2,0,0q�6[   $
 Wrap=�6n   $	��Top=�6�   $	��120��6�   $��1��6�   �� 5%   
   $��
Nazwisko
��6   $��1��6-   $
��Left=�6=   $��
301,69,0,0q�6X   $	��Top=�6l   �� 5&   
   $��Imię

��6   $��1��6.   $
��Left=�6>   $��
327,97,0,0q�6Y   $	��Top=�6m   �� 5'   
   $��Telefon Kontaktowy��6   $��1��6-   $
��Left=�6=   $��246,125,0,0q�6X   $	��Top=�6m   �� 5(   
   $��Miejscowość��6   $��1��6&   $
��Left=�66   $��283,153,0,0q�6Q   $	��Top=�6f   �� 5)   
   $��Ulica i numer ulicy
��6   $��1��63   $
��Left=�6C   $��253,181,0,0q�6^   $	��Top=�6s   �� 5*   
   $��Kod pocztowy
��6   $��1��6,   $
��Left=�6<   $��275,209,0,0q�6W   $	��Top=�6l   $��34��6�   $��2��6�   �� 5+   
   $��Nr dokumentu(dowodu)��6   $��1��6/   $
��Left=�6?   $��	223,1,0,0q�6Z   $	��Top=�6m   $��1��6�   �� 5,   
   $��Dokument wydane przez��6   $��1��60   $
��Left=�6@   $��
219,27,0,0q�6[   $	��Top=�6o   $��1��6�   �� 5-   
   -
   5         ��Name$ btnusun��5-      $��Usuń klienta
��6"   $��1��6>   $
��Left=�6N   $��
10,203,0,0q�6i   $��1��6}   $	��Top=�6�   $	��118��6�   $��22��6�   6�   �� 5.   
   -   5        $ btndodaj��5.      $��Dodaj Klienta
��6#   $��1��6E   $
��Left=�6U   $��384,203,0,0q�6p   $��1��6�   $	��Top=�6�   $	��102��6�   $��22��6�   6�   �� 5/   
   -   5        $ 
btnodswiez��5/      $��	Odśwież��6%   $��1��67   $
��Left=�6G   $��	10,10,0,0q�6b   $	��Top=�6u   $��75��6�   6�   �� 50   
   -   5        $ txtwydanyprzez��50      $��1��6*   $
��Left=�6:   $��23��6U   $��
366,30,0,0q�6a   $
 Wrap=�6u   $	��Top=�6�   $	��120��6�   $��1��6�   51      52      