// This enum is defined manually because GAPI only supports
// different enum type fixup in svn trunk (2009-05-06)

namespace Cogl
{
    [System.Flags]
    public enum MaterialLayerFlags : long
    {
        Matrix = 1L << 0
    }
}
