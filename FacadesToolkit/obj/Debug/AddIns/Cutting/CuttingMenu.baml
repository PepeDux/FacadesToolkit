   M S B A M L   `   `   `  ����  FacadesToolkit/    )FacadesToolkit.AddIns.Cutting.CuttingMenu   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -   5          � Title$  Меню подрезки��5   	   $	��267��6   $	��210��6,    � SizeToContent$ Height=�68    � WindowStyle$ SingleBorderWindow=�6O    � 
ResizeMode$ NoResize=�6p    � WindowStartupLocation$ CenterScreen=�6�   ��. ���#202020 � 	Resources 5
         TextBox.MouseOver.Border �� Color  TextBox.Focus.Border  TextBoxTemplateBase �� 
TargetType ��Name	 �� Padding
 �� CornerRadius J� SnapsToDevicePixels ��Name �� Triggers P� Property P� Value �� 
TargetName �� Property �� Value  Button.MouseOver.Background  Button.MouseOver.Border  Button.Pressed.Background  Button.Pressed.Border  Button.Disabled.Background  Button.Disabled.Border 	 Button.Disabled.Foreground 
 ButtonTemplateBase ��Name��%\  &	        &	 #     &	 F     7   7  &	 �    &	 �    &	 �    &	 �    &	     &	 /    &		 R    &	
 u    7  7  7  7  7  7  7 	 �� 5   
   $ 	#FFBF855F��6;   �� 5   
   $ 	#FFD57334��67   �� 5   
   " ��66   .R�5      �� $ border��6   #��z��6%   #��z��6O   #��z��6{   $	 6,0,0,0q�6�   $
 6��6�    . ._�5      �� $ PART_ContentHost��6   |�.  $��Hidden=�6K   $��Hidden=�6r   5       5      P� 5       � {� .  . �5      �� $ border��60    �@J�Opacity$
 0.56Q�6D   5      P� 5       �@J�IsMouseOver . . �5      �� $ border��64   8    � ��6H   5      P� 5       �@J�IsKeyboardFocused . . �5      �� $ border��64   8   � ��6H   5      5      �� 5   
   $ 	#FFD57334��6>   �� 5   
   $ 	#FFD57334��6:   �� 5    
   $ 	#FFA55928��6<   �� 5!   
   $ 	#FFA55928��68   �� 5"   
   $ 	#FFF4F4F4��6=   �� 5#   
   $ 	#FFADB2B5��69   �� 5$   
   $ 	#FF838383��6=   �� 5%   
   " ��65   .R�5'      �� $ border��6   #��z��6%   #��z��6O   #��z��6{    . $
 6��6�   ._�5(      �� $ contentPresenter��6#   |�.  #��z��6O   #��z��6�   ��. # z 6�   #��z��6  5)       5*      P� 5+       �@��IsDefaulted . . �5,      �� $ border��64   # � ��6H    � ��5-      P� 5.       �@J�IsMouseOver . . �5/      �� $ border��63   8    � ��6G   �� 50      $ border��64   8   � ��6H   51      P� 52       � �� . . �53      �� $ border��63   8   � ��6G   �� 54      $ border��64   8   � ��6H   55      P� 56       � {� .  . �57      �� $ border��63   8   � ��6G   �� 58      $ border��64   8   � ��6H   �� 59      $ contentPresenter��6?   8   � ��6]   5:      5<      5=       � Triggers 5@      :� 5A   
    :� RoutedEvent$ Window.Loaded��6   [�5B      �� 5C      .��5D      �� .��5E      W�  g� Duration$ 0:0:.5D�6*    �� TargetProperty$ Opacity�6<    W� From$ 0X�6`   	 W� To$ 1X�6i   5F      5G      5I      .��5L      � .+�5N   
   � -   5         �Name$ Grid_Slider��5N      $
��Auto��6$   $��	0,0,0,171q�61   .+�5P      �� $&�� Сторона подрезки:��6   $��14(�5Q      ���#DDDD$��	30,20,0,0q�5S      �� 5U      -   5         ��Name$
 Type��5V      $��1��5U      $��14(�5W      ���	#FFD57334$��
158,21,0,0q�5Y      �� 5[      -   5         ��Name$ DigitSlider��5\       � Value$ 1Q�5[       � Minimum$ 1Q�6    � Maximum$ 4Q�6+     �� TickPlacement$  BottomRight=�5^      ! �� TickFrequency$! 1Q�60   " � SmallChange$" 1Q�5_      # � LargeChange$# 1Q�6$   $ �� IsSnapToTickEnabled$ . % �� Ticks$% 1,2,3,4R�5a      $��
30,50,30,0q�5b      5d      � 5f   
   -   5        $ Grid_TextBox��5f      $
��Auto��6%   $��	0,85,0,93q�62   .+�5h      �� $$��Отступ подрезки:��6   $��14(�5i      ���#DDDD$��30,0,0,0q�5k      �� 5m      -   5        & ��Name$& IndentTextBox��5o      #���  5m      $��0��5n      $��16(�5p      $��Center=�5q      $��Center=�5r      ���#DDDD���	#FF2B2B2B���	#FF969696' �� SelectionTextBrush' �	#FFD57334$��
35,30,35,5q�5t      5v      � 5x   
   -   5        $ Grid_Button��5x      $
��Auto��6$   $��	0,163,0,0q�61   .+�5z      �� -   5        ( ��Name$( 	CutButton��5{      #��� 
 5z      $��Применить��5|      ) � Cursor$
) Hand��5~      $��36��5      ���	#FFD57334
�������$��35,25,35,25q�5�      ��5�      Z� 5�      5�      5�      5�      