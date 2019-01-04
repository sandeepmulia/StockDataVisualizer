using System;
using System.IO;

namespace StockDataVisualizer
{
    /// <summary>
    /// Lazy Singleton Logger instantiated on demand
    /// </summary>
    public sealed class Logger : IDisposable
    {
        private string LogFileName = String.Empty;
        private FileStream fileStream;
        private StreamWriter streamWriter;

        private Logger()
        {
            fileStream = new FileStream(GetLoggerFileName, FileMode.OpenOrCreate);
            streamWriter = new StreamWriter(fileStream);
        }

        public string GetLoggerFileName
        {
            get
            {
                if(String.IsNullOrEmpty(LogFileName))
                {
                    LogFileName = Path.GetTempFileName();
                }
                return LogFileName;
            }
        }

        private static readonly Lazy<Logger> logger = new Lazy<Logger>(()=>new Logger());
        public static Logger Instance
        {
            get { return logger.Value; }
        }

        public void Log(string info)
        {
            streamWriter.AutoFlush = true;
            streamWriter.WriteLine(info);
        }

        #region IDisposable Members

        public void Dispose()
        {
            if(fileStream != null)
                fileStream.Close();
        }

        #endregion
    }
}
