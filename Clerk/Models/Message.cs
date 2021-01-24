namespace Clerk.Models
{
    public struct Message
    {
        public string Prefix;
        public string UnFormatedRawMessage;
        public string Tag;

        public void Deconstruct(out string prefix, out string unFormatedRawMessage, out string tag)
        {
            prefix = this.Prefix;
            unFormatedRawMessage = this.UnFormatedRawMessage;
            tag = this.Tag;
        }
    }
}