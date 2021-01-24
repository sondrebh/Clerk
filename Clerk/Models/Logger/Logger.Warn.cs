using System;
using Clerk.Models;

namespace Clerk
{
    public sealed partial class Logger : ILogger 
    {
        private string warnPrefix = "WARNING";
        public void Warn<T> (T rawMessage)
        {
            string unFormatedRawMessage = Convert.ToString(rawMessage);

            Message unFormatedMessage = new Message() {
                Prefix = this.warnPrefix,
                UnFormatedRawMessage = unFormatedRawMessage,
                Tag = this.Tag
            };

            formatAndPrintMessage(unFormatedMessage);
        }
    }
}