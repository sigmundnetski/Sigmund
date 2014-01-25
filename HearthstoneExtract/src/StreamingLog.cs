using System;
using System.IO;

public abstract class StreamingLog
{
    private static StreamWriter log_;

    protected StreamingLog()
    {
    }

    public static void LogAssetCacheItemCorrupt(Asset asset, string computedHash)
    {
        if (Streaming.Enabled)
        {
            object[] args = new object[] { asset.EditorPath, asset.URL, asset.CachePath, Blizzard.Time.Stamp(), computedHash };
            Say("FAILED cache validation '{0}'\n  from='{1}'\n  dest='{2}'\n  time={3}\n  hash={4}", args);
        }
    }

    public static void LogAssetDownloadCorrupt(Asset asset, string computedHash)
    {
        if (Streaming.Enabled)
        {
            object[] args = new object[] { asset.EditorPath, asset.URL, asset.CachePath, Blizzard.Time.Stamp(), computedHash };
            Say("FAILED download validation '{0}'\n  from='{1}'\n  dest='{2}'\n  time={3}\n  hash={4}", args);
        }
    }

    public static void LogAssetDownloaded(Asset asset, int requestCount)
    {
        if (Streaming.Enabled)
        {
            object[] args = new object[] { asset.EditorPath, asset.URL, asset.CachePath, Blizzard.Time.Stamp(), requestCount };
            Say("Downloaded '{0}'\n  from='{1}'\n  dest='{2}'\n  time={3}\n  reqs={4}", args);
        }
    }

    public static void LogAssetDownloadFailed(Asset asset, string error)
    {
        if (Streaming.Enabled)
        {
            object[] args = new object[] { asset.EditorPath, asset.URL, asset.CachePath, Blizzard.Time.Stamp(), error };
            Say("FAILED download '{0}'\n  from='{1}'\n  dest='{2}'\n  time={3}\n  note={4}", args);
        }
    }

    public static void LogAssetLoaded(Asset asset, int requestCount)
    {
        if (Streaming.Enabled)
        {
            object[] args = new object[] { asset.EditorPath, asset.FileURL, Blizzard.Time.Stamp(), requestCount };
            Say("Loaded '{0}'\n  from='{1}'\n  time={2}\n  reqs={3}", args);
        }
    }

    public static void LogAssetMatchFailed(Asset asset, string computedHash)
    {
        if (Streaming.Enabled)
        {
            object[] args = new object[] { asset.EditorPath, asset.URL, asset.CachePath, Blizzard.Time.Stamp(), computedHash };
            Say("FAILED validation '{0}'\n  from='{1}'\n  dest='{2}'\n  time={3}\n  hash={4}", args);
        }
    }

    public static void LogAssetRequested(Asset asset)
    {
        if (Streaming.Enabled)
        {
            object[] args = new object[] { asset.EditorPath, asset.URL, asset.CachePath, Blizzard.Time.Stamp() };
            Say("Requested '{0}'\n  from='{1}'\n  dest='{2}'\n  time={3}", args);
        }
    }

    public static void LogAssetSaved(Asset asset)
    {
        if (Streaming.Enabled)
        {
            object[] args = new object[] { asset.EditorPath, asset.URL, asset.CachePath, Blizzard.Time.Stamp() };
            Say("Saved '{0}'\n  from='{1}'\n  dest='{2}'\n  time={3}", args);
        }
    }

    public static void LogAssetSaveFailed(Asset asset, string error)
    {
        if (Streaming.Enabled)
        {
            object[] args = new object[] { asset.EditorPath, asset.URL, asset.CachePath, Blizzard.Time.Stamp(), error };
            Say("FAILED save '{0}'\n  from='{1}'\n  dest='{2}'\n  time={3}\n  note={4}", args);
        }
    }

    public static void Say(string format, params object[] args)
    {
        if (log_ != null)
        {
            Blizzard.Log.SayToFile(log_, format, args);
        }
        Log.Asset.Print(format, args);
    }

    public static void Start()
    {
        if (Streaming.Enabled)
        {
            try
            {
                log_ = System.IO.File.AppendText("streaming.log");
                if (log_ != null)
                {
                    log_.AutoFlush = true;
                    Blizzard.Log.SayToFile(log_, "==============================================================================", new object[0]);
                    Blizzard.Log.SayToFile(log_, "Streaming log begins", new object[0]);
                    Blizzard.Log.SayToFile(log_, "==============================================================================", new object[0]);
                }
            }
            catch (Exception)
            {
            }
        }
    }

    public static void Stop()
    {
        if (Streaming.Enabled && (log_ != null))
        {
            Blizzard.Log.SayToFile(log_, "==============================================================================", new object[0]);
            Blizzard.Log.SayToFile(log_, "Streaming log ends", new object[0]);
            Blizzard.Log.SayToFile(log_, "==============================================================================", new object[0]);
            log_.Close();
            log_ = null;
        }
    }
}

