namespace Ads.Helpers
{
    public static class PropertyInjector
    {
        public static T InjectNonNull<T>(T dest, T src)
        {
            if (dest == null || src == null)
            {
                throw new ArgumentNullException("Source and destination objects must not be null");
            }

            var properties = typeof(T).GetProperties();

            foreach (var property in properties)
            {
                if (property.CanWrite)
                {
                    var fromValue = property.GetValue(src, null);

                    if (fromValue != null)
                    {
                        property.SetValue(dest, fromValue, null);
                    }
                }
            }

            return dest;
        }
    }
}
