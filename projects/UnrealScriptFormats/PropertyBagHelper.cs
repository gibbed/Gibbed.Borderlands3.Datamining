﻿/* Copyright (c) 2019 Rick (rick 'at' gibbed 'dot' us)
 *
 * This software is provided 'as-is', without any express or implied
 * warranty. In no event will the authors be held liable for any damages
 * arising from the use of this software.
 *
 * Permission is granted to anyone to use this software for any purpose,
 * including commercial applications, and to alter it and redistribute it
 * freely, subject to the following restrictions:
 *
 * 1. The origin of this software must not be misrepresented; you must not
 *    claim that you wrote the original software. If you use this software
 *    in a product, an acknowledgment in the product documentation would
 *    be appreciated but is not required.
 *
 * 2. Altered source versions must be plainly marked as such, and must not
 *    be misrepresented as being the original software.
 *
 * 3. This notice may not be removed or altered from any source
 *    distribution.
 */

using System;
using System.Collections.Generic;
using System.IO;

namespace UnrealScriptFormats
{
    public static class PropertyBagHelper
    {
        public delegate bool SerializeProperty(IUnrealSerializer serializer, ref PropertyTag tag);

        public static void SerializeTaggedProperties(
            IUnrealSerializer serializer,
            SerializeProperty serializeProperty,
            Dictionary<PropertyTag, object> unknownProperties)
        {
            SerializeTaggedProperties(serializer, serializeProperty, unknownProperties, true);
        }

        public static void SerializeTaggedProperties(
            IUnrealSerializer serializer,
            SerializeProperty serializeProperty,
            Dictionary<PropertyTag, object> unknownProperties,
            bool safe)
        {
            if (serializer.Mode != UnrealSerializationMode.Loading)
            {
                throw new InvalidOperationException();
            }

            while (true)
            {
                var tag = new PropertyTag();
                serializer.Serialize(ref tag);

                if (tag.Name == "None")
                {
                    break;
                }

                if (safe == false)
                {
                    if (serializeProperty == null || serializeProperty(serializer, ref tag) == false)
                    {
                        var bytes = new byte[tag.Size];
                        serializer.Serialize(bytes, 0, bytes.Length);
                        unknownProperties.Add(tag, bytes);
                    }
                }
                else
                {
                    var bytes = new byte[tag.Size];
                    serializer.Serialize(bytes, 0, bytes.Length);

                    if (serializeProperty == null)
                    {
                        unknownProperties.Add(tag, bytes);
                    }
                    else
                    {
                        using (var temp = new MemoryStream(bytes, false))
                        {
                            var safeSerializer = serializer.New(temp);
                            if (serializeProperty(safeSerializer, ref tag) == false)
                            {
                                unknownProperties.Add(tag, bytes);
                            }
                        }
                    }
                }
            }
        }
    }
}
