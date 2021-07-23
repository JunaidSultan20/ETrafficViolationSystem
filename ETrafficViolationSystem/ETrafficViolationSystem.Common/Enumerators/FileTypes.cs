using System.ComponentModel;

namespace ETrafficViolationSystem.Common.Enumerators
{
    public enum FileTypes
    {
        [Description(".html")]
        HTML = 1,
        [Description(".pdf")]
        PDF,
        [Description(".csv")]
        CSV,
        [Description(".xls")]
        XLS,
        [Description(".docx")]
        DOCX,
        [Description(".ppt")]
        PPT,
        [Description(".xml")]
        XML
    }
}