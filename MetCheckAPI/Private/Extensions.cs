
///-----------------------------------------------------------------
///   Namespace:      MetCheckAPI
///   Description:    Private extensions not to be consumed outside library
///-----------------------------------------------------------------

using System;


namespace MetCheckAPI.Private
{

    internal static class EnumExt
    {
        internal static string UrlRequestParameter(this ForecastRequestType enumVal)
        {
            switch (enumVal)
            {
                case ForecastRequestType.Astronomy:
                    return "As";

                case ForecastRequestType.Fishing:
                    return "Fi";

                case ForecastRequestType.Aviation:
                    return "Av";

                case ForecastRequestType.Soil:
                    return "So";

                case ForecastRequestType.Storm:
                    return "St";

                case ForecastRequestType.ClothesDrying:
                    return "Cd";

                case ForecastRequestType.Normal:
                default:
                    return "No";
            }

        }
    }
}
