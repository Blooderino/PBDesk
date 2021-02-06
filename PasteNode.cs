using System;
using System.Windows.Forms;

namespace PBDesk
{
    class PasteNode : TreeNode
    {
        public const String
            PASTE_NODE_DEFAULT_TAG = "PasteNode",
            PASTE_NODE_FILE_TYPE_TAG = "FileTypeNode";

        public PasteNode
            (in String key, in String date, in String title, in String size, in String expire_date,
             in String access_limitation, in String format_long, in String format_short, in String url, 
             in String hits) : base()
        {
            this.PasteKey = key;
            this.PasteDate = date;
            this.PasteTitle = title.Length > 0 ? title : "Untitled";
            this.PasteSize = size;
            this.PasteExpireDate = expire_date;
            this.PasteAccessLimitation = access_limitation;
            this.PasteFormatLong = format_long;
            this.PasteFormatShort = format_short;
            this.PasteUrl = url;
            this.PasteHits = hits;
            this.Tag = PasteNode.PASTE_NODE_DEFAULT_TAG;
        }

        public String PasteKey { get; private set; }
        public String PasteDate { get; private set; }
        public String PasteTitle { get => this.Text; private set => this.Text = value; }
        public String PasteSize { get; private set; }
        public String PasteExpireDate { get; private set; }
        public String PasteAccessLimitation { get; private set; }
        public String PasteFormatLong { get; private set; }
        public String PasteFormatShort { get; private set; }
        public String PasteUrl { get; private set; }
        public String PasteHits { get; private set; }
    }
}
