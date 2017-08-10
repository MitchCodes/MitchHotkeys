# Mitch Hotkeys
A desktop application written in C# that utilizes Windows API Interops to register global hotkeys and gives the user an interface to set up actions to trigger.

## How to install
1. Todo
2. Todo

## Programming technologies/concepts used
1. C#
2. Windows Forms
3. WPF Forms with XAML
4. Audio with NAudio
5. Windows Interop for global hotkey registering
6. SQLLite for local database access

## How to program a new hotkey type
1. Todo
2. Todo

## Todo
1. Readme todos
2. Finish WPF conversion for certain screens
3. Use Entity Framework instead of basic SQLite for data access
4. Refactor so that the data is not reliant on the factory. Goal is to get the data reading to be no longer in MainLogic

## Random Developer Tidbits
1. The first versions of this application used pure Windows Forms. This is going to be changed so the application uses WPF as well for some of the more complicated screens. The legacy UI is located in the UI folder of the MitchHotkeys project. To change the application to use legacy Windows Forms or WPF, change the constant in Constants.cs.
2. The autotune and audio passthrough hotkeys are experimental and not expected to work.