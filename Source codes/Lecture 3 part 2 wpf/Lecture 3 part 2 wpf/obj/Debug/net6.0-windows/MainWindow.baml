   M S B A M L   `   `   `  ����O  KLecture 3 part 2 wpf, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:Lecture_3_part_2_wpfLecture_3_part_2_wpf  5   	   %    Lecture_3_part_2_wpf.MainWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   4local"clr-namespace:Lecture_3_part_2_wpf     5   	     � Title$  	Lecture 3��5   	   $	��800��6   $
��1600��6(   .��5	      � .+�5
   
   �� -   5        $
��txt1��5
      $
��Left=�6   $��	60,50,0,0q�69    �� TextWrapping$
 Wrap=�6L   $��First Input��6`   $	��Top=�6s   $	��120��6�   �� 5   
   -   5         ��Name$
 txt2��5      $
��Left=�6    $��
218,50,0,0q�6;   $
 Wrap=�6O   $��Second Input��6c   $	��Top=�6w   $	��120��6�   �� 5   
   -   5         ��Name$ btnJoinStrings��5      $��Join buttons��6)   $
��Left=�6@   $��
384,50,0,0q�6[   $	��Top=�6o   $��18��6�   $��84��6�   6�   �� 5   
   -   5        $ txtSplitBox��5      $
��Left=�6'   $��	60,98,0,0q�6B   $
 Wrap=�6U   $��Type split text��6i   $	��Top=�6�   $	��158��6�   $	��140��6�   �� 5   
   -   5        $ txtSplitParameter��5      $
��Left=�6-   $��70��6H   $��
234,98,0,0q�6T   $
 Wrap=�6h   $��TextBox��6|   $	��Top=�6�   $	��104��6�   �� 5   
   -   5         ��Name$ lstSplitResults��5      $��60,250,1132,425q�6V   6o   �� 5   
   -   5        $ 	splitText��5      $��Split the text��6$   $
��Left=�6=   $��
343,98,0,0q�6X   $	��Top=�6l   6�   �� 5   
   -   5        $ splitBoxClear��5      $��Clear��6(   $
��Left=�68   $��343,148,0,0q�6S   $	��Top=�6h   $��71��6�   6�   �� 5   
   -	   5        $ insertPosition��5      $
��Left=�6*   $��20��6E   $��234,182,0,0q�6Q   $
 Wrap=�6f   $��Insert to position��6z   $	��Top=�6�   $	��104��6�   �� 5   
   -
   5        $ newValueOfListBox��5      $
��Left=�6-   $��20��6H   $��234,213,0,0q�6T   $
 Wrap=�6i   $��Enter new value��6}   $	��Top=�6�   $	��104��6�   $y�Hidden=�6�   �� 5   
   -   5        $ btnSaveNewValueOfListBox��5      $
��Save��63   $
��Left=�6B   $��343,213,0,0q�6]   $	��Top=�6r   $��71��6�   $y�Hidden=�6�   �� 5   
   -   5        $ 
nextWindow��5      $��Next window��6%   $
��Left=�6;   $��43��6V   $��
584,16,0,0q�6b   $	��Top=�6v   $	��150��6�   6�   5      5      