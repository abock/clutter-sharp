// This enum is defined manually because GAPI only supports
// different enum type fixup in svn trunk (2009-05-06)

namespace Cogl
{
    [System.Flags]
    public enum BufferBit : long
    {
        Color = 1L << 0,
        Depth = 1L << 1,
        Stencil = 1L << 2,
    }
}
