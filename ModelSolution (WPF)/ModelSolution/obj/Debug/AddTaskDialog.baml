   M S B A M L   `   `   `  ����H  DModelSolution, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:ModelSolutionModelSolution  5   	   !    ModelSolution.AddTaskDialog   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:ModelSolution     5   	   X TXceed.Wpf.Toolkit, Version=3.4.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit  5   	     � Title$  AddTaskDialog��5	   	    � 
ResizeMode$ NoResize=�6    � SizeToContent$ WidthAndHeight=�65    � WindowStartupLocation$ CenterOwner=�6T   .��5
      �� .+�5   
   �� $
��Name��6   $	��0,5q�6   $��Center=�6,   (  "Xceed.Wpf.Toolkit.WatermarkTextBox  5   
   -   5        $
��Name��5          	Watermark$ E.g. Pictures Inc��6,   $	��250��6J   $	��5,0q�6V   �� 5   
   $��
Start date��6   $	��0,5q�6%   $��Center=�62   &   Xceed.Wpf.Toolkit.DateTimePicker  5   
   -   5        $��	StartDate��5   1   &   Xceed.Wpf.Toolkit.DateTimeUpDown   Format$ 	ShortDate=�6   $	��250��6C   $	��5,0q�6O   �� 5   
   $��Days (duration)��6   $��Center=�6*   %  Xceed.Wpf.Toolkit.IntegerUpDown  5   
   -   5        $
��Days��5   6   �  �Xceed.Wpf.Toolkit.Primitives.UpDownBase`1[[System.Nullable`1[[System.Int32, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]], mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]   Minimum$ 0X�6   $	��5,0q�6)   $
��Left=�6B   ,  &Xceed.Wpf.Toolkit.Primitives.InputBase   	Watermark$ E.g. 0 days��6d   �� 5   
   $��Address��6   $	��0,5q�6"   $��Center=�6/     5   
   -   5        $��Address��5       $+ %E.g. Anderson Street 123, 8000 Aarhus��6/   $	��250��6a   $	��5,0q�6m   �� 5   
   $��Required for task��6   $��Center=�6,     5   
   -   5        $��Required��5   6   $ 0X�6   $	��5,0q�6)   $
��Left=�6F   $ E.g. 1��6h   �� 5   
   $��Comment��6   $	��0,5q�6"   $��Center=�6/   +  %Xceed.Wpf.Toolkit.MultiLineTextEditor  5   
   -   5        $��Comment��5   #   $��5,0,5,5q�62   �� 5   
   $��Assigned models��6   $	��0,5q�6*   $��Center=�67   %  Xceed.Wpf.Toolkit.CheckComboBox  5   
   -   5        $��Assigned��5       �� DisplayMemberPath$
 Name��6-   �� 5   
   -   5        $��Add_Task��5   $   $��Add Task��6   $��5q�64   6?   5      5      