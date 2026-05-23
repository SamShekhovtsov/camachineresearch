using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using CA.Localization.Properties;

namespace CA.Localization
{
    public class LocalizationInfo
    {
        public static CultureInfo UserCulture { get { return Settings.Default.UserCulture; } }
        public static CultureInfo DefaultCulture { get { return Settings.Default.DefaultCulture; } }
        public static CultureInfo UkrainianCulture { get { return Settings.Default.UkrCulture; } }
    }
}
