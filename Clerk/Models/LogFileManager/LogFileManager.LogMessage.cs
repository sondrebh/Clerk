using System;
using System.Diagnostics;
using System.IO;

namespace Clerk.Models
{
    public sealed partial class LogFileManager : ILogFileManager
    {
        
        #region State
        private string currentProgramPath = null;
        private int currentLogFileIndex = 0;
        private Lazy<StreamWriter> logFileStreamWriterSingleton = null;
        private StreamWriter logFileStreamWriter => logFileStreamWriterSingleton.Value;
        private bool logFileSpecificsValidationRunning = false;
        #endregion

        public void LogMessage(string message)
        {
            if(logFileSpecificsNeedsValidation())
                validateLogFileSpecifics();

            if(loggingToFileIsNotAvailable())
                return;

            if(logFileStreamWriterIsNotSet())
                setLogFileStreamWriter();

            logFileStreamWriter.WriteLine(message);
            logFileStreamWriter.Flush();
        }

        private void validateLogFileSpecifics()
        {
            if(logFileSpecificsValidationRunning)
                return;

            startValidationOfLogFileSpecifics();

            if(logFileIndexIsZero())
                increaseLogFileIndex();

            while(logFileSpecificsValidationRunning)
            {
                validateLogFileAtIndex();
            }
        }

        private void validateLogFileAtIndex()
        {
            if(logFileAtCurrentIndexExists()) {
                evaluateLogFileAtCurrentIndex();
            } else {
                updateLogFileSpecifics();
            }
        }
        private void evaluateLogFileAtCurrentIndex()
        {
            if(logFileAtCurrentIndexExceedsSizeLimit()) {
                continueValidationOfLogFileSpecifics();
            } else {
                endValidationOfLogFileSpecifics();
            }
        }

        private void updateLogFileSpecifics()
        {
            if(currentLogFileIndexIsLessThanMax()) {
                createLogFileAtCurrentIndex();
                setLogFileStreamWriter();
            }

            endValidationOfLogFileSpecifics();
        }

        #region Conditionals

        private bool currentLogFileIndexIsLessThanMax()
            => (this.currentLogFileIndex <= this.LogFileMaxCount);

        private void startValidationOfLogFileSpecifics()
            => logFileSpecificsValidationRunning = true;

        private void continueValidationOfLogFileSpecifics()
            => increaseLogFileIndex();

        private void endValidationOfLogFileSpecifics()
            => logFileSpecificsValidationRunning = false;

        private bool logFileSpecificsNeedsValidation()
            => (logFileStreamWriterIsNotSet() || currentLogFileSizeExceedsLimit());

        private bool logFileStreamWriterIsSet()
            => (logFileStreamWriterSingleton != null);

        private bool logFileStreamWriterIsNotSet()
            => (logFileStreamWriterSingleton == null);

        private bool loggingToFileIsNotAvailable()
            => (this.FileLoggingEnabled && (this.LogFileMaxCount > 0) && (this.currentLogFileIndex <= this.LogFileMaxCount)) == false;

        private bool loggingIsAvailable()
            => (this.FileLoggingEnabled && (this.LogFileMaxCount > 0) && (this.currentLogFileIndex <= this.LogFileMaxCount)) == true;

        private bool currentProgramPathIsNotSet()
            => (currentProgramPath == null);
    
        private bool logFileIndexIsZero()
            => currentLogFileIndex == 0;

        private bool currentLogFileSizeExceedsLimit()
        {
            if(logFileStreamWriterIsSet()) {
                return (logFileStreamWriterSingleton.Value.BaseStream.Length / 1000) > this.LogFileMaxSizeInKB;
            } else {
                return false; 
            }
        }
        
        private bool logFileAtCurrentIndexExceedsSizeLimit()
            => (new FileInfo(getLogFilePath()).Length / 1000) > this.LogFileMaxSizeInKB;

        private bool logFileAtCurrentIndexExists()
            => File.Exists(getLogFilePath());

        #endregion Conditionals

        private void setLogFileStreamWriter()
            => logFileStreamWriterSingleton = new Lazy<StreamWriter>(
                () => new StreamWriter(this.getLogFilePath(), true)
            );

        private string getLogFilePath()
        {
            string programPath = getProgramPath();
            string logFilePath = $"{programPath}\\{this.LogFilePrefix}_{this.currentLogFileIndex}.txt";
            return logFilePath;
        }

        private string getProgramPath()
        {
            if(currentProgramPathIsNotSet())
                setCurrentProgramPath();

            return this.currentProgramPath;
        }

        private void setCurrentProgramPath()
        {
            currentProgramPath = Path.GetDirectoryName(
                Process.GetCurrentProcess().MainModule.FileName
            );
        }

        private void createLogFileAtCurrentIndex()
        {
            using (StreamWriter sw = File.CreateText(getLogFilePath()));
        }

        private void increaseLogFileIndex()
            => currentLogFileIndex += 1;
    }
}