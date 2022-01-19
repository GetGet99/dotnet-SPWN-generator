# .NET SPWN Generator

Simple, incomplete generator that generates SPWN code from .NET 6 code.

# What it can do?
Currently, it can:
* Create basic codes and other simple stuff, but not all methods from SPWN is supported yet

Future Plans:
* Let User create simple wrapper for libraries or in case SPWN gets updated (since I don't think I might be able to keep this project up-to-date later on, and it will let user use it even if this project is dead.)
* Add all features of SPWN regular libraries

## Completed (everything here is a "maybe" and as of SPWN 0.7 beta)
* Array
* Block
* Boolean (unsure, can't find the documentation)
* Color
* Dictionary
* Event (but not include everything in event.spwn)
* Group
* Item
* String

## Not implemented yet
* lib.spwn (you probably won't need it when it is wrapped but did not check carefully so put it here first)
* control_flow.spwn
* binary_counter.spwn
* complex.spwn
* constants.spwn
* event.spwn
* fileio.spwn
* general_triggers.spwn
* heapq.spwn
* http.spwn
* obj_set.spwn
* util.spwn
* vector.spwn
* zip.spwn
* Trigger
* and more? idk

## Incomplete implementation
* Counter
* Pattern
* Range
* Module
* Trigger
* Macro
* and more? idk

# Why this project?

If you're a fan of IntelliSense, Typing, or other features avaliable in .NET or .NET editor, using this project might help you. In addition, even if this project is dead, the "wrapper" can be created and custom codes can easily be added (you technically can right now, but will be easier later on. It's part of Future plans.)

# Usage
See https://github.com/Get0457/dotnet-SPWN-generator/blob/master/Example.ipynb for simple examples
See SPWNTestProject for sample project setup

 You do not neccessary need to make Console app. If you think of importing this to WinForms App / WinUI / WPF / etc. and you think it will compat with your work somehow, do it.
