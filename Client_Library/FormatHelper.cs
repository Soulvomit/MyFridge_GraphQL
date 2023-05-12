using System.Text;
using System.Text.RegularExpressions;

namespace Client_Library
{
    public static partial class FormatHelper
    {
        public static string FormatNullable(string cursor)
        {
            if (cursor != "null")
            {
                cursor = $$"""
                            \"{{cursor}}\"
                            """;
            }

            return cursor;
        }
        public static string FormatPagination(int entries, string cursor = "null")
        {
            if (entries == -1)
                return string.Empty;

            cursor = FormatNullable(cursor);

            return $$"""
                    first: {{entries}} after: {{cursor}}
                    """;
        }
        public static string FormatFilter(string condition)
        {
            if (string.IsNullOrEmpty(condition))
                return string.Empty;

            return $$"""
                    where: {{{condition}}}
                    """;
        }
        public static string FormatOrder(string order)
        {
            if (string.IsNullOrEmpty(order))
                return string.Empty;

            return $$"""
                    order: {{{order}}}
                    """;
        }
        public static string FormatItems(params string[] items)
        {
            StringBuilder itemBuilder = new();
            foreach (string item in items)
            {
                itemBuilder.Append(item).Append(' ');
            }
            return itemBuilder.ToString();
        }
        public static string FormatQuery(string query)
        {
            query = $$"""
                    {
                        "query": 
                        "
                        {{query}}
                        " 
                    }
                    """;

            string trimmedQuery = QueryRegex().Replace(query, " ");
            return trimmedQuery/*.Replace("( )", "")*/;
        }
        public static string FormatMutation(string mutation)
        {
            mutation = $$"""
                    {
                        "mutation": 
                        "
                        {{mutation}}
                        " 
                    }
                    """;

            string trimmedMutation = MutationRegex().Replace(mutation, " ");
            return trimmedMutation;
        }

        [GeneratedRegex("(\\s+|\\r\\n|( ))\\s*")]
        private static partial Regex QueryRegex();
        [GeneratedRegex("(\\s+|\\r\\n)\\s*")]
        private static partial Regex MutationRegex();
    }
}
