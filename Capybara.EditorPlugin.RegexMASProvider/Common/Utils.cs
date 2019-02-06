using System;
using System.IO;
using System.Reflection;
using System.Text.RegularExpressions;
using Microsoft.VisualBasic;

namespace Capybara.EditorPlugin.RegexMASProvider.Common
{
    public static class Utils
    {
        public static string GetSettingsPath(string fileNameSuffix)
        {
            Assembly executingAssembly = Assembly.GetExecutingAssembly();
            string name = executingAssembly.GetName().Name;
            string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), name);
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            return Path.Combine(path, name + fileNameSuffix);
        }

        public static string WideToNarrow(this string text)
        {
            return Regex.Replace(text, @"[０-９ａ-ｚＡ-Ｚ]",
                m => Strings.StrConv(m.Value, VbStrConv.Narrow, 0x0411));
        }

        public static bool IsNumber(this string s)
        {
            return int.TryParse(s, out _);
        }

        public static string ReplaceFirst(this string text, string search, string replace)
        {
          int pos = text.IndexOf(search);
          if (pos < 0)
          {
            return text;
          }
          return text.Substring(0, pos) + replace + text.Substring(pos + search.Length);
        }
        
    }
}
