using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using UnityEngine;

public class Blizzard
{
    public class Crypto
    {
        public class SHA1
        {
            public const int Length = 40;
            public const string Null = "0000000000000000000000000000000000000000";

            public static string Calc(byte[] bytes)
            {
                return Calc(bytes, 0, bytes.Length);
            }

            public static string Calc(FileInfo path)
            {
                return Calc(path.FullName);
            }

            public static string Calc(string path)
            {
                return Calc(System.IO.File.ReadAllBytes(path));
            }

            public static string Calc(byte[] bytes, int start, int count)
            {
                byte[] buffer = System.Security.Cryptography.SHA1.Create().ComputeHash(bytes, start, count);
                StringBuilder builder = new StringBuilder();
                foreach (byte num in buffer)
                {
                    builder.Append(num.ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }

    public class File
    {
        public static bool createFolder(string path)
        {
            string directoryName = System.IO.Path.GetDirectoryName(path);
            if (!string.IsNullOrEmpty(directoryName))
            {
                try
                {
                    Directory.CreateDirectory(directoryName);
                    return true;
                }
                catch (UnauthorizedAccessException exception)
                {
                    object[] args = new object[] { directoryName, exception.Message };
                    Blizzard.Log.Error("*** UnauthorizedAccessException writing {0}\n*** Exception was: {1}", args);
                }
                catch (ArgumentNullException exception2)
                {
                    object[] objArray2 = new object[] { directoryName, exception2.Message };
                    Blizzard.Log.Error("*** ArgumentNullException writing {0}\n*** Exception was: {1}", objArray2);
                }
                catch (ArgumentException exception3)
                {
                    object[] objArray3 = new object[] { directoryName, exception3.Message };
                    Blizzard.Log.Error("*** ArgumentException writing {0}\n*** Exception was: {1}", objArray3);
                }
                catch (PathTooLongException exception4)
                {
                    object[] objArray4 = new object[] { directoryName, exception4.Message };
                    Blizzard.Log.Error("*** PathTooLongException writing {0}\n*** Exception was: {1}", objArray4);
                }
                catch (DirectoryNotFoundException exception5)
                {
                    object[] objArray5 = new object[] { directoryName, exception5.Message };
                    Blizzard.Log.Error("*** DirectoryNotFoundException writing {0}\n*** Exception was: {1}", objArray5);
                }
                catch (IOException exception6)
                {
                    object[] objArray6 = new object[] { directoryName, exception6.Message };
                    Blizzard.Log.Error("*** IOException creating folder '{0}'\n*** Exception was: {1}", objArray6);
                    throw new ApplicationException(string.Format("Unable to create folder '{0}': {1}", directoryName, exception6.Message));
                }
                catch (NotSupportedException exception7)
                {
                    object[] objArray7 = new object[] { directoryName, exception7.Message };
                    Blizzard.Log.Error("*** NotSupportedException writing {0}\n*** Exception was: {1}", objArray7);
                }
            }
            return false;
        }

        public static int GetLastDirectoryIndex(string path)
        {
            int num = path.LastIndexOf(System.IO.Path.DirectorySeparatorChar);
            if (num < 0)
            {
                num = path.LastIndexOf(System.IO.Path.AltDirectorySeparatorChar);
            }
            return num;
        }

        public static void SearchFoldersForExtension(DirectoryInfo dir, string extension, ref List<FileInfo> results)
        {
            foreach (FileInfo info in dir.GetFiles(string.Format("*.{0}", extension), SearchOption.AllDirectories))
            {
                results.Add(info);
            }
        }

        public static void SearchFoldersForExtension(string dirPath, string extension, ref List<FileInfo> results)
        {
            if (Directory.Exists(dirPath))
            {
                SearchFoldersForExtension(new DirectoryInfo(dirPath), extension, ref results);
            }
        }

        public static void SearchFoldersForExtensions(DirectoryInfo dir, string[] extensions, ref List<FileInfo> results)
        {
            foreach (string str in extensions)
            {
                SearchFoldersForExtension(dir, str, ref results);
            }
        }

        public static void SearchFoldersForExtensions(string dirPath, string[] extensions, ref List<FileInfo> results)
        {
            if (Directory.Exists(dirPath))
            {
                SearchFoldersForExtensions(new DirectoryInfo(dirPath), extensions, ref results);
            }
        }

        public static bool SetFileWritableFlag(string path, bool setWritable)
        {
            bool flag;
            if (!System.IO.File.Exists(path))
            {
                return false;
            }
            try
            {
                FileAttributes attributes = System.IO.File.GetAttributes(path);
                FileAttributes fileAttributes = !setWritable ? (attributes | FileAttributes.ReadOnly) : (attributes & ~FileAttributes.ReadOnly);
                if (setWritable && (Environment.OSVersion.Platform == PlatformID.MacOSX))
                {
                    fileAttributes |= FileAttributes.Normal;
                }
                if (fileAttributes == attributes)
                {
                    return true;
                }
                System.IO.File.SetAttributes(path, fileAttributes);
                if (System.IO.File.GetAttributes(path) != fileAttributes)
                {
                    return false;
                }
                flag = true;
            }
            catch (DirectoryNotFoundException)
            {
            }
            catch (FileNotFoundException)
            {
            }
            catch (Exception)
            {
            }
            return flag;
        }

        public static bool SetFolderWritableFlag(string dirPath, bool writable)
        {
            foreach (string str in Directory.GetFiles(dirPath))
            {
                SetFileWritableFlag(str, writable);
            }
            foreach (string str2 in Directory.GetDirectories(dirPath))
            {
                SetFolderWritableFlag(str2, writable);
            }
            return true;
        }

        public class Asset
        {
            public string Hash { get; set; }

            public string Path { get; set; }
        }

        public class CopyTask
        {
            public bool overwrite = true;

            private CopyTask()
            {
            }

            public Result copy()
            {
                if (!this.sourceExists)
                {
                    return Result.MissingSource;
                }
                if (this.targetExists)
                {
                    if (!this.overwrite)
                    {
                        return Result.CantOverwriteTarget;
                    }
                    if (!Blizzard.File.SetFileWritableFlag(this.targetPath, true))
                    {
                        return Result.CantOverwriteTarget;
                    }
                }
                try
                {
                    if (this.sourceIsFolder)
                    {
                        copyRecursive(new DirectoryInfo(this.sourceFolder), this.targetFolder, this.overwrite);
                    }
                    else
                    {
                        Blizzard.File.createFolder(this.targetFolder);
                        System.IO.File.Copy(this.sourcePath, this.targetPath, this.overwrite);
                    }
                    return Result.Success;
                }
                catch (UnauthorizedAccessException exception)
                {
                    object[] args = new object[] { this.sourcePath, this.targetPath, exception.Message };
                    Blizzard.Log.Warning("*** Unauthorized access writing {0} to {1}\n*** Exception was: {2}", args);
                    return Result.UnauthorizedAccess;
                }
                catch (ArgumentNullException)
                {
                    return Result.ArgumentNull;
                }
                catch (ArgumentException)
                {
                    return Result.Argument;
                }
                catch (PathTooLongException)
                {
                    return Result.PathTooLong;
                }
                catch (DirectoryNotFoundException)
                {
                    return Result.DirectoryNotFound;
                }
                catch (FileNotFoundException)
                {
                    return Result.FileNotFound;
                }
                catch (IOException exception2)
                {
                    object[] objArray2 = new object[] { this.sourcePath, this.targetPath, exception2.Message };
                    Blizzard.Log.Warning("*** IO error writing {0} to {1}\n*** Exception was: {2}", objArray2);
                    return Result.IO;
                }
                catch (NotSupportedException)
                {
                    return Result.NotSupported;
                }
                catch (Exception exception3)
                {
                    object[] objArray3 = new object[] { this.sourcePath, this.targetPath, exception3.Message };
                    Blizzard.Log.Warning("*** Unknown error writing {0} to {1}: {2}", objArray3);
                    return Result.Unknown;
                }
            }

            private static void copyRecursive(DirectoryInfo source, string target, bool overwrite)
            {
                if (Blizzard.File.createFolder(target))
                {
                    foreach (FileInfo info in source.GetFiles())
                    {
                        object[] args = new object[] { target, info.Name };
                        System.IO.File.Copy(info.FullName, Blizzard.Path.combine(args), overwrite);
                    }
                    foreach (DirectoryInfo info2 in source.GetDirectories())
                    {
                        object[] objArray2 = new object[] { target, info2.Name };
                        copyRecursive(info2, Blizzard.Path.combine(objArray2), overwrite);
                    }
                }
            }

            public static Blizzard.File.CopyTask FileToFile(string s, string t)
            {
                return new Blizzard.File.CopyTask { sourcePath = s, targetPath = t };
            }

            public static Blizzard.File.CopyTask FileToFolder(string s, string t)
            {
                return new Blizzard.File.CopyTask { sourcePath = s, targetFolder = t, targetFilename = System.IO.Path.GetFileName(s) };
            }

            public static Blizzard.File.CopyTask FolderToFolder(string s, string t)
            {
                return new Blizzard.File.CopyTask { sourceFolder = s, targetFolder = t };
            }

            public override string ToString()
            {
                return string.Format("{0} => {1}", this.sourcePath, this.targetPath);
            }

            private static DateTime writeTime(bool isFolder, string path)
            {
                return (!isFolder ? System.IO.File.GetLastWriteTime(path) : Directory.GetLastWriteTime(path));
            }

            public bool sourceExists
            {
                get
                {
                    return (!this.sourceIsFolder ? System.IO.File.Exists(this.sourcePath) : Directory.Exists(this.sourceFolder));
                }
            }

            public string sourceFilename { get; private set; }

            public string sourceFolder { get; set; }

            public FileSystemInfo sourceInfo
            {
                get
                {
                    return (!this.targetIsFolder ? ((FileSystemInfo) new FileInfo(this.targetPath)) : ((FileSystemInfo) new DirectoryInfo(this.targetPath)));
                }
            }

            public bool sourceIsFolder
            {
                get
                {
                    return string.IsNullOrEmpty(this.sourceFilename);
                }
            }

            public string sourcePath
            {
                get
                {
                    // This item is obfuscated and can not be translated.
                    if (this.sourceFilename != null)
                    {
                        goto Label_0018;
                    }
                    return System.IO.Path.Combine(this.sourceFolder, string.Empty);
                }
                set
                {
                    this.sourceFolder = System.IO.Path.GetDirectoryName(value);
                    this.sourceFilename = System.IO.Path.GetFileName(value);
                }
            }

            public DateTime sourceTime
            {
                get
                {
                    return writeTime(this.sourceIsFolder, this.sourcePath);
                }
            }

            public bool targetExists
            {
                get
                {
                    return (!this.targetIsFolder ? System.IO.File.Exists(this.targetPath) : Directory.Exists(this.targetFolder));
                }
            }

            public string targetFilename { get; private set; }

            public string targetFolder { get; set; }

            public FileSystemInfo targetInfo
            {
                get
                {
                    return (!this.targetIsFolder ? ((FileSystemInfo) new FileInfo(this.targetPath)) : ((FileSystemInfo) new DirectoryInfo(this.targetPath)));
                }
            }

            public bool targetIsFolder
            {
                get
                {
                    return string.IsNullOrEmpty(this.targetFilename);
                }
            }

            public string targetPath
            {
                get
                {
                    if (this.targetIsFolder)
                    {
                        return (!this.sourceIsFolder ? System.IO.Path.Combine(this.targetFolder, this.sourceFilename) : this.targetFolder);
                    }
                    return System.IO.Path.Combine(this.targetFolder, this.targetFilename);
                }
                set
                {
                    this.targetFolder = System.IO.Path.GetDirectoryName(value);
                    this.targetFilename = System.IO.Path.GetFileName(value);
                }
            }

            public DateTime targetTime
            {
                get
                {
                    return writeTime(this.targetIsFolder, this.targetPath);
                }
            }

            public enum Result
            {
                Unknown,
                Success,
                MissingSource,
                CantOverwriteTarget,
                UnauthorizedAccess,
                ArgumentNull,
                Argument,
                PathTooLong,
                DirectoryNotFound,
                FileNotFound,
                IO,
                NotSupported
            }
        }
    }

    public class Log
    {
        public static void Error(string message)
        {
            try
            {
                Debug.LogError(string.Format("{0}: Error: {1}", Blizzard.Time.Stamp(), message));
            }
            catch (Exception)
            {
            }
        }

        public static void Error(string format, params object[] args)
        {
            Error(string.Format(format, args));
        }

        public static void SayToFile(StreamWriter logFile, string format, params object[] args)
        {
            try
            {
                string str = Blizzard.Time.Stamp() + ": " + string.Format(format, args);
                if (logFile != null)
                {
                    logFile.WriteLine(str);
                    logFile.Flush();
                }
            }
            catch (Exception)
            {
            }
        }

        public static void Warning(string message)
        {
            try
            {
                Debug.LogWarning(string.Format("{0}: Warning: {1}", Blizzard.Time.Stamp(), message));
            }
            catch (Exception)
            {
            }
        }

        public static void Warning(string format, params object[] args)
        {
            Warning(string.Format(format, args));
        }

        public static void Write(string message)
        {
            try
            {
                Debug.Log(string.Format("{0}: {1}", Blizzard.Time.Stamp(), message));
            }
            catch (Exception)
            {
            }
        }

        public static void Write(string format, params object[] args)
        {
            Write(string.Format(format, args));
        }
    }

    public static class Path
    {
        public static readonly string altSeparator = System.IO.Path.AltDirectorySeparatorChar.ToString();
        public static readonly string separator = System.IO.Path.DirectorySeparatorChar.ToString();

        public static string combine(params object[] args)
        {
            string str = string.Empty;
            foreach (object obj2 in args)
            {
                if ((obj2 != null) && !string.IsNullOrEmpty(obj2.ToString()))
                {
                    str = System.IO.Path.Combine(str, obj2.ToString());
                }
            }
            return str;
        }

        public static string lastFolderName(FileInfo file)
        {
            if (file == null)
            {
                return string.Empty;
            }
            string directoryName = file.DirectoryName;
            if (string.IsNullOrEmpty(directoryName))
            {
                return string.Empty;
            }
            int num = directoryName.LastIndexOf(@"\", StringComparison.OrdinalIgnoreCase);
            if (num < 0)
            {
                num = directoryName.LastIndexOf("/", StringComparison.OrdinalIgnoreCase);
                if (num < 0)
                {
                    return null;
                }
            }
            return directoryName.Remove(0, num + 1);
        }
    }

    public class Time
    {
        public static long BinaryStamp()
        {
            return DateTime.UtcNow.ToBinary();
        }

        public static string FormatElapsedTime(TimeSpan elapsedTime)
        {
            StringBuilder builder = new StringBuilder();
            if (elapsedTime.TotalHours >= 1.0)
            {
                builder.Append(string.Format("{0}h", Convert.ToInt32(elapsedTime.TotalHours)));
            }
            if (elapsedTime.Minutes >= 1.0)
            {
                builder.Append(string.Format("{0}m", Convert.ToInt32(elapsedTime.Minutes)));
            }
            builder.Append(elapsedTime.Seconds);
            builder.Append(".");
            builder.Append(elapsedTime.Milliseconds);
            builder.Append("s");
            return builder.ToString();
        }

        public static string Stamp()
        {
            return Stamp(DateTime.Now);
        }

        public static string Stamp(DateTime then)
        {
            return then.ToString("yyyy-MM-dd HH:mm:ss.fff");
        }

        public class ScopedTimer : IDisposable
        {
            private readonly string message_;
            private readonly DateTime start_ = DateTime.Now;

            private ScopedTimer(string message)
            {
                this.message_ = message;
            }

            public static Blizzard.Time.ScopedTimer Create(string postMessage)
            {
                return new Blizzard.Time.ScopedTimer(postMessage);
            }

            public static Blizzard.Time.ScopedTimer Create(string preMessage, string postMessage)
            {
                Blizzard.Log.Write(preMessage);
                return Create(postMessage);
            }

            public void Dispose()
            {
                Blizzard.Log.Write(string.Format("{0} ({1})", this.message_, Blizzard.Time.FormatElapsedTime(DateTime.Now.Subtract(this.start_))));
            }
        }
    }
}

