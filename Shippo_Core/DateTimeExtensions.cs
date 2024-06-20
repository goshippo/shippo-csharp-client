﻿/*
 * Copyright 2011 Xamarin, Inc.
 *
 * Author(s):
 * 	Gonzalo Paniagua Javier (gonzalo@xamarin.com)
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *      http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */
using System;

namespace Shippo {
    public static class DateTimeExtensions {
        static DateTime epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        public static DateTime FromUnixEpoch(this int utc_unix)
        {
            return epoch.AddSeconds(utc_unix);
        }

        public static DateTime FromUnixEpoch(this long utc_unix)
        {
            return epoch.AddSeconds(utc_unix);
        }

        public static long ToUnixEpoch(this DateTime dt)
        {
            dt = dt.ToUniversalTime();
            return Convert.ToInt64((dt - epoch).TotalSeconds);
        }

        public static long UnixTimeNow()
        {
            var timeSpan = (DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0));
            return (long) timeSpan.TotalSeconds;
        }
    }
}
