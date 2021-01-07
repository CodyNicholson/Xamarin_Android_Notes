# Creating Layouts

When building Android screens we have **Layouts** (All Layouts inherit from the **ViewGroup** class) and **Widgets** (All Widgets inherit from the **Views** class). Widgets will typically be placed inside layouts. The hierarchy starts with a ViewGroup that can contain children Views (Which includes Widgets) and ViewGroups (Layouts). Android layouts make your life easier because they accommodate for the different resolutions of each device that will run your app.

The three most common Layout classes are:

## LinearLayout

The LinearLayout is a simple layout that will place it's children below or next to each other based on the orientation we've chosen. Between each child we can include a margin so the children don't stick together. LinearLayouts also support **Weight**. **Weight** indicates how important a child is, which determines how much of teh screen s child will occupy. More weight means more screen. 

## RelativeLayout
The RelativeLayout can place it's children in relative positions. One widget can be placed relative to another widget. You can also specify position relative to the parent. RelativeLayout makes it harder to drag-and-drop widgets in Visual Studio. 

## TableLayout

The TableLayout can be compared with an HTML table because it allows us to place it's children in rows and columns. 
