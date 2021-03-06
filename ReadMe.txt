INTRODUCTION
============

This project provides a user interface for an LED message board (see https://www.thinkgeek.com/product/1690/).

The software that comes with the message board is not great. The UI is terrible, and the options aren't very dynamic. This project creates a new program for gathering configuration details from the user and displaying the messages on the display board. Not all of the options the original software provided are implemented yet, however the UI is cleaner and more intuitive, and the possibilities for extending the capabilities of the project are plentiful.


NOTABLE CODE SECTIONS
=====================

"ConfigurationPanels" Folder:
	- Contains the classes implementing the UI for the application
	- Each configuration panel represents a different message type that can be displayed (i.e. different data sources for the messages)
	- There is one interface (IConfigurationPanel) providing the "non-designer-related" definitions for methods
	- There is one base class (ConfigurationPanel.cs) which defines the "designer-related" methods, and three sub-classes, one for each data source

"DisplayAdapters"
	- These classes prepare the data to be displayed and pass it to the appropriate view port
	- There is one interface (IDisplayAdapter) defining the display adapter methods
	- There are three implementations, one for each data source

"ViewPort.cs", "ScrollingViewPort.cs", "StaticViewPort.cs", "ViewPortFactory"
	- ViewPort.cs is the abstract class, defining common behavior for the view ports, especially outputting data to the message board
	- ScrollingViewPort.cs is an implementation that scrolls the message across the message board (used for messages that are too long to display all at once)
	- StaticViewPort.cs is an implementation that displays the message centered on the message board (used for messages that are short enough to display all at once)
	- ViewPortFactory.cs takes in a message and the message board width and determines the kind of view port needed to display the message (Scrolling vs. Static)

	
Future Plans
============
- Have a software-based implementation of the message board, instead of requiring the hardware
	- Would allow for different heights / widths for the message board
- Multiple instances of the same data source type (i.e. multiple custom text messages, multiple countdowns, etc.)
- Weather messages
- Random quote messages
- etc.
