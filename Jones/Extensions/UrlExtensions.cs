namespace Jones.Extensions
{
    public static class UrlExtensions
    {
        /// <summary>
        /// 分析url链接，返回参数集合
        /// </summary>
        /// <param name="url">url链接</param>
        /// <param name="baseUrl"></param>
        /// <returns></returns>
        public static System.Collections.Specialized.NameValueCollection? ParseUrl(this string? url, out string? baseUrl)
        {
            baseUrl = "";
            if (string.IsNullOrEmpty(url))
                return null;
            var nvc = new System.Collections.Specialized.NameValueCollection();

            try
            {
                var questionMarkIndex = url.IndexOf('?');

                if (questionMarkIndex == -1)
                {
                    baseUrl = url;
                    return null;
                }
                baseUrl = url.Substring(0, questionMarkIndex);

                var ps = url.Substring(questionMarkIndex + 1);

                // 开始分析参数对   
                var re = new System.Text.RegularExpressions.Regex(@"(^|&)?(\w+)=([^&]+)(&|$)?", System.Text.RegularExpressions.RegexOptions.Compiled);
                var mc = re.Matches(ps);

                foreach (System.Text.RegularExpressions.Match m in mc)
                {
                    nvc.Add(m.Result("$2").ToLower(), m.Result("$3"));
                }

            }
            catch
            {
                // ignored
            }
            return nvc;
        }
    }
}