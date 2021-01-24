using System;
using Clerk.Models;

namespace Clerk
{
    public sealed partial class Logger : ILogger 
    {
        private string fatalPrefix = "FATAL";
        public void Fatal<T> (T rawMessage)
        {
            string unFormatedRawMessage = Convert.ToString(rawMessage);

            Message unFormatedMessage = new Message() {
                Prefix = this.fatalPrefix,
                UnFormatedRawMessage = unFormatedRawMessage,
                Tag = this.Tag
            };

            formatAndPrintMessage(unFormatedMessage);
        }
    }
}