using System;
using Clerk.Models;

namespace Clerk
{
    public sealed partial class Logger : ILogger
    {
        private string debugPrefix = "DEBUG";
        public void Debug<T> (T rawMessage)
        {
            #if !DEBUG
            return;
            #endif

            string unFormatedRawMessage = Convert.ToString(rawMessage);

            Message unFormatedMessage = new Message() {
                Prefix = this.debugPrefix,
                UnFormatedRawMessage = unFormatedRawMessage,
                Tag = this.Tag
            };

            formatAndPrintMessage(unFormatedMessage);
        }
    }
}