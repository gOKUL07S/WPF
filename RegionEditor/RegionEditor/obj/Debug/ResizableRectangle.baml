   M S B A M L   `   `   `  ����G  CRegionEditor, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:RegionEditorRegionEditor  5      %    RegionEditor.ResizableRectangle   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ,localclr-namespace:RegionEditor     5      -   5          >�Name$  MainControl��5      $	��200��5	      $	��200��5
       � 	Resources 5      *  $RegionEditor.SizePercentageConverter   SizePercentageConverter �� 
TargetType �� Property �� Value �� EndPoint �� 
StartPoint � Color � Offset	 �� 
TargetType
 �� Triggers P� Property P� Value��%�  &	        'n�        5   
   6(   �� 5   
   " n�6   .�5      ��  � ��$ 16��5      �� 5       � ��$ 16��5      �� 5       � �� 5      �� 5      $ 0.5,1&�6*   $ 0.5,0&�5   *   .��5      � $ 	#FFFF1010��6'   $
 0.51Q�5   '   � 5      $ 	#FF0A0909��6'   $ 0.531Q�5   '   5      5      �� 5       � �� 5      �� 5       "	 n�6&   .R�5!      � .+�5"      A� #��z��6&   #��z��5#   &   #��z��5$   &   #��z��5%   &   #��z��5&   &   A� 5'      $��8��6&   $��8��5(   &   
�������
���   �$	��0.5��5+   &   5,      5-      5/      
 50      P� 51       �@J�IsMouseCaptured . . �53      ��  � ��
 �  ��54      55      57      59      .��5;      �� }�. .+�5<   
   �� -   5         ��Name$ SelectionRectangle��5<      
���  ��$��2��5>      
������� �� StrokeDashArray$	 2,2R�5@      $y�Visible=�5A       J� Opacity$	 0.3Q�5D       �� Left$ 2��5E      
 �� Top$ 2��5F      ��5B      �� *ActualHeight+ �� ElementName$ MainControl�� �� 	Converter# [  ��5C      �� *ActualWidth+$ MainControl��# [  5F      n� 5I   
   -   5         n�Name$ TopLeftThumb��5I       � Cursor$ SizeNWSE��5J      $��8q�5K      n� 5L   
   -   5        $ TopRightThumb��5L      $ SizeNESW��5M      n� 5N   
   -   5        $ BottomLeftThumb��5N      $ SizeNESW��5O      n� 5P   
   -   5        $ BottomRightThumb��5P      $ SizeNWSE��5Q      n� 5T   
   -   5        $ TopThumb��5T      $ SizeNS��5U      $��0 6 0 0q�5V      n� 5W   
   -   5        $ BottomThumb��5W      $ SizeNS��5X      n� 5Y   
   -	   5        $ 	LeftThumb��5Y      $ SizeWE��5Z      n� 5[   
   -
   5        $ 
RightThumb��5[      $ SizeWE��5\      5]      5_      