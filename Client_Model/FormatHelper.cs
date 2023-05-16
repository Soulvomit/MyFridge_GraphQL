using System.Text;
using System.Text.RegularExpressions;

namespace Client_Model
{
    public static partial class FormatHelper
    {
        public static string PascalToCamel(string pascalStr)
        {
            if (pascalStr == null)
                return null;
            if (pascalStr.Length < 3)
                return pascalStr.ToLower();

            return char.ToLower(pascalStr[0]) + pascalStr.Substring(1);
        }
        public static string FormatNullableOutput(string nullable)
        {
            if (nullable != "null")
            {
                nullable = $$"""
                            \"{{nullable}}\"
                            """;
            }

            return nullable;
        }
        public static string FormatNullableInput(object nullable)
        {
            if (nullable != null)
            {
                return $$"""
                            \"{{nullable}}\"
                            """;
            }

            return "null";
        }
        public static string FormatPagination(int entries, string cursor = "null")
        {
            if (entries == -1)
                return string.Empty;

            cursor = FormatNullableOutput(cursor);

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
                        "query": 
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
