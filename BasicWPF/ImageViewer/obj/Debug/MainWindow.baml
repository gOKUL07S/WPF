   M S B A M L   `   `   `  ����F  BImageViewer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:ImageViewerImageViewer  5   	       ImageViewer.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:ImageViewer     5   	     � Title$  
MainWindow��5   	   $��429.976��5	   	   $��419.121��5
   	   .��5      �  � ColumnDefinitions 5   
   �� 5      $��4* �6   �� 5      $��* �6    � RowDefinitions 5   
   �� 5      $
��20px �6   �� 5      $��* �6   .+�5   
   (� -   5        $��imageCanvas��5      $��0��5      $��1��5       (� Stretch$
 Fill=�6    (� StretchDirection$ UpOnly=�6-   .��5      �� -   5        $	��img��5      $��D:\WP\OBITO_FRIENDS.png��5      $��0,0,0,0q�5       $��Center=�5!      $��Center=�5"      5,      5-      �� 5.   
   $��1��6   $��1��5/      $
��Auto=�50      .��51      �� 
���  ��.+�56      �� -   5        $
��xPos��58      $��30��56      
��� ���58   *   �� 59      -   5        $
��yPos��5;      $��30��59      
�������5;   *   �� 5<      -   5        $��x2Pos��5>      $��30��5<      
��� ���5>   +   �� 5?      -   5        $��y2Pos��5A      $��30��5?      
�������5A   +   5B      5C      5D      5E      