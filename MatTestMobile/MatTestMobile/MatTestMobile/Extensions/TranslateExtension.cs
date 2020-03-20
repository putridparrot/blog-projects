using System;
using System.Reflection;
using System.Resources;
using Plugin.Multilingual;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MatTestMobile.Extensions
{
    [ContentProperty("Text")]
    public class TranslateExtension : IMarkupExtension
    {
        const string ResourceId = "MatTestMobile.Resources.AppResources";

        static readonly Lazy<ResourceManager> Resmgr = new Lazy<ResourceManager>(() => new ResourceManager(ResourceId, typeof(TranslateExtension).GetTypeInfo().Assembly));

        public string Text { get; set; }

        public object ProvideValue(IServiceProvider serviceProvider)
        {
            if (Text == null)
                return "";

            var ci = CrossMultilingual.Current.CurrentCultureInfo;
            var translation = Resmgr.Value.GetString(Text, ci);
            if (translation == null)
            {
#if DEBUG
                throw new ArgumentException(
                    $"Key '{Text}' was not found in resources '{ResourceId}' for culture '{ci.Name}'.",
                    "Text");
#else
				translation = Text; // returns the key, which GETS DISPLAYED TO THE USER
#endif
            }
            return translation;
        }
    }

}
