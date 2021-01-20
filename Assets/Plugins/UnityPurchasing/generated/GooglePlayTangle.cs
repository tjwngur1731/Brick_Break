#if UNITY_ANDROID || UNITY_IPHONE || UNITY_STANDALONE_OSX || UNITY_TVOS
// WARNING: Do not modify! Generated file.

namespace UnityEngine.Purchasing.Security {
    public class GooglePlayTangle
    {
        private static byte[] data = System.Convert.FromBase64String("HK4tDhwhKiUGqmSq2yEtLS0pLC+O+/k6iK6ND5aLz4EsoDy3rVrSuTa90GYQeRndAsBX69h9qD5mdNgD7+X/BE1M8GEeCQelq4mz2DF80xNybque/4FtYgfIyvYLZz37euDNcdDviNBXCArMYcGLZ4n2lsGdRnCEMfn4gYBtEYM8+h/N3JLQxiAt74rjB8ht/GMg/zBY17pe8cdKpEAyf0IFuXGqJIDKImpjFxt+RH2fR/lh3R7gBuIrRa4lwek3C9h4wQbt9H6uLSMsHK4tJi6uLS0spUBqztZ4dUQuuy576cjxT2pbq8g7lzpQFrXzE4+HFCsljEpWC1QKmz3z+BAR10RdCZe4cttK68YfesbOZpt85xYCk/oLD1zdPACxvy4vLSwt");
        private static int[] order = new int[] { 0,11,12,12,8,6,13,13,9,13,11,13,12,13,14 };
        private static int key = 44;

        public static readonly bool IsPopulated = true;

        public static byte[] Data() {
        	if (IsPopulated == false)
        		return null;
            return Obfuscator.DeObfuscate(data, order, key);
        }
    }
}
#endif
