   M S B A M L   `   `   `  ����G  CRegionEditor, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:RegionEditorRegionEditor  5   	       RegionEditor.Resize   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:RegionEditor     5   	     � Title$  Resize��5   	   $	��450��6   $	��800��6%    � 
ResizeMode$ NoResize=�61    � WindowState$ 	Maximized=�6G   .��5	      �  � RowDefinitions 5
   
   �� 5      $��9* �6   �� 5      $��1* �6   .+�5   
   �� -   5         ��Name$ 	TopCanvas��5      $��1��6$   $��	0,10,10,5q�65   .+�5      �� -   5         ��Name$ ImageBorder��5      
������ 
���P��$��2q�5      
 �� Top$ 10��5       �� Left$ 10��6%   $	��347��66   $	��762��6C   ._�5      �� -   5         ��Name$ ResizableImage��5      $��Stretch=�5      $
��Fill=�66   $��Stretch=�5      $��0q�64   5      n� 5      -   5        	 n�Name$	 ResizeThumb��5      $��10��5      $��10��5      
���P��$	 772��5      $	 357��5      5      5      �� 5   
   -   5        $ BottomBorder��5      $��1��6'   
���   �$��2q�6H   
 �� CornerRadius$
 5��6\   }�. $��0,0,10,0q�5    %   ._�5!      �� -   5        }�. $��	0,-1,-1,1q�5!   )   $
��Save��6<   $��Right=�6_   $	��108��6{   5"      5#      5$      