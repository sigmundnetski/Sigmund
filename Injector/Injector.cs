using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mono.Cecil;
using Mono.Cecil.Cil;

namespace Injector
{
    class Injector
    {
        static string appOrigPath = @"C:\Users\Joseph\Documents\Visual Studio 2013\Projects\HearthstoneBot\ext\Assembly-CSharp.orig.dll";
        static string injPath = @"C:\Users\Joseph\Documents\Visual Studio 2013\Projects\HearthstoneBot\ext\Sigmund.dll";
        static string appPatchedPath = @"C:\Users\Joseph\Documents\Visual Studio 2013\Projects\HearthstoneBot\ext\Assembly-CSharp.dll";

        static string appTypeName = "SceneMgr";
        static string appMethodName = "Start";
        static string injTypeName = "Main";
        static string injMethodName = "Start";
        
        static void Main(string[] args)
        {
            var app = AssemblyDefinition.ReadAssembly(appOrigPath);
            var inj = AssemblyDefinition.ReadAssembly(injPath);

            var injType = inj.MainModule.Types.Single(t => t.Name == injTypeName);
            var injMethod = injType.Methods.Single(t => t.Name == injMethodName);

            var appType = app.MainModule.Types.Single(t => t.Name == appTypeName);
            var appMethod = appType.Methods.Single(t => t.Name == appMethodName);

            var ipl = appMethod.Body.GetILProcessor();
            var firstInstruction = ipl.Body.Instructions[0];
            var instruction = ipl.Create(OpCodes.Call, app.MainModule.Import(injMethod.Resolve()));
            ipl.InsertBefore(firstInstruction, instruction);
            app.Write(appPatchedPath);
        }
    }
}
