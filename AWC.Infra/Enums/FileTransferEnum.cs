using System.ComponentModel;

namespace AWC.Infra.Enums
{
    public enum FileTransferEnum
    {
        [Description("text/html")]
        HtmlText,
        [Description("application/octet-stream")]
        ApplicationStream,
        [Description("image/png")]
        ImagePng,
        [Description("text/plain")]
        PlainText,
        [Description("application/zip")]
        ApplicationZip
    }
}
