   M S B A M L   `   `   `  ����I  EUserManagement, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:UserManagementUserManagement  5   	       UserManagement.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:UserManagement     5   	     � Title$  
MainWindow��5   	   $	��600��5	   	   $	��800��5
   	    � WindowStartupLocation$ CenterScreen=�5   	    � 
ResizeMode$ NoResize=�5   	    � 	Resources 5      .   (UserManagement.MultiTextBoxValueConvetor   textBoxMultiValueConvertor  CurvedButton �� 
TargetType �� Property �� Value �� 
TargetType ��Name	 �� CornerRadius
 �� Triggers P� Property P� Value �� 
TargetName �� EndPoint �� 
StartPoint � Color � Offset��%]  &	        &	        5   
   6*   �� 5   
   " ��5      .�5      ��  � �� 5      �� 5      " ��6&   .R�5      �� $ border��6!   $	 15��5   !   #��z��5   !   #��z��5   !   $��1q�5   !   ._�5      �� $��Center=�6/   $��Center=�5   /   5      
 5      P� 5       �@J�IsMouseOver . . �5    "   �� $ border��6)    � �� 5"   &   �� 5#   *   $ 0.5,1&�6>   $ 0.4,0&�5$   >   .��5%   .   � $ #00C9FF��6;   � 5&   .   $ 	#FF07D192��6;   $ 0.813Q�5'   ;   5(   +   5*   #   5+      5-      5/      50      51      .��52      � .+�53   
   �� -   5        $��Login��53      $y�Visible=�54      ��55      �� 56      $	 1,1&�6&   $	 0,0&�57   &   .��58      � $ #00C9FF��6#   � 59      $ 	#FF07D192��6#   $	 0.9Q�5:   #   5;      .+�5=      �� -   5        $ loginBorder��5=      $	 12��5>      $	��400��5?      $	��300��5@       �� Left$	 250��5A      
 �� Top$ 75��5B      
������� K� ZIndex$ 10��5D      ._�5E      �� .+�5F      �� $��75��6   $��Center=�5G      $��Center=�5H      .��5I      �� .+�5K      �� $��Segoe UI Black)�6(   $��Center=�5L   (   $��Center=�5M   (   $��30(�5N   (   Login6=   �� 5O      
�������$��0,1,0,0q�5P   %   $	��0,8q�5Q   %   5R      5S      �� 5T      $	��320��6   .+�5U      "   UserManagement.HeaderTextBox  -   5          Name$ 
usernameTb��5U   .      Header$ Username��5V   .   $ 36��5W   .   $ 13��5X   .   $��50��5Y   .   $	��220��5Z   .   &    UserManagement.HeaderPasswordBox  5\      -   5          Name$ 
passwordTb��5\   2      Header$ Password��5]   2   $ 36��5^   2   $ 83��5_   2   $��50��5`   2   $	��220��5a   2   �� 5c      -   5         �� Right$ 40��5c       $	 150��5d       $��ForgetPassword?��5e       
�������$��0q�5g       $��
UltraLight"�5h       5�      �� 5�      $ 46��6!   $	 170��5�   !   $��0 1 0 0q�5�   !   
�������$��84��5�   !   �� 5�      -   5        #��[ 5�   !   $	��100��5�   !   $��30��5�   !   $	 100��5�   !   $	 200��5�   !   $��Login��5�   !   ��5�      �� 5�   "   $ 0.5,1&�66   $ 0.4,0&�5�   6   .��5�   &   � $ 	#FF07D192��63   � 5�   &   $ #00C9FF��63   $	 0.9Q�5�   3   5�   #   {�5�      `� 5�   "    `� 	Converter# [  6/   .1�5�   &   ��  �� Path$ TextBoxText�6.    �� ElementName$ 
usernameTb��5�   .   �� 5�   &   $ Passworddemo�6.   $ 
passwordTb��5�   .   5�   #   5�      �� 5�      -   5        $��Create User��5�       
�������$��12(�5�        �� Bottom$ 5��5�       $	 120��5�       $��0q�5�       $��
UltraLight"�5�       5�      �� 5�      $ 7��6!   $	 123��5�   !   $��0 1 0 0q�5�   !   
�������$��62��5�   !   5�      5�      5�      �� 5�      -   5        $ createUserBorder��5�      $	 12��5�      $	��400��5�      $	��300��5�      $	 250��5�      $ 75��5�      
�������$ 11��5�      ._�5�      �� .+�5�      �� $��75��6   $��Center=�5�      $��Center=�5�      .��5�      �� .+�5�      �� -	   5         ��Name$ 
headerLbl2��5�   (   $��Segoe UI Black)�5�   (   $��Center=�5�   (   $��Center=�5�   (   $��30(�5�   (   	sign up5�   E   �� 5�      
�������$��0,1,0,0q�5�   %   $	��0,8q�5�   %   5�      5�      �� 5�      $	��320��6   .+�5�        -
   5        $ CreateUsernameTb��5�   .   $ Username��5�   .   $ 36��5�   .   $ 13��5�   .   $��50��5�   .   $	��220��5�   .     5�      -   5        $ CreateNewPasswordTb��5�   2   $ New Password��5�   2   $ 36��5�   2   $ 83��5�   2   $��50��5�   2   $	��220��5�   2     5�      -   5        $ CreateConfirmPasswordTb��5�   2   $ Confirm Password��5�   2   $ 36��5�   2   $	 153��5�   2   $��50��5�   2   $	��220��5�   2   �� 5�      -   5        #��[ 5�   !   $	��100��5�   !   $��30��5�   !   $	 100��5�   !   $	 250��5�   !   $��Sign up��5�   !   ��5      �� 5  "   $ 0.5,1&�66   $ 0.4,0&�5  6   .��5  &   � $ 	#FF07D192��63   � 5  &   $ #00C9FF��63   $	 0.9Q�5  3   5  #   {�5     `� 5	  "   # [  6/   .1�5
  &   �� $ TextBoxText�6.   $ CreateUsernameTb��5  .   �� 5  &   $ Passworddemo�6.   $ CreateNewPasswordTb��5  .   �� 5  &   $ Passworddemo�6.   $ CreateConfirmPasswordTb��5  .   5  #   5     �� 5     -   5        $��sign in��5      
�������$��12(�5      $ 5��5      $	 127��5      $��0q�5      $��
UltraLight"�5      5.     �� 5/     $ 7��6!   $	 130��50  !   $��0 1 0 0q�51  !   
�������$��37��53  !   54     55     57     �� 58     -   5        $ loginSuccessfulBorder��58     $	 12��59     $	��400��5:     $	��300��5;     $	 250��5<     $ 75��5=     
�������._�5@     �� .+�5A     �� $ 5��6    $ 50��5B      $��40(�5C      
����� �Login Successful5D  H   �� 5E     $	 150��6    $ 13��5F      $��20(�5G      
����� �Do you want to continue or go5H  U   �� 5I     $	 180��6    $	 127��5J      $��20(�5K      
����� �back?5L  =   �� 5M     -   5        #��[ 5M     $	��100��5N     $��30��5O     $
��back��5P     $	 110��5Q     $ 30��5R     ��5T     �� 5U     $ 0.5,1&�62   $ 0.4,0&�5V  2   .��5W  "   � $ 	#FF07D192��6/   � 5X  "   $ #00C9FF��6/   $	 0.9Q�5Y  /   5Z     5\     �� 5]     -   5        #��[ 5]     $	��100��5^     $��30��5_     $��continue��5`     $	 110��5a     $ 30��5b     ��5d     �� 5e     $ 0.5,1&�62   $ 0.4,0&�5f  2   .��5g  "   � $ 	#FF07D192��6/   � 5h  "   $ #00C9FF��6/   $	 0.9Q�5i  /   5j     {�5l     `� 5m     # [  6+   .1�5n  "   �� $ TextBoxText�6*   $ 
usernameTb��5o  *   5p     5r     5s     5t     5u     5w     5x     