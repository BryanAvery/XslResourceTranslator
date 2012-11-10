using System.Resources;
using System.Text.RegularExpressions;

namespace Translator
{
    /// <summary>
    /// Takes text and checks to see if it can be translated
    /// </summary>
    public class ResourceTranslator
    {
        private string _baseName;

        public ResourceTranslator()
        {
            _baseName = "Dummy.Resource";
        }

        public ResourceTranslator(string baseName)
        {
            _baseName = baseName;
        }

        /// <summary>
        /// Finds the specified displaytext.
        /// </summary>
        /// <param name="displayText">The display text.</param>
        /// <returns></returns>
        public string Find(string displayText)
        {
            if (displayText == null) return null;

            var assem = System.Reflection.Assembly.Load("Resources");
            var rman = new ResourceManager(_baseName, assem);
            var s = rman.GetString(Regex.Replace(displayText, "[^\\w]", string.Empty, RegexOptions.CultureInvariant));
            
            return s ?? displayText;
        }

    }
}
