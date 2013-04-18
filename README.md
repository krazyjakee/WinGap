WinGap
======

Build HTML5 apps for windows

Form Functions
==============

```javascript
  
  // Sets a bar (usually at the top of the form) that the user can use to drag the form around the screen.
  var x = 1;
  var y = 1;
  var width = 300;
  var height = 20;
  var backgroundColor = 'ffffff';
  var transparencyKey = '000000';
  form.setDragBar(x, y, width, height, backgroundColor, backgroundColor, transparencyKey);
  
  // With a dragbar in place we can begin to setup the other form settings.
  var width = 800;
  var height = 600;
  var title = 'Form 1';
  var borderType = 'FixedSingle';
  var transparent = true;
  var transparencyKey = '000000';
  form.setup(width, height, title, borderType, transparent, transparencykey);
  
  // Minimises the form
  form.minimize();
  
  // Maximise the form
  form.maximise();
  
  // Resize the current window
  form.resize(width, height);
  
  // Bring the form to the front.
  form.focus();
  
  // Alert the user in the task bar
  form.flash();
  
```

WinGap Functions
================

```javascript

  // Had to be done.
  wingap.helloWorld();
  
  // Quits the application
  wingap.quit();
  
  // Opens an application or url.
  wingap.open(address [, args]);
  
  // Enable key listening
  wingap.keyListener();
  
  // The current active key(s) variable to watch.
  wingap.activeKeys;
  
  // Opens a select file dialog and returns the file path.
  wingap.openfile();
  
  // Opens a select files dialog and returns the file paths.
  wingap.openfiles();
  
  // Read a file and return the content.
  wingap.readfile(path);
  
```
