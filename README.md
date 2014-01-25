Sigmund
=======
Card game automation framework

Hooks game and loads plugins as they are modified (or explicitly requested to be reloaded).
All plugins are run in separate threads (which are killed if the plugin is reloaded).
Plugin libraries are rewritten to have different names to allow loading of multiple versions (thus the psuedo reload mechanic).

Developers just need to hit rebuild when working on a plugin to immediately see the effects in game.


Setup
=====
 1. If needed, update ext/ with new Assembly-CSharp.dll, Mono.Cecil.dll (match the version Unity uses internally), and UnityEngine.dll
 2. Fix hardcoded paths in Injector.cs and Sigmund.cs (basically, point to location of ext/ and plugins/)
 3. Run injector to create patched Assembly-CSharp.dll which loads Sigmund.dll
 4. Start game launcher. It will revert all game files to the originals
 5. Rebuild the plugin or Sigmund, this will cause the patched Assembly-CSharp.dll to get copied to game directory
 6. Start game and click through until you reach main Hub menu.

You can open the dev console (Ctrl-Enter) and type "echo my message" to display "my message" to the screen.
 
Usage
=====
 1. TestPlugin will load automatically (comment out line in Sigmund.Main.Start to disable)
 2. Modify or create any files in plugins/ directory will cause them to be (re)loaded
 3. Open dev console (Ctrl-Enter) and type "run somePlugin" will (re)load the somePlugin.dll in plugins/

Projects
========
Injector: patches Assembly-CSharp.dll to load Sigmund.dll (our loader)

Sigmund: loader which watches filesystem and the game's dev console to trigger (re)loading plugins (after doing minor rewriting)

TestPlugin: example plugin to automate playing against practice AI
