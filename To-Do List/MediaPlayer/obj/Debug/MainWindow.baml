   M S B A M L   `   `   `  ����F  BMediaPlayer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:MediaPlayerMediaPlayer  5   	       MediaPlayer.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:MediaPlayer     5   	   -   5          � Title$  
MainWindow��5   	   $	��534��6   $	��800��6)   .��5	      � 
���   �$��
0,-48,0,-6q�6   .+�5
   
   �� -   5        $��listbox��5
      ���#1DB954$	��150��66   $��0,40,0,0q�6C   $	��Top=�6U   $��Segoe UI Black)�6m   $��24(�6�   r� 5   
   -   5        $��media��5   /    r� LoadedBehavior$ Manual=�6<   $��95,195,77,348q�6T    J� RenderTransformOrigin$ 0.5,0.5&�6k   �� 5   
   -   5         ��Name$
 play��5      $
��Play��6   $��305,240,327,226q�6.   $��Segoe UI Black)�6G   $��24(�6c   ��5      �� 5       �� EndPoint$ 0.5,1&�6&    �� 
StartPoint$ 0.5,0&�67   .��5      �  � Color$ 	#FFCAE2B6��6#    � Offset$ 0.444Q�65   � 5      $ 	#FF7BBF41��6#   $ 1Q�65   5      5      �� 5   
   -   5        $ pause��5      $��Pause��6    $��100,240,532,229q�60   $��Segoe UI Black)�6I   $��24(�6e   ��5      �� 5      $ 0.5,1&�6&   $ 0.5,0&�67   .��5      � $ 	#FFCAE2B6��6#   $ 0.444Q�65   � 5      $ 	#FF7BBF41��6#   $ 1Q�65   5      5      �� 5   
   -   5         ��Name$ slider��5   6   	 � Minimum$	 0Q�6   
 � Maximum$
 1Q�6    � Value$	 0.5Q�6)   $��30��6F   $��29,494,23,33q�6R   $��20,10q�6h   6x   �� 5   
   -   5        $
 stop��5      $
��Stop��6   $��510,245,122,230q�6.   $��Segoe UI Black)�6G   $��24(�6c   ��5      �� 5      $ 0.5,1&�6&   $ 0.5,0&�67   .��5       � $ 	#FFCAE2B6��6#   $ 0.444Q�65   � 5!      $ 	#FF7BBF41��6#   $ 1Q�65   5"      5$      �� 5%   
   $��Volume��6   $
��Left=�6!   $��
15,437,0,0q�6<   $	��Top=�6P   
�������$	��115��6{   $��Segoe UI Black)�6�   $��22(�6�   �� 5&   
   -   5        $ musicplayer��5&   ^   $��30��6s   $��29,415,23,112q�6   $��20,10q�6�   
 6   �� *'%NaturalDuration.TimeSpan.TotalSeconds+ �� ElementName$ media��6  �� 5'   
   $��Music Player��6   $
��Left=�6'   $��
15,358,0,0q�6B   $	��Top=�6V   
�������$	��160��6�   $��Segoe UI Black)�6�   $��22(�6�   5)      5*      