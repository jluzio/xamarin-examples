https://stackoverflow.com/questions/37964909/xamarin-forms-absolutelayout-how-does-works-positions

With AbsoluteLayoutFlag.All, the Rectangle bounds parameters have the following meaning:

x means the percentage of the remaining space (i.e parent width - control width) which should be on the left of the control
y means the percentage of the remaining space (i.e parent height - control height) which should be on the top of the control
width is the width of the control in percentage of the parent width
height is the height of the control in percentage of the parent height
Width and height are what people usually expect. However, x and y are not as people are more used to "left" and "top". So you can write a converter to convert left percentage into x and top percentage into y:

x = left / (1 - width)
y = top / (1 - height)
