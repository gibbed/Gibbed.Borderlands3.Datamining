/* Copyright (c) 2019 Rick (rick 'at' gibbed 'dot' us)
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

namespace UnrealScriptFormats
{
    public class TaggedArray<TType> : IUnrealSerializable
        where TType: IUnrealSerializable, new()
    {
        public TaggedArray()
        {
            this.Items = new List<TType>();
        }

        public List<TType> Items { get; }

        public void Serialize(IUnrealSerializer serializer)
        {
            if (serializer.Mode == UnrealSerializationMode.Loading)
            {
                int count = 0;
                serializer.Serialize(ref count);

                var innerTag = new PropertyTag();
                serializer.Serialize(ref innerTag);

                var startPosition = serializer.Position;

                for (int i = 0; i < count; i++)
                {
                    var item = new TType();
                    serializer.Serialize(ref item);
                    this.Items.Add(item);
                }

                if (startPosition + innerTag.Size != serializer.Position)
                {
                    throw new InvalidOperationException();
                }
            }
            else
            {
                throw new NotSupportedException();
            }
        }
    }
}
