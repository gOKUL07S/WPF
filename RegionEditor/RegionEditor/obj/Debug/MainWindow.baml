   M S B A M L   `   `   `  ����G  CRegionEditor, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:RegionEditorRegionEditor  5   	       RegionEditor.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:RegionEditor     5   	     � Title$  
MainWindow��5   	   $	��350��6   $	��674��6)    � WindowStartupLocation$ CenterScreen=�65    � 
ResizeMode$ 	CanResize=�6Z   .��5	      �  � RowDefinitions 5
   
   �� 5      $
��100* �6   �� 5      $	��10* �6   .+�5   
   � -   5         �Name$ 	ImageGrid��5      ���	#FFB6B6B6}�. .+�5      �� -   5         ��Name$ ImageViewer��5      $��Stretch=�6)   $��Stretch=�6G   $
��Fill=�6c   }�. 6r   �� 5      -   5        $��OverlayCanvas��5      
������  J� IsHitTestVisible . .+�5      %   RegionEditor.ResizableRectangle  -   5          Name$! ResizableSelectionRectangle��5   +   $	��509��5   '   $	��163��63    �� Left$ 50��5   '   
	 �� Top$	 50��68   $y�Hidden=�5   '   
 J� RenderTransformOrigin$
 0.5,0.5&�6;   5      5      � 5   
   $��1��6   ���	#FFD7DCE0.+�5      �� -   5         ��Name$ 
LoadButton��5      $
��Load��6)   $��	5,2,322,0q�6T   �� 5      -   5         ��Name$ ShapeBox��5      $��	0,2,215,2q�6)    �� SelectedIndex$ 0��6<   $��Right=�6N   $��Center=�5      $	��106��69   .@�5      �� $��14(�6   $��	Rectangle��6*   �� 5      $��14(�6   $��Circle��6*   �� 5       $��14(�6   $��Polygon��6*   5!      �� 5"      -   5        $ 
CropButton��5"      $
��Crop��6)   $��0,1,95,1q�6T   $	��117��6f   $��Right=�6r   �� 5#      -   5        $ ResizeButton��5#      $��ReSize��6+   $��0,0,4,2q�6V   $��86��6g   $��Right=�6r   5$      5%      5&      