   M S B A M L   `   `   `  ����   FacadesToolkit)    #FacadesToolkit.ClippingIndentWindow   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     -     � Title$)  #Параметры подрезки��$	��280��$	��200�� � WindowStyle$ SingleBorderWindow=� � 
ResizeMode$ NoResize=� � WindowStartupLocation$ CenterScreen=���. ���#202020 � 	Resources    TextBox.MouseOver.Border �� Color  TextBox.Focus.Border  TextBoxTemplateBase �� 
TargetType ��Name �� Padding	 �� CornerRadius
 J� SnapsToDevicePixels ��Name �� Triggers P� Property P� Value �� 
TargetName �� Property �� Value  Button.MouseOver.Background  Button.MouseOver.Border  Button.Pressed.Background  Button.Pressed.Border  Button.Disabled.Background  Button.Disabled.Border 	 Button.Disabled.Foreground 
 ButtonTemplateBase ��Name��%�  &	        &	      &	 *     7   7  &	 �    &	 �    &	 �    &	 �    &	 �    &	 �    &		     &	
      7  7  7  7  7  7  7 	 �� $ 	#FFBF855F���� $ 	#FFD57334���� " ��.R��� $ border��#��z��#��z��#��z��$ 6,0,0,0q�$	 6��
 . ._��� $ PART_ContentHost��|�.  $��Hidden=�$��Hidden=� P�  � {� .  . ��� $ border�� �@J�Opacity$
 0.56Q�P�  �@J�IsMouseOver . . ��� $ border��8    � ��P�  �@J�IsKeyboardFocused . . ��� $ border��8   � ���� $ 	#FFD57334���� $ 	#FFD57334���� $ 	#FFA55928���� $ 	#FFA55928���� $ 	#FFF4F4F4���� $ 	#FFADB2B5���� $ 	#FF838383���� " ��.R��� $ border��#��z��#��z��#��z��
 . $	 6��._��� $ contentPresenter��|�.  #��z��#��z����. #
 z
 #��z�� P�  �@��IsDefaulted . . ��� $ border��# � �� � ��P�  �@J�IsMouseOver . . ��� $ border��8    � ���� $ border��8   � ��P�  � �� . . ��� $ border��8   � ���� $ border��8   � ��P�  � {� .  . ��� $ border��8   � ���� $ border��8   � ���� $ contentPresenter��8   � �� � Triggers :�  :� RoutedEvent$ Window.Loaded��[��� .���� .��W�  g� Duration$ 0:0:.5D� �� TargetProperty$ Opacity� W� From$ 0X�	 W� To$ 1X�.��� .+��� $'��!Сторона подрезки: ��$��14(�$��33�����#DDDD$��	23,31,0,0q�$	��Top=�$
��Left=�$	��133���� -    ��Name$
 Type��$�� ��$��14(�$��33�����	#FFD57334$��
149,31,0,0q�$	��Top=�$
��Left=�$��28���� -    ��Name$ Slider�� � Value$ 0Q� � Minimum$ 1Q� � Maximum$ 4Q� � SmallChange$ 1Q� � LargeChange$ 4Q�  �� TickPlacement$  BottomRight=�! �� TickFrequency$! 4Q�" �� IsSnapToTickEnabled" . # �� Ticks$# 1,2,3,4R�$
��auto��$	��154��$��	23,69,0,0q�$	��Top=�$
��Left=��� -   $��Center=�$	��160��$��	0,109,0,0q�$	��125��$	��Top=�.+��� $)��#Отступ обрезки в мм��$��16(�$
��auto�����#DDDD�� -   $ ��Name$$ IndentTextBox��#���  $��0,6,0,0q�$��36��$
��auto��% �� TextAlignment$% Center=�$��Center=�$��16(����#DDDD���	#FF2B2B2B���	#FF969696& �� SelectionTextBrush& �	#FFD57334�� -   ' ��Name$' 	CutButton��#��� 
 $��Отправить��$��Bottom=�$��36��$��0,26,0,0q�( � Cursor$
( Hand�����	#FFD57334
���������Z� 