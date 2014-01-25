using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

namespace Sigmund
{
    public class Main
    {
        public static void Start()
        {
            var w = new Watchdog();
            w.startWatch();
            Log.say("Sigmund online");
            w.RunPlugin("TestPlugin"); // temp for testing
        }
    }
    public class Watchdog
    {
        static string pluginDirectory = @"C:\Users\Joseph\Documents\Visual Studio 2013\Projects\HearthstoneBot\plugins";
        //static string scriptDir = @"C:\Users\Joseph\Documents\Visual Studio 2013\Projects\HearthstoneBot\scripts";
        Loader loader;
        Hashtable mtimeDb = new Hashtable();
        public void startWatch()
        {
            // init
            loader = new Loader();

            // If a plugin is modified, reload it
            FileSystemWatcher fsw = new FileSystemWatcher(pluginDirectory, "*.dll");
            fsw.NotifyFilter = NotifyFilters.LastWrite;
            fsw.Changed += new FileSystemEventHandler(onChange_raw);
            fsw.Created += new FileSystemEventHandler(onChange_raw);
            fsw.EnableRaisingEvents = true;
            Log.debug("Watching filesystem for plugin changes in: " + pluginDirectory);

            // If the user requests a plugin be run, reload it
            CheatMgr.Get().RegisterCheatHandler("run", new CheatMgr.ProcessCheatCallback(this.RunCommand));

            // For testing
            CheatMgr.Get().RegisterCheatHandler("echo", new CheatMgr.ProcessCheatCallback(this.EchoCommand));
        }
        public bool RunPlugin(string pluginName)
        {
            string path = pluginDirectory + Path.DirectorySeparatorChar + pluginName + ".dll";
            loader.exec(path);
            return true;
        }
        public bool RunCommand(string func, string[] args, string rawArgs)
        {
            return RunPlugin(rawArgs);
        }
        public bool EchoCommand(string func, string[] args, string rawArgs)
        {
            return true;
        }
        public void onChange_raw(object sender, FileSystemEventArgs e)
        {
            TimeSpan eps = new TimeSpan(0, 0, 2);
            var mtime = File.GetLastWriteTime(e.FullPath);
            if (!mtimeDb.ContainsKey(e.FullPath) || (DateTime)mtimeDb[e.FullPath] + eps < mtime)
            {
                mtimeDb[e.FullPath] = mtime;
                onChange(e.FullPath);
            }
        }
        public void onChange(string path)
        {
            Log.debug("Watchdog: change detected for: " + path);
            Thread.Sleep(1000 * 2); // wait for file to finish writing
            loader.exec(path);
        }
    }
    public class Loader
    {
        public Hashtable pluginDb = new Hashtable(); // assembly path -> thread
        public Hashtable tempDb = new Hashtable(); // thread -> temp file

        public Thread exec(string path) // creates shadow copy
        {
            Log.log("Loader.exec called for " + path);
            string tempPath = System.IO.Path.GetTempFileName();

            //System.IO.File.Copy(path, tempPath, true);

            var ad = Mono.Cecil.AssemblyDefinition.ReadAssembly(path);
            var name = ad.Name.Name;
            ad.Name.Name = name + "_" + Path.GetFileName(tempPath);
            ad.MainModule.Name = name + "_" + Path.GetFileName(tempPath);
            ad.Write(tempPath);

            //var t = execAssembly(tempPath);
            var a = Assembly.LoadFile(tempPath);
            var t = runAssembly( a, name );
            tempDb[t] = tempPath;
            return t;
        }
        /*
        public Thread execAssembly(string path)
        {
            Log.debug("Loader.execAssembly " + path);
            var a = Assembly.LoadFile(path);
            return runAssembly(a);
        }*/
        public Thread runAssembly(Assembly a, string trueName)
        {
            if (pluginDb.ContainsKey(trueName))
            {
                Thread oldThread = (Thread)pluginDb[trueName];
                Log.debug("Killing old thread for assembly: " + trueName);
                oldThread.Abort();
                Thread.Sleep(1000);
            }

            var t = new Thread(() => runAssembly_worker(a));
            pluginDb[trueName] = t;
            t.Start();
            Log.debug("Loader.runAssembly started new thread for " + a.FullName);
            return t;
        }
        public static void runAssembly_worker(Assembly a)
        {
            //var t = a.GetType("Plugin.Plugin");
            //var c = Activator.CreateInstance(t);
            //t.InvokeMember("init", BindingFlags.InvokeMethod, null, c, new object[] { });
            foreach (var t in a.GetExportedTypes())
            {
                var c = Activator.CreateInstance(t);
                t.InvokeMember("init", BindingFlags.InvokeMethod, null, c, new object[] { });
                // method 2
                //dynamic c = Activator.CreateInstance(t);
                //c.init();
            }
        }
    }

    public class Log
    {
        public static void debug(string msg)
        {
            log(msg);
        }
        public static void log(string msg)
        {
            Console.WriteLine(msg);
        }
        public static void say(string msg)
        {
            UIStatus.Get().AddInfo( msg );
            log(msg);
        }
    }
}
