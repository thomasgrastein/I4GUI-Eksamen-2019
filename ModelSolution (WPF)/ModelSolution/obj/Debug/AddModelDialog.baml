   M S B A M L   `   `   `  ����H  DModelSolution, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:ModelSolutionModelSolution  5   	   "    ModelSolution.AddModelDialog   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:ModelSolution     5   	   X TXceed.Wpf.Toolkit, Version=3.4.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit  5   	     � Title$  AddModelDialog��5	   	    � 
ResizeMode$ NoResize=�6     � SizeToContent$ WidthAndHeight=�66    � WindowStartupLocation$ CenterOwner=�6U   .��5
      �� .+�5   
   �� $
��Name��6   $	��0,5q�6   $��Center=�6,   (  "Xceed.Wpf.Toolkit.WatermarkTextBox  5   
   -   5        $
��Name��5          	Watermark$ E.g. Anders Anderson��6,   $	��250��6M   $	��5,0q�6Y   �� 5   
   $��Phone��6   $	��0,5q�6    $��Center=�6-     5   
   -   5        $��Phone��5       $ E.g. +45 00000000��6-   $	��250��6K   $	��5,0q�6W   �� 5   
   $��Address��6   $	��0,5q�6"   $��Center=�6/     5   
   -   5        $��Address��5       $+ %E.g. Anderson Street 123, 8000 Aarhus��6/   $	��250��6a   $	��5,0q�6m   �� 5   
   $��Height��6   $	��0,5q�6!   $��Center=�6.   %  Xceed.Wpf.Toolkit.IntegerUpDown  5   
   -   5        $��Height��5      $	��250��6+   �  �Xceed.Wpf.Toolkit.Primitives.UpDownBase`1[[System.Nullable`1[[System.Int32, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]], mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]   Minimum$ 0X�67   ,  &Xceed.Wpf.Toolkit.Primitives.InputBase   	Watermark$ 
E.g 180 cm��6C   $
��Left=�6Z   �� 5   
   $��Weight��6   $	��0,5q�6!   $��Center=�6.     5   
   -   5        $��Weight��5      $	��250��6+   $ 0X�67   $ 	E.g 80 kg��6C   $
��Left=�6Y   �� 5   
   $��
Hair color��6   $	��0,5q�6%   $��Center=�62   #  Xceed.Wpf.Toolkit.ColorPicker  5   
   -   5        $��	HairColor��5   6      DisplayColorAndName . $	��5,0q�6G   �� 5   
   $��Comment��6   $	��0,5q�6"   $��Center=�6/   +  %Xceed.Wpf.Toolkit.MultiLineTextEditor  5   
   -   5        $��Comment��5   #   $��5,0,5,5q�62   �� 5   
   -   5        $��	Add_Model��5   %   $��	Add Model��6   $��5q�66   6A   5      5      