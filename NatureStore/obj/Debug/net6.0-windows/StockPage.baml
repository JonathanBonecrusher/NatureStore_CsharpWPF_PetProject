   M S B A M L   `   `   `  ����F  BNatureStore, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:NatureStoreNatureStore  5          NatureStore.StockPage   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      +localclr-namespace:NatureStore     5        N� Title$  	StockPage��5	      .��5      �  � ColumnDefinitions 5   
   �� 5      $��* �6   6+   �� 5      $��2* �6   6,   �� 5      $��4* �6   6,    � RowDefinitions 5   
   �� 5      $��* �6   6)   �� 5      $��5* �6   6*   �� 5      $��* �6   6)   .+�5   
   �� $��1��6   $��2��6%   $��0��69    �� Orientation$ 
Horizontal=�6F   .+�5      �� -   5         ��Name$ 	SearchBar��5      $��	20 0 10 0q�6)   $��Center=�6<   $��Center=�6W   $��50��6t   $	��700��6�   6�   �� 5      -   5         ��Name$ SearchButton��5   0   $��0q�6F   $��50��6Q   $��50��6`   $��Center=�6n   $��Center=�6�   ���#67d2f0.��5      �� $��50��6   $��50��6$   $��/img/Find.png��6/   6H   5      5      &   System.Windows.Controls.DataGrid  5   
   -   5        $��ProductDataGridView��5   V      
IsReadOnly$
 True��6   $��1��6%   $��1��62   $��2��6B      AutoGenerateColumns$ False��6q   $��24(�6�      Columns 5      4  .System.Windows.Controls.DataGridTemplateColumn  5       	   CellTemplate	 5!      �� 5"      .R�5#      �� $��Center=�6)   $ 
Horizontal=�6D   .+�5$   "   �� 
 ��Name$
 SelectButton��6m   -   5        5$   �   5%      5&      5(      0  *System.Windows.Controls.DataGridTextColumn  5*         FontSize$ 29Q�6%   ,  &System.Windows.Controls.DataGridColumn   Header$ Наименование��63   -   5        Product_NameView��1  +System.Windows.Controls.DataGridBoundColumn   Binding 5*   I   ��  �� Path$ Product_Name�6�     5+      $ 29Q�6%   $ Категория��63   -   5        Product_TypeView�� 5+   F   �� $ Product_Type�6�     5,      $ 29Q�6%   $ Количество��63   -   5        Product_AmountView�� 5,   G   �� $ Product_Amount�6�     5-      $ 29Q�6%   $ Стоимость��63   -   5        Product_CostView�� 5-   F   �� $ Product_Cost�6�     5.      $ 29Q�6%   $ Срок годности��63   -	   5        Expiration_DateView�� 5.   J   �� $ Expiration_Date�6�     5/      $ 29Q�6%   $ Поставщик��63   -
   5        Provider_NameView�� 5/   F   �� $" ProviderEntity.Provider_Name�6�   51      �� 53   
   $��1��6   $��2��6%   $��2��69   $ 
Horizontal=�6F   ���#67d2f0.+�54      �� $��2��6   $��2��6&   $��Center=�66   $��Center=�6Q   $ 
Horizontal=�6n   .+�55      �� -   5        $	��100��55   .   $	��100��6>   ���#67d2f0
����������#2d9bba$��4q�6�   $��38(�6�   $
��20 0q�6�   .��6�   Добавить6�   �� 56      -   5        $ DeletButton��56   3   $	��100��6H   $	��100��6X   ���#67d2f0
����������#2d9bba$��4q�6�   $��38(�6�   $
��20 0q�6�   .��6�   Удалить6�   �� 57      -   5        $ 
EditButton��57   2   $	��100��6F   $	��100��6V   ���#67d2f0
����������#2d9bba$��4q�6�   $��38(�6�   $
��20 0q�6�   .��6�   Редактировать6�   �� 58      -   5        $ SupplyButton��58   4   $	��100��6J   $	��100��6Z   ���#67d2f0
����������#2d9bba$��4q�6�   $��38(�6�   $
��20 0q�6�   .��6�   Поставка6�   59      5:      5;      5<      