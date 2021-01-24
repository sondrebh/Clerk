using System;
using Clerk.Models;

namespace Clerk
{
    public sealed partial class Logger : ILogger 
    {
        private string errorPrefix = "ERROR";
        public void Error<T> (T rawMessage)
        {
            string unFormatedRawMessage = Convert.ToString(rawMessage);

            Message unFormatedMessage = new Message() {
                Prefix = this.errorPrefix,
                UnFormatedRawMessage = unFormatedRawMessage,
                Tag = this.Tag
            };

            formatAndPrintMessage(unFormatedMessage);
        }
    }
}