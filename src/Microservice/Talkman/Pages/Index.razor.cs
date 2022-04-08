using System.IO.Compression;
using System.Text;

namespace Talkman.Pages;
public partial class Index
{
    public string? HEXOrigin { get; set; }
    public string? UTF8Content { get; set; }
    public string? UTF8Origin { get; set; }
    public string? HEXContent { get; set; }


    /// <summary>
    /// utf8->hex
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    public void UTF8ToHEX()
    {
        if (UTF8Origin != null)
        {
            var bytes = Encoding.UTF8.GetBytes(UTF8Origin, 0, UTF8Origin.Length);
            var reverse =  bytes.Reverse().ToArray();
            HEXContent = Encoding.Unicode.GetString(reverse);

        }
    }

    /// <summary>
    /// hex-utf8
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    public void HEXToUTF8()
    {
        if (HEXOrigin != null)
        {
            var bytes = Encoding.Unicode.GetBytes(HEXOrigin, 0, HEXOrigin.Length);
            var reverse = bytes.Reverse().ToArray();
            UTF8Content = Encoding.UTF8.GetString(reverse);
        }
    }


    public static string Reverse(string s)
    {
        char[] charArray = s.ToCharArray();
        Array.Reverse(charArray);
        return new string(charArray);
    }
}
