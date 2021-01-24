using System;
using Clerk.Models;

namespace Clerk
{
    public sealed partial class Logger : ILogger
    {
        private string infoPrefix = "INFO";
        public void Info<T> (T rawMessage)
        {
            string unFormatedRawMessage = Convert.ToString(rawMessage);

            Message unFormatedMessage = new Message() {
                Prefix = this.infoPrefix,
                UnFormatedRawMessage = unFormatedRawMessage,
                Tag = this.Tag
            };

            formatAndPrintMessage(unFormatedMessage);
        }
    }
}