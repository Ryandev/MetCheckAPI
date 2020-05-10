
///-----------------------------------------------------------------
///   Namespace:      MetCheckAPI
///   Description:    Library configuration not to be consumed outside library
///-----------------------------------------------------------------

using System;
using static System.Environment;


namespace MetCheckAPI.Private
{
    public static class FetchSettings
    {
        public static string UserAgent => GetEnvironmentVariable("MetCheckAPI-UserAgent") ?? "Ryandev/MetCheckAPI";
        public static string Scheme    => GetEnvironmentVariable("MetCheckAPI-Scheme")    ?? "http";
        public static string Host      => GetEnvironmentVariable("MetCheckAPI-Host")      ?? "ws1.metcheck.com";
        public static string Path      => GetEnvironmentVariable("MetCheckAPI-Path")      ?? "/ENGINE/v9_0/json.asp";
    }
}
