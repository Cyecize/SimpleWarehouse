using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleWarehouse.Constants
{
    public class RevenueDataTableNames
    {
        public const string USERNAME = "USERNAME";
        public const string REVENUE_AMOUNT = "REVENUE_AMOUNT";
        public const string DATE = "DATE";
        public const string IS_REVISED = "IS_REVISED";
        public const string COMMENT = "COMMENT";

        public static Dictionary<string, string> GetNamesForAddRevenue()
        {
            Dictionary<string, string> keyValuePairs = new Dictionary<string, string>() { };
            keyValuePairs[USERNAME] = "Username";
            keyValuePairs[REVENUE_AMOUNT] = "Amount";
            keyValuePairs[DATE] = "Date";
            keyValuePairs[IS_REVISED] = "IsRevised";
            keyValuePairs[COMMENT] = "Comment";

            return keyValuePairs;
        }

        public static Dictionary<string, string> GetNamesForArchivedRevenues()
        {
            Dictionary<string, string> keyValuePairs = new Dictionary<string, string>() { };
            keyValuePairs[USERNAME] = "UsernameArch";
            keyValuePairs[REVENUE_AMOUNT] = "AmountArch";
            keyValuePairs[DATE] = "DateArch";
            keyValuePairs[IS_REVISED] = "IsRevisedArch";
            keyValuePairs[COMMENT] = "CommentArch";

            return keyValuePairs;
        }
    }
}
